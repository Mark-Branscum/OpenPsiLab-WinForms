using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

        public UnsplashWebForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
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

            UnsplashController unsplashDownloader = new UnsplashController();
            Bitmap bm = unsplashDownloader.DownloadImage(uia.InfoURL.Trim());
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

    }
}
