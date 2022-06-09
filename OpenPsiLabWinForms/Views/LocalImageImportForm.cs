using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Views
{
    public partial class LocalImageImportForm : Form
    {
        private ImageAsset _image;
        private ImageUtilities imageUtils;
        private OPLConfiguration oplConfig;

        public LocalImageImportForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fileNameTextBox.Text))
            {
                return;
            }
            _image.UUID = Guid.NewGuid();
            _image.Name = nameTextbox.Text.Trim();
            _image.Notes = notesTextBox.Text.Trim();

            //Save to file system
            imageUtils.SaveImageToImagesFolder(_image);

            //Save image to database
            imageUtils.SaveImageToDatabase(_image, new SQLiteDatabase(oplConfig));

            fileNameTextBox.Text = "";
            nameTextbox.Text = "";
            notesTextBox.Text = "";
            imagePictureBox.Image = null;

            saveButton.Enabled = false;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = addOpenFileDialog;
            string dir = Directory.GetCurrentDirectory();
            
            dlg.Title = "Image Files";
            string savedPath = oplConfig.AddImagePath;
            if (string.IsNullOrWhiteSpace(savedPath)
                || !Directory.Exists(savedPath))
            {
                dlg.InitialDirectory = dir;
                oplConfig.AddImagePath = dir;
            }
            else
            {
                dlg.InitialDirectory = oplConfig.AddImagePath;
            }
            dlg.DefaultExt = ".png";
            dlg.Filter = "All files (*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;
            string fileName = string.Empty;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = dlg.FileName;
                    _image = new ImageAsset();
                    string fileDirectory = Path.GetDirectoryName(fileName);
                    oplConfig.AddImagePath = fileDirectory;
                    _image.ImageBitmap = new Bitmap(fileName);
                    imagePictureBox.Image = _image.ImageBitmap;
                    imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    fileNameTextBox.Text = fileName;
                    saveButton.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Can't load image {fileName}",
                        "Image Load Error", MessageBoxButtons.OK);
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _image = null;
            fileNameTextBox.Text = string.Empty;
            nameTextbox.Text = string.Empty;
            notesTextBox.Text = string.Empty;
            imagePictureBox.Image = null;
            saveButton.Enabled = false;
        }
    }
}
