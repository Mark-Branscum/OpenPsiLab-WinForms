using OpenPsiLabWinForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views;
using OpenPsiLabWinForms.Views.Alerts;

namespace OpenPsiLabWinForms.Controllers
{
    public class SessionController
    {
        private ADatabase sessionDatabase;
        private SiderealTimeUtilities sideTimeUtilities;
        private OPLConfiguration oplConfig;
        private ImageUtilities imageUtils;
        public SessionController(ADatabase sessionDB, OPLConfiguration oplConfiguration)
        {
            sessionDatabase = sessionDB;
            sideTimeUtilities = new SiderealTimeUtilities();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
        }
        
        public string SessionPracticeSaveToFolder(RVSession rvSession,
            SessionForm sessionForm, List<string> fileList,  string exportFolderFullPath = "",
            bool includeScreenshot = false, SessionExportConfiguration exportConfig = null)
        {
            string returnString = string.Empty;

            //Setup directory
            DateTimeOffset dtoUtc = DateTimeOffset.Now.ToUniversalTime();
            int year = dtoUtc.Year;
            string month = dtoUtc.Month.ToString();
            if (dtoUtc.Month < 10) month = $"0{month}";
            string day = dtoUtc.Day.ToString();
            if (dtoUtc.Day < 10) day = $"0{day}";
            string destinationFolderPath;

            string sessionFolderName;
            if (string.IsNullOrWhiteSpace(rvSession.Name))
            {
                sessionFolderName = $"{year}-{month}-{day}_" +
                    "BlankSessionName" +
                    $"_UUID_{rvSession.UUID}";
            }
            else
            {
                sessionFolderName = $"{year}-{month}-{day}_" +
                    $"{RemoveSpecialCharacters(rvSession.Name)}" +
                    $"_UUID_{rvSession.UUID}";
            }
                

            if (string.IsNullOrWhiteSpace(exportFolderFullPath))
            {
                destinationFolderPath = Path.Combine(oplConfig.ExportSessionPath,
                sessionFolderName);
                if (Directory.Exists(destinationFolderPath) == false)
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }
            }
            else
            {
                destinationFolderPath = Path.Combine(exportFolderFullPath, sessionFolderName);
                if (Directory.Exists(destinationFolderPath) == false)
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }
                
                //destinationFolderPath = exportFolderFullPath;
            }

            if (exportConfig == null || 
                (exportConfig != null && exportConfig.GeomagneticWeather == true))
            {
                //Setup GUIDs
                Guid overviewGUID = rvSession.UUID; 
                rvSession.SWXOverviewLargeUUID = overviewGUID.ToString();
                Guid notificationGUID = rvSession.UUID; 
                rvSession.NotificationsInEffectTimelineUUID = notificationGUID.ToString();

                //Get image files
                string overviewURL =
                    @"https://services.swpc.noaa.gov/images/swx-overview-large.gif";
                string noficationURL =
                    @"https://services.swpc.noaa.gov/images/notifications-in-effect-timeline.png";
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(new Uri(overviewURL), 
                            Path.Combine(destinationFolderPath, $"swx-overview-large-{overviewGUID}.gif"));
                        client.DownloadFile(new Uri(noficationURL),
                            Path.Combine(destinationFolderPath, 
                                $"notifications-in-effect-timeline-{notificationGUID}.png"));
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
                }
            }

            if (includeScreenshot || (exportConfig != null && exportConfig.Screenshot == true))
            {
                rvSession.ScreenshotUUID = rvSession.UUID; 
                sessionForm.screenshot(destinationFolderPath, rvSession.UUID.ToString());
            }
            
            //This converter will ensure the session type is saved
            //as a string and not an int
            JsonSerializerOptions opts = new JsonSerializerOptions
            {
                Converters ={
                    new JsonStringEnumConverter()
                }
            };
            opts.WriteIndented = true;
            string sessionJson = string.Empty;
            try
            {
                sessionJson = JsonSerializer.Serialize<RVSession>((RVSession)rvSession, opts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            string sessionName = rvSession.Name;
            if (string.IsNullOrWhiteSpace(sessionName))
            {
                sessionName = "BlankSessionName";
            }
            else
            {
                sessionName = RemoveSpecialCharacters(rvSession.Name);
            }
            string jsonPath = Path.Combine(destinationFolderPath, 
                 $"{sessionName}_{rvSession.UUID}_SESSION.json");
            File.WriteAllText(jsonPath, sessionJson);

            //Save to csv
            string sessionCSV = rvSession.ToCommaSeparatedValues();
            string csvPath = Path.Combine(destinationFolderPath, $"{sessionName}_{rvSession.UUID}.csv");
            File.WriteAllText(csvPath, sessionCSV);

            //Save to tsv
            string sessionTSV = rvSession.ToTabSeparatedValues();
            string tsvPath = Path.Combine(destinationFolderPath, $"{sessionName}_{rvSession.UUID}.tsv");
            File.WriteAllText(tsvPath, sessionTSV);
            
            //Save files that the user has added
            string fileDestination = Path.Combine(destinationFolderPath, "Files");
            if (Directory.Exists(fileDestination) == false)
                Directory.CreateDirectory(fileDestination);
            try
            {
                foreach (string tempFilePath in fileList)
                {
                    string tempFileName = Path.GetFileName(tempFilePath);
                    string destFileName = $"{fileDestination}{tempFileName}";
                    if (tempFilePath != destFileName)
                        File.Copy(tempFilePath, destFileName, true);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            bool saveImage1 = false;
            bool saveImage2 = false;

            // Save images if exportConfig is null
            if (exportConfig == null || exportConfig.BothImages)
            {
                saveImage1 = true;
                saveImage2 = true;
            } else if (rvSession.Targeted.ToLower() == "true")
            {
                if (exportConfig.TargetImage)
                {
                    if (rvSession.Image1.IsTarget)
                    {
                        saveImage1 = true;
                        saveImage2 = false;
                    } else if (rvSession.Image2.IsTarget)
                    {
                        saveImage1 = false;
                        saveImage2 = true;
                    }
                } else if (exportConfig.ControlImage)
                {
                    if (rvSession.Image1.IsTarget)
                    {
                        saveImage1 = false;
                        saveImage2 = true;
                    }
                    else if (rvSession.Image2.IsTarget)
                    {
                        saveImage1 = true;
                        saveImage2 = false;
                    }
                }
            }

            //Save the images
            if (rvSession.Image1 != null && rvSession.Image1.ImageBitmap != null && saveImage1 == true)
            {
                //Save Image 1 to file system
                ImageAsset Im1 = rvSession.Image1;
                string imagePath = Path.Combine(destinationFolderPath, 
                    "Image1_", rvSession.UUID.ToString(), ".",
                    imageUtils.GetName(Im1.ImageFileFormat));

                Im1.ImageBitmap.Save(imagePath, Im1.ImageFileFormat);
            }
            if (rvSession.Image2 != null && rvSession.Image2.ImageBitmap != null && saveImage2 == true)
            {
                //Save Image 2 to file system
                ImageAsset Im2 = rvSession.Image2;
                string imagePath = Path.Combine(destinationFolderPath, 
                     "Image2_", rvSession.UUID.ToString(), ".", 
                     imageUtils.GetName(Im2.ImageFileFormat));

                Im2.ImageBitmap.Save(imagePath, Im2.ImageFileFormat);
            }

            //Save export config to file
            if (exportConfig != null)
            {
                JsonSerializerOptions jOpts = new JsonSerializerOptions();
                jOpts.WriteIndented = true;
                string exportJson = JsonSerializer.Serialize<SessionExportConfiguration>(exportConfig, jOpts);
                string exportConfigPath = Path.Combine(destinationFolderPath, 
                    $"ExportConfig_{rvSession.UUID.ToString()}.json");
                File.WriteAllText(exportConfigPath, exportJson);
            }
            return returnString;
        }

        public void SessionPracticeSaveToDatabase(RVSession rvSession, bool overwrite = false)
        {
            sessionDatabase.SessionPracticeSave(rvSession, overwrite);
        }
        
        public string RemoveSpecialCharacters(string str)
        {
            if (str == null) return str; 
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public RVSession SessionPracticeGetFromDirectory(string folderPath)
        {
            string[] filePaths = Directory.GetFiles(folderPath);
            string sessionPath = string.Empty;
            string image1Path = string.Empty;
            string image2Path = string.Empty;
            foreach (string filePath in filePaths)
            {
                if (filePath.EndsWith("_SESSION.json"))
                    sessionPath = filePath;
                if (Path.GetFileName(filePath).StartsWith("Image1"))
                    image1Path = filePath;
                if (Path.GetFileName(filePath).StartsWith("Image2"))
                    image2Path = filePath;
            }

            string sessionJson = string.Empty;
            if (!string.IsNullOrWhiteSpace(sessionPath))
            {
                sessionJson = File.ReadAllText(sessionPath);
            }
                
            if (!string.IsNullOrWhiteSpace(sessionJson))
            {
                RVSession sp = null;
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        Converters ={
                            new JsonStringEnumConverter( JsonNamingPolicy.CamelCase)
                        },
                    };
                    sp = JsonSerializer.Deserialize<RVSession>(sessionJson, options);
                    if (!string.IsNullOrWhiteSpace(image1Path))
                        sp.Image1.ImageBitmap = new Bitmap(image1Path);
                    if (!string.IsNullOrWhiteSpace(image2Path))
                        sp.Image2.ImageBitmap = new Bitmap(image2Path);
                    return sp;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public List<ImageAsset> ImageSetRandomGet(int numberOfImages = 2)
        {
            RandomNumberController randomController = new RandomNumberController(oplConfig);

            List<Guid> uuidsAll = sessionDatabase.ImageUUIDsGetAll();
            if (uuidsAll.Count < numberOfImages)
            {
                //throw new Exception($"Less than {numberOfImages} images in database");
                return new List<ImageAsset>();
            }

            string rngSerialPort = oplConfig.RNGSerialPortName;

            List<Guid> imageRandomUUIDs = new List<Guid>();
            for (int i = 0; i < numberOfImages; i++)
            {
                bool repeat;
                do
                {
                    repeat = false;
                    RandomNumberResult randResult = randomController.GetRandomNumberNormalized();
                    double? randNum = randResult.randomNumber;
                    if (randNum != null)
                    {
                        //Subtracting one at the end in order to account for arrays
                        //starting at zero and we will be using "imageIndex" var
                        //to index arrays
                        int imageIndex = (int)Math.Round((double)randNum * (uuidsAll.Count - 1), 0);
                        //Check to ensure the same index has not already been chosen
                        //if it has then don't re-add it but instead go an extra
                        //cycle to get a different image
                        if (!imageRandomUUIDs.Contains(uuidsAll[imageIndex]))
                        {
                            imageRandomUUIDs.Add(uuidsAll[imageIndex]);
                        }
                        else
                        {
                            repeat = true;
                        }
                    }
                } while (repeat);
            }

            //Get the ImageAsset from the database
            List<ImageAsset> ias = sessionDatabase.ImagesGet(imageRandomUUIDs);
            return ias;
        }
    }
}
