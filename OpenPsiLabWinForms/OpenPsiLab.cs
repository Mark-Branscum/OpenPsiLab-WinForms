using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views.Alerts;
using static System.Net.Mime.MediaTypeNames;
using WinFormApp = System.Windows.Forms.Application;

namespace OpenPsiLabWinForms
{
    internal static class OpenPsiLab
    {
        private static string programVersion = "0.0.002";
        private static string databaseVersion = "0.0.001";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            WinFormApp.EnableVisualStyles();
            WinFormApp.SetCompatibleTextRenderingDefault(false);

            string appDataPath = "";
            string documentsPath = "";
            bool portableApp = false;
            OPLConfiguration oplConfig;
            
            try
            {
                //Check if the user has specified the '-p' or '-portable' command line argument.
                //If so, set the portableApp flag to true and set the appDataPath and documentsPath
                //to the current directory.
                SetPathsAndPortable(args: args, appDataPath: ref appDataPath,
                    documentsPath: ref documentsPath, portableApp: ref portableApp);

                //Create or load the OPLConfiguration object from the OPLConfig.json file.
                oplConfig = CreateOrLoadConfiguration(appDataPath: appDataPath,
                    documentsPath: documentsPath, portableApp: portableApp);

                if (oplConfig.InstallOrUpdateConfigured == false)
                {
                    //Create the appDataPath and documentsPath folder if they don't exist.
                    CreateFolders(oplConfig: oplConfig);

                    //Update database to latest version if necessary.
                    UpdateDatabase(oplConfig: oplConfig);

                    //Record program and database versions in the OPLConfig.json file 
                    //and the database. This is used to determine if the database needs to be updated.
                    UpdateCheckProgramVersion(oplConfig: oplConfig);

                    SetupSpaceWeatherPage(oplConfig: oplConfig);

                    oplConfig.InstallOrUpdateConfigured = true;
                }
                
                //Run the application
                WinFormApp.Run(new MainForm(oplConfig));
            }
            catch (Exception e)
            {
               HandleError(e: e);
            }
        }

        private static void UpdateDatabase(OPLConfiguration oplConfig)
        {
            //This will update the database to the latest version if necessary.
            //This method will be implemented in a future version.
        }

        private static void CreateFolders(OPLConfiguration oplConfig)
        {
            //Create the appDataPath folder and subfolders if they don't exist.
            if (Directory.Exists(oplConfig.AppDataPath) == false)
            {
                Directory.CreateDirectory(oplConfig.AppDataPath);
            }
            string databasePath = Path.Combine(oplConfig.AppDataPath, "Database");
            if (Directory.Exists(databasePath) == false)
            {
                Directory.CreateDirectory(databasePath);
            }
            string resourcesPath = Path.Combine(oplConfig.AppDataPath, "Resources");
            if (Directory.Exists(resourcesPath) == false)
            {
                Directory.CreateDirectory(resourcesPath);
            }

            //Create the documentsPath folder and subfolders if they don't exist.
            if (Directory.Exists(oplConfig.DocumentsPath) == false)
            {
                Directory.CreateDirectory(oplConfig.DocumentsPath);
            }

            //Setup data folders for sessions
            string rvSessionPath = Path.Combine(oplConfig.DocumentsPath, "RVSessions");
            if (Directory.Exists(rvSessionPath) == false)
            {
                Directory.CreateDirectory(rvSessionPath);
            }
            oplConfig.ExportSessionPath = rvSessionPath;

            //Setup data folder for images
            //If no images folder path is in the OPLConfig.json file, create one.
            if (oplConfig.InstallOrUpdateConfigured == false)
            {
                string imagesPath;
                if (string.IsNullOrWhiteSpace(oplConfig.ImageFolderFullPath))
                {
                    //First time install so setup the default image folder path.
                    imagesPath = Path.Combine(oplConfig.DocumentsPath, "Images");
                    oplConfig.ImageFolderFullPath = imagesPath;
                }
                else
                {
                    //Update so use the existing image folder path.
                    imagesPath = oplConfig.ImageFolderFullPath;
                }
                
                if (Directory.Exists(imagesPath) == false)
                {
                    Directory.CreateDirectory(imagesPath);
                    InitializeDefaultImageFiles(oplConfig: oplConfig);
                }
            }
        }

        private static void SetupSpaceWeatherPage(OPLConfiguration oplConfig)
        {
            if (File.Exists(Path.Combine(oplConfig.DocumentsPath, "Resources", "MainPage.html")) == false)
            {
                //If the MainPage.html file exists then return
                //otherwise create a new one from template.
                if (File.Exists(Path.Combine(
                        oplConfig.DocumentsPath, "Resources", "MainPage.html")) == true)
                {
                    return;
                }
                string currDir = Directory.GetCurrentDirectory();
                string sourceFile = Path.Combine(currDir, "Resources", "MainPage.html");
                string destFile = Path.Combine(oplConfig.DocumentsPath, "Resources", "MainPage.html");
                
                string destDir = Path.GetDirectoryName(destFile);
                if (Directory.Exists(destDir) == false)
                {
                    Directory.CreateDirectory(destDir);
                }
                File.Copy(sourceFileName: sourceFile, destFileName: destFile);
            }
        }

        private static void UpdateCheckProgramVersion(OPLConfiguration oplConfig)
        {
            SQLiteDatabase db = new SQLiteDatabase(oplConfiguration: oplConfig);
            db.ProgramVersionSave(programVersion);

            //Todo: Check database version and update database structure if necessary.
            db.DatabaseVersionSave(databaseVersion);

            oplConfig.SoftwareVersion = programVersion;
        }
        
        private static void HandleError(Exception e)
        {
            string message = "Fatal Error Encountered.  If you would like " +
                             "to send the following information to the developers it will " +
                             "help diagnose the issue. Please also include a description " +
                             "of the steps that led up to the error in order to help " +
                             "the developers recreate the error.\r\n\r\n";
            message += e.Message + "\r\n\r\n";
            message += e.StackTrace;
            ErrorForm ef = new ErrorForm(message);
            ef.ShowDialog();
            Environment.Exit(-1);
        }
        
        private static void SetPathsAndPortable(string[] args, 
            ref string appDataPath, ref string documentsPath, ref bool portableApp)
        {
            foreach (string arg in args)
            {
                if (arg.ToLower().Equals("-portable") || arg.ToLower().Equals("-p"))
                {
                    portableApp = true;
                }
            }

            if (portableApp == true)
            {
                //Use portable app paths
                appDataPath = Directory.GetCurrentDirectory();
                documentsPath = Directory.GetCurrentDirectory();
            }
            else if (portableApp == false)
            {
                //Use installed app paths
                appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                appDataPath = Path.Combine(appDataPath, "OpenPsiLab");
                documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                documentsPath = Path.Combine(documentsPath, "OpenPsiLab");
            }
        }
        
        private static OPLConfiguration CreateOrLoadConfiguration(string appDataPath, 
            string documentsPath, bool portableApp)
        {
            OPLConfiguration oplConf = new OPLConfiguration();

            //Create new OPLConfig.json file if it doesn't exist.
            if (File.Exists(Path.Combine(appDataPath, "OPLConfig.json")) == false)
            {
                //Initialize the new config file with default values.
                oplConf.InitializeNewConfig(appDataPath: appDataPath,
                    documentsPath: documentsPath);
            }
            
            //Create configuration object from OPLConfig.json file 
            //for use throughout the program.
            string configJson = File.ReadAllText(Path.Combine(appDataPath, "OPLConfig.json"));
            JsonSerializerOptions opts = new JsonSerializerOptions()
            {
                Converters = {
                        new ColorJsonConverter()
                    }
            };
            oplConf = JsonSerializer.Deserialize<OPLConfiguration>(configJson, opts);

            //if oplConfig.AppDataPath is different than the current appDataPath it means
            //that the user has either added or removed the '-portable' flag from the 
            //command line arguments.  This is currently not supported and will cause
            //the program to exit.
            if (oplConf.AppDataPath.ToLower().Equals(appDataPath.ToLower()) == false)
            {
                if (portableApp == true)
                {
                    MessageBox.Show("OPL was started as a portable app by using the " +
                                    "'-p' or '-portable' command line argument.  However OPL " +
                                    "was originally installed as a normal Windows app.  OPL " +
                                    "does not currently support converting an installed OPL " +
                                    "instance to a portable instance.  Please refer to the GitHub " +
                                    "repository for instructions on how to transfer data between " +
                                    "the two versions or remove the '-p' or '-portable' command " +
                                    "line argument and relaunch OPL.",
                        "Portable App Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    System.Environment.Exit(0);
                }
                else if (portableApp == false)
                {
                    MessageBox.Show("OPL was started like a Windows intalled app by removing the " +
                                    "'-p' or '-portable' command line argument.  However OPL " +
                                    "was originally initialized as a portable app.  OPL " +
                                    "does not currently support converting a portable OPL " +
                                    "instance to an installed instance.  Please refer to the GitHub " +
                                    "repository for instructions on how to transfer data between " +
                                    "the two versions or use the '-portable' command line argument " +
                                    "and relaunch OPL.", "Portable App Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    System.Environment.Exit(0);
                }
            }
            return oplConf;
        }

        private static void InitializeDefaultImageFiles(OPLConfiguration oplConfig)
        {
            //Copy the images from the program folder to the user's Images folder
            if (oplConfig.InstallOrUpdateConfigured == false)
            {
                string imageSourceFolder = Path.Combine(
                    Directory.GetCurrentDirectory(), "Images");
                string[] imageFullPaths = Directory.GetFiles(imageSourceFolder);
                foreach (string imageFullPath in imageFullPaths)
                {
                    string imageFileName = Path.GetFileName(imageFullPath);
                    string imageDestinationPath =
                        Path.Combine(oplConfig.ImageFolderFullPath, imageFileName);
                    File.Copy(imageFullPath, imageDestinationPath);
                }
                oplConfig.InstallOrUpdateConfigured = true;
            }

        }

    }
}
