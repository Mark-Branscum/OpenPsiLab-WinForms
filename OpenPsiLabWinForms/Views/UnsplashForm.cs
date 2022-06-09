using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;

namespace OpenPsiLabWinForms
{
    public partial class UnsplashForm : Form
    {
        private ImageAsset _image;
        private OPLConfiguration oplConfig;
        private ImageUtilities imageUtils;

        public UnsplashForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_image != null)
            {
                _image.Name = NameTextbox.Text.Trim();
                _image.Notes = notesTextBox.Text.Trim();
                _image.UUID = Guid.NewGuid();

                //Save image to disk
                imageUtils.SaveImageToImagesFolder(_image);

                //Save image to database
                SQLiteDatabase db = new SQLiteDatabase(oplConfig);
                db.ImageUpsert(_image);

                saveButton.Enabled = false;
                unsplashURLTextbox.Text = "";
                NameTextbox.Text = "";
                notesTextBox.Text = "";
                unsplashPicBox.Image = null;
            }
        }

        private void unsplashURLTextbox_Leave(object sender, EventArgs e)
        {
            UpdateImageBox();
        }

        private void UpdateImageBox(bool suppressErrors = false)
        {
            if (_image == null) _image = new ImageAsset();

            if (!string.IsNullOrWhiteSpace(unsplashURLTextbox.Text)
                && unsplashURLTextbox.Text.Trim().ToLower() !=
                _image.InfoURL)
            {
                _image.InfoURL = unsplashURLTextbox.Text.Trim();

                UnsplashController unsplashDownloader = new UnsplashController();
                Bitmap bm = unsplashDownloader.DownloadImage(unsplashURLTextbox.Text.Trim());
                if (bm != null)
                {
                    _image.ImageBitmap = bm;
                    unsplashPicBox.Image = _image.ImageBitmap;
                    unsplashPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                    saveButton.Enabled = true;
                }
                else
                {
                    if (suppressErrors) return;
                    MessageBox.Show("Unable to download Unsplash image.  Please try again.",
                        "Error", MessageBoxButtons.OK);
                    unsplashURLTextbox.Text = string.Empty;
                    _image.ImageBitmap = null;
                    unsplashPicBox.Image = null;
                    saveButton.Enabled = false;
                }
            }
        }

        private void unsplashURLTextbox_TextChanged(object sender, EventArgs e)
        {
            //A complete unsplash url will be exactly 39 characters
            if (unsplashURLTextbox.Text.Length != 39) return;
            UpdateImageBox();
        }
    }
}
