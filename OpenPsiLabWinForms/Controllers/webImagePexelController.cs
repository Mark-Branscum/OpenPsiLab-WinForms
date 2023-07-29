using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using PexelsDotNetSDK.Api;
using PexelsDotNetSDK.Models;

namespace OpenPsiLabWinForms.Controllers
{
    public class webImagePexelController
    {
        public OPLConfiguration oplConfig { get; set; }

        public webImagePexelController(OPLConfiguration oplConfigSource)
        {
            oplConfig = oplConfigSource;
        }

        public async Task<string> getImageDownloadURL(string imageID)
        {
            string userAPI_ID = "";
            var pexelsClient = new PexelsClient(userAPI_ID);
            Photo result = await pexelsClient.GetPhotoAsync(int.Parse(imageID));//.GetAwaiter().GetResult();
            return result.source.original;
        }

        public async Task<Bitmap> DownloadImage(string imageID)
        {
            using (HttpClient client = new HttpClient())
            {
                //string ID = GetImageIDFromInfoURL(imageInfoURL);

                string imageDownloadURL = await getImageDownloadURL(imageID: imageID);

                var response = await client.GetAsync(imageDownloadURL);//.GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();

                var imageBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                //File.WriteAllBytes(savePath, imageBytes);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    Bitmap bitmap = new Bitmap(image);
                    return bitmap;
                }
            }
        }

        public string GetImageIDFromInfoURL(string infoURL)
        {
            string returnID = string.Empty;
            string trimmedURL = infoURL.TrimEnd('/');
            int lastHyphenIndex = trimmedURL.LastIndexOf("-");

            if (lastHyphenIndex >= 0)
            {
                returnID = trimmedURL.Substring(lastHyphenIndex + 1);
                Console.WriteLine(returnID); 
            }

            return returnID;
            
            //string baseUrl = "https://www.pexels.com/photo/";
            //if (!inputUrl.StartsWith(baseUrl))
            //{
            //    throw new ArgumentException("Invalid input URL format.");
            //}

            //string remainingPart = inputUrl.Substring(baseUrl.Length).TrimEnd('/');

            //// Check if remaining part contains '/', 
            //// if yes, get part after '/', else get remaining part as ID
            //string id = remainingPart.Contains('/')
            //    ? remainingPart.Substring(remainingPart.LastIndexOf('/') + 1)
            //    : remainingPart;

            //return $"https://images.pexels.com/photos/{id}/pexels-photo-{id}.jpeg";
        }

    }
    
}

