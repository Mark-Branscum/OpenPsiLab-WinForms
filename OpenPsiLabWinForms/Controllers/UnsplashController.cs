using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Controllers
{
    public class UnsplashController
    {
        public Bitmap DownloadImage(string infoURL)
        {
            int retryCount = 0;
            int maxRetries = 3;

            while (retryCount < maxRetries)
            {
                try
                {
                    retryCount++;
                    using (WebClient client = new WebClient())
                    {
                        using (Stream stream = client.OpenRead(ConvertInfoURLToImageURL(infoURL)))
                        {
                            return new Bitmap(stream);
                        }
                    }
                }
                catch (Exception)
                {
                    //Sometimes Unsplash will randomly time out
                    //so we retry it a coupld of times
                    Thread.Sleep(3000);
                }
            }
            return null;
        }

        private string ConvertInfoURLToImageURL(string infoURL)
        {
            if (infoURL.EndsWith("/"))
            {
                int len = infoURL.Length;
                infoURL = infoURL.Substring(0, infoURL.Length - 1);
            }
            string imageID = infoURL.Substring(infoURL.LastIndexOf("/") + 1);
            string imageURL = $"https://unsplash.com/photos/{imageID}/download?force=true";
            return imageURL;
        }
    }
}
