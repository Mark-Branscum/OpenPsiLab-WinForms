using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Controllers
{
    public class ImageUtilities
    {
        public OPLConfiguration oplConfig { get; set; }

        public ImageUtilities(OPLConfiguration oplConfiguration)
        {
            oplConfig = oplConfiguration;
        }

        public string GetImageString(Guid imageGuid)
        {
            string FormetType = string.Empty;
            if (imageGuid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                FormetType = "tiff";
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                FormetType = "gif";
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                FormetType = "jpg";
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                FormetType = "bmp";
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                FormetType = "png";
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                FormetType = "ico";
            else
                throw new System.ArgumentException("Invalid File Type");
            return FormetType;
        }
        public ImageFormat GetImageFormatFromGuid(Guid imageGuid)
        {
            ImageFormat FormetType = null;
            if (imageGuid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                FormetType = ImageFormat.Tiff;
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                FormetType = ImageFormat.Gif;
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                FormetType = ImageFormat.Jpeg;
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                FormetType = ImageFormat.Bmp;
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                FormetType = ImageFormat.Png;
            else if (imageGuid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                FormetType = ImageFormat.Icon;
            else
                throw new System.ArgumentException("Invalid File Type");
            return FormetType;
        }

        public string GetName(ImageFormat format)
        {
            if (format.Guid == ImageFormat.MemoryBmp.Guid)
                return "MemoryBMP";
            if (format.Guid == ImageFormat.Bmp.Guid)
                return "bmp";
            if (format.Guid == ImageFormat.Emf.Guid)
                return "emf";
            if (format.Guid == ImageFormat.Wmf.Guid)
                return "wmf";
            if (format.Guid == ImageFormat.Gif.Guid)
                return "gif";
            if (format.Guid == ImageFormat.Jpeg.Guid)
                return "jpeg";
            if (format.Guid == ImageFormat.Png.Guid)
                return "png";
            if (format.Guid == ImageFormat.Tiff.Guid)
                return "tiff";
            if (format.Guid == ImageFormat.Exif.Guid) 
                return "exif";
            if (format.Guid == ImageFormat.Icon.Guid)
                return "icon";

            throw new Exception("Image format name not found.");
        }

        public void SaveImageToImagesFolder(ImageAsset imageToSave)
        {
            string completePath = oplConfig.ImageFolderFullPath;
            if (Directory.Exists(completePath) == false)
            {
                Directory.CreateDirectory(completePath);
            }
            //string fileExtension = GetName(imageToSave.ImageFileFormat);
            string fileExtension = "jpeg";
            imageToSave.FileName = $"{imageToSave.UUID}.{fileExtension}";
            completePath = Path.Combine(completePath, $"{imageToSave.UUID}.{fileExtension}");
            imageToSave.ImageBitmap.Save(completePath, imageToSave.ImageFileFormat);
        }

        public void SaveImageToDatabase(ImageAsset imageToSave, ADatabase imageDatabase)
        {
            imageDatabase.ImageUpsert(imageToSave);
        }

        public void loadBitmaps(List<ImageAsset> images)
        {
            //Get bitmaps files from disk
            foreach (ImageAsset image in images)
            {
                string path = oplConfig.ImageFolderFullPath; 
                //string fullPath = Path.Combine(path, image.UUID.ToString());
                string[] filePaths = Directory.GetFiles(path, $"{image.UUID}.*");
                if (filePaths.Length == 0)
                {
                    //The image file was not found in the images folder
                    //So we set it to inactive in the database and throw an error
                    ADatabase db = new SQLiteDatabase(oplConfiguration: oplConfig);
                    db.SetImageActive(image.UUID, false);
                    throw new Exception("Image file not found in Images folder");
                }

                string filePathToLoad = Path.Combine(path, 
                    $"{image.UUID.ToString()}{Path.GetExtension(filePaths[0])}");
                    // = $"{path}{image.UUID.ToString()}{Path.GetExtension(filePaths[0])}";
                image.ImageBitmap = new Bitmap(filePathToLoad);
            }
        }
    }
}
