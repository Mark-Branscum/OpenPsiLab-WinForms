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
    public partial class UnsplashWebForm : Form
    {
        private ImageUtilities imageUtils;
        private OPLConfiguration oplConfig;
        private string webviewHTML = "";

        public UnsplashWebForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);

            //unsplashWebView2.Invoke(new Action(() =>
            //{
            //    Task.Run(async () => await unsplashWebView2.EnsureCoreWebView2Async()).GetAwaiter().GetResult();
            //}));

            //Task.Run(async () => await unsplashWebView2.EnsureCoreWebView2Async()).GetAwaiter().GetResult();

            //unsplashWebView2.CoreWebView2.NavigationCompleted += handleNavigation;


            //unsplashWebView2.CoreWebView2.NavigationCompleted += (sender, args) =>
            //{

            //};

            

        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            //{
            //    MessageBox.Show("Navigate to image first before saving.", "Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return;
            //}
            saveButton.Enabled = false;
            ImageAsset uia = new ImageAsset();
            uia.Name = nameTextBox.Text.Trim();
            uia.Notes = notesTextBox.Text.Trim();
            uia.InfoURL = urlTextBox.Text.Trim();
            uia.UUID = Guid.NewGuid();

            //string jsonEncodedHtml =  unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML").Result;
            //string jsonEncodedHtml = await unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");

            //string jsonEncodedHtml = unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML").Result;
            
            
            //string jsonEncodedHtml = unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML")
            //    .ConfigureAwait(false).GetAwaiter().GetResult();
            //string html = System.Text.Json.JsonSerializer.Deserialize<string>(jsonEncodedHtml);

            string precedingString = "title=\\\"Download photo\\\" href=\\\"";
            string followingString = @"&amp;";

            string tempURL = this.urlTextBox.Text.Trim();
            string tempID = ExtractAfterLastHyphen(tempURL);

            //string thing =
            //    "title=\"Download photo\" href=\"https://unsplash.com/photos/zmj0Y5Ox2_8/download?ixid=M3wxMjA3fDB8MXxhbGx8fHx8fHx8fHwxNjkwMjQ3MjQ5fA&amp;force=true\"><span class=\"TaWJf\">Download</span>";
            //this.webviewHTML = thing;

            UnsplashController unsplashDownloader = new UnsplashController();
            Bitmap bm = unsplashDownloader.DownloadImage(
                html: this.webviewHTML, precedingString: precedingString, 
                middleString: tempID, followingString: followingString);
            if (bm != null) uia.ImageBitmap = bm;
            else
            {
                MessageBox.Show("Unable to download Unsplash image.  Please try again.",
                    "Error", MessageBoxButtons.OK);
                unsplashWebView2.GoBack();
                return;
            }
                

            //Save image to disk
            imageUtils.SaveImageToImagesFolder(uia);

            //Save image to database
            SQLiteDatabase db = new SQLiteDatabase(oplConfig);
            db.ImageUpsert(uia);

            nameTextBox.Text = "";
            notesTextBox.Text = "";
            unsplashWebView2.GoBack();
        }

        private void unsplashWebView2_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            string url = unsplashWebView2.Source.ToString();
            if (url.StartsWith("https://unsplash.com/photos/"))
            {
                saveButton.Enabled = true;
                urlTextBox.Text = url;
                nameTextBox.Text = "";
                notesTextBox.Text = "";

            } else
            {
                saveButton.Enabled = false;
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
                var thing = unsplashWebView2.EnsureCoreWebView2Async();

                string html = await unsplashWebView2.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");

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
