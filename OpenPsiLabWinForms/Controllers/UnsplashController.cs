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
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Controllers
{
    public class UnsplashController
    {
        public Bitmap DownloadImage(string html, string precedingString, 
            string middleString, string followingString)
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
                        //string imageURL = ConvertInfoURLToImageURL(infoURL);

                        //string imageURL = GetImageURLFromHTML(html: html, precedingString: precedingString,
                        //    followingString: followingString);
                        
                        string imageURL = 
                            ExtractSubstring(html: html, start: precedingString, 
                                middle: middleString, end: followingString);

                        if (string.IsNullOrWhiteSpace(imageURL))
                        {
                            return null;
                        }

                        DownloadImage(imageUrl: imageURL, savePath: "C:temp\\test.jpg");

                        using (Stream stream = client.OpenRead(imageURL))
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

        static void DownloadImage(string imageUrl, string savePath)
        {
            var client = new HttpClient();
            try
            {
                var response = client.GetAsync(imageUrl).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();

                var imageBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                File.WriteAllBytes(savePath, imageBytes);
            }
            finally
            {
                client.Dispose();
            }
        }

        private string ConvertInfoURLToImageURL(string infoURL)
        {
            string url = infoURL;
            string precedingString = "title=\"Download photo\" href=\"";
            string followingString = "\"><span class=\"TaWJf\">";
            string result = GetHtmlAndFindStringAsync(url, precedingString, followingString).Result;
            result.Replace("amp;", "");

            //if (infoURL.EndsWith("/"))
            //{
            //    int len = infoURL.Length;
            //    infoURL = infoURL.Substring(0, infoURL.Length - 1);
            //}

            //string imageID = infoURL.Substring(infoURL.LastIndexOf("/") + 1);
            //string imageURL = $"https://unsplash.com/photos/{imageID}/download?force=true";
            //return imageURL;

            return result;
        }

        public static async Task<string> GetHtmlAndFindStringAsync
            (string url, string precedingString, string followingString)
        {
            using (HttpClient client = new HttpClient())
            {

                string html = await client.GetStringAsync(url);

                string pattern = $"{Regex.Escape(precedingString)}(.*?){Regex.Escape(followingString)}";
                Match match = Regex.Match(html, pattern, RegexOptions.Singleline);

                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
                else
                {
                    return "No match found";
                }
            }

        }

        public static string GetImageURLFromHTML(string html, 
            string precedingString, string middleString, string followingString)
        {
            string pattern = $"{Regex.Escape(precedingString)}(.*?){Regex.Escape(followingString)}";
            Match match = Regex.Match(html, pattern, RegexOptions.Singleline);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                //todo: THIS CREATES AN ERROR THAT IS NOT HANDLED
                return "No match found";
            }
        }

        //static string ExtractSubstring(string html, string start, string middle, string end)
        //{
        //    // Escape the start, middle, and end strings in case they contain special regex characters.
        //    //string escapedStart = Regex.Escape(start);
        //    string escapedStart = start;
        //    string escapedMiddle = Regex.Escape(middle);
        //    //string escapedEnd = Regex.Escape(end);
        //    string escapedEnd = end;

        //    // The pattern that matches "start", followed by anything, then "middle", followed by anything, then "end".
        //    // We capture the part in between start-middle and middle-end
        //    //string pattern = $"{escapedStart}(.*?){escapedMiddle}(.*?){escapedEnd}";
        //    string pattern = $"{escapedStart}(.*{escapedMiddle}.*){escapedEnd}";

        //    var match = Regex.Match(html, pattern);

        //    // If a match is found, return it. Otherwise, return null.
        //    // We return group 1 (as group 0 is always the full match)
        //    return match.Success ? match.Groups[1].Value : null;
        //}

        static string ExtractSubstring(string html, string start, 
            string middle, string end)
        {
            string betweenStartAndEnd = string.Empty;
            int startIndex = 0;
            do
            {
                startIndex = html.IndexOf(start, startIndex);
                if (startIndex == -1)
                    return null; // start substring not found

                startIndex += start.Length;
                int endIndex = html.IndexOf(end, startIndex);
                if (endIndex == -1)
                    return null; // end substring not found

                betweenStartAndEnd = html.Substring(startIndex, endIndex - startIndex);

                // Check if the middle string is in the substring between start and end
                if (betweenStartAndEnd.ToLower().Contains(middle.ToLower()))
                {
                    return betweenStartAndEnd;
                }
            } while (true);

        }
    }


}

