using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Interfaces;

namespace OpenPsiLabWinForms.Models
{
    public class SessionPractieJson
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TargetID { get; set; }
        public string Image1FilePath { get; set; }
        public string Image1BitMap { get; set; }
        public string Image1ImageFileFormat { get; set; }
        public string Image1ImageURL { get; set; }
        public string Image1InfoURL { get; set; }
        public string Image1Name { get; set; }
        public string Image1Notes { get; set; }
        public string Image1UUID { get; set; }
        public bool Image1IsViewerSelected { get; set; }
        public bool Image1IsMontoriSelectd { get; set; }
        public bool Image1IsTarget { get; set; }
        public string Image2FilePath { get; set; }
        public string Image2BitMap { get; set; }
        public string Image2ImageFileFormat { get; set; }
        public string Image2ImageURL { get; set; }
        public string Image2InfoURL { get; set; }
        public string Image2Name { get; set; }
        public string Image2Notes { get; set; }
        public string Image2UUID { get; set; }
        public bool Image2IsViewerSelected { get; set; }
        public bool Image2IsMontoriSelectd { get; set; }
        public bool Image2IsTarget { get; set; }
        public string TargetImageUUID { get; set; }
        public string ViewerSelectedImageUUID { get; set; }
        public string JudgeSelectedImageUUID { get; set; }
        public string StartDateTimeLocal { get; set; }
        public string StartDateTimeUTC { get; set; }
        public string StartDateTimeSidereal { get; set; }
        public string EndDateTimeLocal { get; set; }
        public string EndDateTimeUTC { get; set; }
        public string EndDateTimeSidereal { get; set; }
        public string ViewerSelectedDateTimeLocal { get; set; }
        public string ViewerSelectedDateTimeUTC { get; set; }
        public string ViewerSelectedDateTimeSidereal { get; set; }
        public string JudgeSelectedDateTimeLocal { get; set; }
        public string JudgeSelectedDateTimeUTC { get; set; }
        public string JudgeSelectedDateTimeSidereal { get; set; }
        public string TargetedDateTimeLocal { get; set; }
        public string TargetedDateTimeUTC { get; set; }
        public string TargetedDateTimeSidereal { get; set; }
        public int ViewerSelectedIndex { get; set; }
        public int JudgeSelectedIndex { get; set; }
        public double Longitude { get; set; }
        public string SWXOverviewLargeUUID { get; set; }
        public string NotificationsInEffectTimelineUUID { get; set; }
        public string ScreenshotUUID { get; set; }
        public string ViewerSelectedTarget { get; set; }
        public string JudgeSelectedTarget { get; set; }
        public int TargetIndex { get; set; }
        private ImageUtilities imageUtils;
        private OPLConfiguration oplConfig;

        public SessionPractieJson(RVSession sp, OPLConfiguration oplConfiguration)
        {
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);

            UUID = sp.UUID;
            Name = sp.Name;
            Notes = sp.Notes;

            TargetID = sp.TargetID;
            Image1FilePath = sp.Image1.FileName;
            Image1BitMap = convertBitmapToString(sp.Image1);
            Image1ImageFileFormat = imageUtils.GetName(sp.Image1.ImageFileFormat);
            Image1ImageURL = sp.Image1.ImageURL;
            Image1InfoURL = sp.Image1.InfoURL;
            Image1Name = sp.Image1.Name;
            Image1Notes = sp.Image1.Notes;
            Image1UUID = sp.Image1.UUID.ToString();
            Image1IsViewerSelected = sp.Image1.IsViewerSelected;
            Image1IsMontoriSelectd = sp.Image1.IsJudgeSelected;
            Image1IsTarget = sp.Image1.IsTarget;

            TargetID = sp.TargetID;
            Image2FilePath = sp.Image2.FileName;
            Image2BitMap = convertBitmapToString(sp.Image2);
            Image2ImageFileFormat = imageUtils.GetName(sp.Image2.ImageFileFormat);
            Image2ImageURL = sp.Image2.ImageURL;
            Image2InfoURL = sp.Image2.InfoURL;
            Image2Name = sp.Image2.Name;
            Image2Notes = sp.Image2.Notes;
            Image2UUID = sp.Image2.UUID.ToString();
            Image2IsViewerSelected = sp.Image2.IsViewerSelected;
            Image2IsMontoriSelectd = sp.Image2.IsJudgeSelected;
            Image2IsTarget = sp.Image2.IsTarget;
            TargetImageUUID = sp.TargetImageUUID.ToString();
            ViewerSelectedImageUUID = sp.ViewerSelectedImageUUID.ToString();
            JudgeSelectedImageUUID = sp.JudgeSelectedImageUUID.ToString();
            StartDateTimeLocal = sp.StartDateTimeLocal.ToString();
            StartDateTimeUTC = sp.StartDateTimeUTC.ToString();
            EndDateTimeSidereal = sp.EndDateTimeSidereal.ToLongTimeString();
            EndDateTimeLocal = sp.EndDateTimeLocal.ToString();
            EndDateTimeUTC = sp.EndDateTimeUTC.ToString();
            EndDateTimeSidereal = sp.EndDateTimeSidereal.ToLongTimeString();
            ViewerSelectedDateTimeLocal = sp.ViewerSelectedDateTimeLocal.ToString();
            ViewerSelectedDateTimeUTC = sp.ViewerSelectedDateTimeUTC.ToString();
            ViewerSelectedDateTimeSidereal = sp.ViewerSelectedDateTimeSidereal.ToString();
            JudgeSelectedDateTimeLocal = sp.JudgeSelectedDateTimeLocal.ToString();
            JudgeSelectedDateTimeUTC = sp.JudgeSelectedDateTimeUTC.ToString();
            JudgeSelectedDateTimeSidereal = sp.JudgeSelectedDateTimeSidereal.ToString();
            TargetedDateTimeLocal = sp.TargetedDateTimeLocal.ToString();
            TargetedDateTimeUTC = sp.TargetedDateTimeUTC.ToString();
            TargetedDateTimeSidereal = sp.TargetedDateTimeSidereal.ToString();
            ViewerSelectedIndex = sp.ViewerSelectedIndex;
            JudgeSelectedIndex = sp.JudgeSelectedIndex;
            Longitude = sp.Longitude;
            SWXOverviewLargeUUID = sp.SWXOverviewLargeUUID;
            NotificationsInEffectTimelineUUID = 
                sp.NotificationsInEffectTimelineUUID;
            ScreenshotUUID = sp.ScreenshotUUID.ToString();
            ViewerSelectedTarget = sp.ViewerSelectedTarget;
            JudgeSelectedTarget = sp.JudgeSelectedTarget;
            TargetIndex = sp.TargetIndex;

        }

        private string convertBitmapToString(ImageAsset ia)
        {
            MemoryStream ms = new MemoryStream();
            ia.ImageBitmap.Save(ms, ia.ImageFileFormat); 
            byte[] byteImage = ms.ToArray();
            return Convert.ToBase64String(byteImage); 
        }

        public string ToJSON()
        {
            JsonSerializerOptions opts = new JsonSerializerOptions();
            opts.WriteIndented = true;
            return JsonSerializer.Serialize(this, opts);
        }

    }
}
