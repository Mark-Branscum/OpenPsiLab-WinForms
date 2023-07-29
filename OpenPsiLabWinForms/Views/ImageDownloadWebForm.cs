using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Models;

namespace OpenPsiLabWinForms.Views
{
    public partial class ImageDownloadWebForm : Form
    {
        private ImageUtilities imageUtils;
        private OPLConfiguration oplConfig;
        private string webviewHTML = "";

        public ImageDownloadWebForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
            ImageDownloadWebView2.EnsureCoreWebView2Async();
            ImageDownloadWebView2.Source = new Uri($"https://www.pexels.com?nocache={DateTime.Now.Ticks}");
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            ImageAsset uia = new ImageAsset();
            uia.Name = nameTextBox.Text.Trim();
            uia.Notes = notesTextBox.Text.Trim();
            uia.InfoURL = urlTextBox.Text.Trim();
            uia.UUID = Guid.NewGuid();

            webImagePexelController webImageDownloader = new webImagePexelController(this.oplConfig);

            string imageID = webImageDownloader.GetImageIDFromInfoURL(uia.InfoURL);

            Bitmap bm = await webImageDownloader.DownloadImage(imageID: imageID);
            
            if (bm != null) uia.ImageBitmap = bm;
            else
            {
                MessageBox.Show("Unable to download Unsplash image.  Please try again.",
                    "Error", MessageBoxButtons.OK);
                ImageDownloadWebView2.GoBack();
                return;
            }

            //Save image to disk
            imageUtils.SaveImageToImagesFolder(uia);

            //Save image to database
            SQLiteDatabase db = new SQLiteDatabase(oplConfig);
            db.ImageUpsert(uia);

            nameTextBox.Text = "";
            notesTextBox.Text = "";
            ImageDownloadWebView2.GoBack();

        }

        private void unsplashSaveButton_Click(object sender, EventArgs e)
        {
            ////if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            ////{
            ////    MessageBox.Show("Navigate to image first before saving.", "Error", MessageBoxButtons.OK,
            ////        MessageBoxIcon.Error);
            ////    return;
            ////}
            //saveButton.Enabled = false;
            //ImageAsset uia = new ImageAsset();
            //uia.Name = nameTextBox.Text.Trim();
            //uia.Notes = notesTextBox.Text.Trim();
            //uia.InfoURL = urlTextBox.Text.Trim();
            //uia.UUID = Guid.NewGuid();

            //webImagePexelController unsplashDownloader = new webImagePexelController();
            ////Bitmap bm = unsplashDownloader.DownloadImage(
            ////    imageInfoURL: uia.InfoURL, savePath: oplConfig.ImageFolderFullPath);
            
            //if (bm != null) uia.ImageBitmap = bm;
            //else
            //{
            //    MessageBox.Show("Unable to download Unsplash image.  Please try again.",
            //        "Error", MessageBoxButtons.OK);
            //    ImageDownloadWebView2.GoBack();
            //    return;
            //}

            ////Save image to disk
            //imageUtils.SaveImageToImagesFolder(uia);

            ////Save image to database
            //SQLiteDatabase db = new SQLiteDatabase(oplConfig);
            //db.ImageUpsert(uia);

            //nameTextBox.Text = "";
            //notesTextBox.Text = "";
            //ImageDownloadWebView2.GoBack();
        }

        private void unsplashWebView2_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            string url = ImageDownloadWebView2.Source.ToString();
            if (url.StartsWith("https://www.pexels.com/photo"))
            {
                webImageSavePanel.Visible = true;
                saveButton.Enabled = true;
                urlTextBox.Text = url;
                nameTextBox.Text = "";
                notesTextBox.Text = "";

            } else
            {
                webImageSavePanel.Visible = false;
                urlTextBox.Text = string.Empty;
                saveButton.Enabled = false;
                nameTextBox.Text = "";
                notesTextBox.Text = "";
            }
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            NotesForm nForm = new NotesForm();
            nForm.notesTextBox.Text = notesTextBox.Text;
            nForm.ShowDialog(this);
            if (nForm.DialogResult == DialogResult.OK)
            {
                notesTextBox.Text = nForm.notesTextBox.Text;
            }
            nForm.Dispose();
        }

        private async void unsplashWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Console.WriteLine("Nav Competed <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            try
            {
                var thing = ImageDownloadWebView2.EnsureCoreWebView2Async();

                string html = await ImageDownloadWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");

                if (!String.IsNullOrWhiteSpace(html))
                {
                    webviewHTML = html;
                }
                
                //unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML")
                //    .ContinueWith(scriptTask =>
                //    {
                //        string jsonEncodedHtml = scriptTask.Result;
                //        string html = System.Text.Json.JsonSerializer.Deserialize<string>(jsonEncodedHtml);
                //        webviewHTML = html;
                //        UnsplashController.GetHtmlAndFindStringAsync(html);
                //        // Do something with HTML...
                //        //Console.WriteLine(html);
                //    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static string ExtractAfterLastHyphen(string input)
        {
            int lastHyphenIndex = input.LastIndexOf('-');

            // If there are no hyphens in the string, return the original string.
            if (lastHyphenIndex == -1)
            {
                return input;
            }

            // Add 1 to the index to start from the character after the hyphen.
            string result = input.Substring(lastHyphenIndex + 1);
            return result;
        }

    }
}
