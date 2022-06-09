using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;

namespace OpenPsiLabWinForms
{
    public class ImageAsset  
    {
        public string Name { get; set; }
        public string InfoURL { get; set; }
        public string ImageURL
        {
            get
            {
                if (InfoURL == null) return null;
                if (InfoURL.EndsWith("/"))
                {
                    //Strip off trailing slash
                    int len = InfoURL.Length;
                    InfoURL = InfoURL.Substring(0, InfoURL.Length - 1);
                }
                string imageURL = $"{InfoURL}/download?force=true";
                return imageURL;
            }
            set
            {
                //ignore since this property is derived from the InfoURL
            }
        }
        public Guid UUID { get; set; }
        [JsonIgnore]
        public Bitmap ImageBitmap { get; set; }
        public ImageFormat ImageFileFormat
        {
            get
            {
                if (ImageBitmap != null)
                {
                    return ImageBitmap.RawFormat;
                }
                else
                {
                    return null;
                }
            }
        }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public bool IsViewerSelected { get; set; }
        public bool IsJudgeSelected { get; set; }
        public bool IsTarget { get; set; }
        public ImageFormat ParseImageFormat(string str)
        {
            return (ImageFormat)typeof(ImageFormat)
                .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                .GetValue(null);
        }
        public ImageAsset DeepCopy()
        {
            string json = JsonSerializer.Serialize<ImageAsset>(this);
            ImageAsset newIA = JsonSerializer.Deserialize<ImageAsset>(json);
            if (ImageBitmap != null) 
                newIA.ImageBitmap = (Bitmap)ImageBitmap.Clone();
            return newIA;
        }
    }
}
