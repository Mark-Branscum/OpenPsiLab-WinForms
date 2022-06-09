using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class SetImagesForm : Form
    {
        private ADatabase ImageDatabase { get; set; }
        public ImageAsset Image1;
        public ImageAsset Image2;
        private SessionController sessionController;
        private OPLConfiguration oplConfig { get; set; }
        private ImageUtilities imageUtils;

        public SetImagesForm(RVSession rvSession, ADatabase imageDatabase,
            SessionController sessionControl, OPLConfiguration oplConfiguration)
        {
            try
            {
                InitializeComponent();
                oplConfig = oplConfiguration;
                imageUtils = new ImageUtilities(oplConfig);
                sessionController = sessionControl;
                ImageDatabase = imageDatabase;

                if (rvSession.ImagesArray == null || rvSession.Image1 == null 
                    || rvSession.Image2 == null)
                {
                    //rvSession.ImagesArray = new ImageAsset[2];
                    updateImage1DBButton.Enabled = false;
                    updateImage2DBButton.Enabled = false;
                    return;
                }

                updateImage1DBButton.Enabled = true;
                updateImage2DBButton.Enabled = true;
                
                if (rvSession.ImagesArray[0] == null)
                    rvSession.ImagesArray[0] = new ImageAsset();
                Image1 = rvSession.ImagesArray[0];
                if (rvSession.ImagesArray[1] == null)
                    rvSession.ImagesArray[1] = new ImageAsset();
                Image2 = rvSession.ImagesArray[1];

                //Setup Image 1
                nameImage1TextBox.Text = Image1.Name;
                notesImage1TextBox.Text = Image1.Notes;
                uuidImage1textBox.Text = Image1.UUID.ToString();
                image1PictureBox.Image = Image1.ImageBitmap;

                List<ImageAsset> dbImages1 = ImageDatabase.ImagesGet(
                    new List<Guid>() { Image1.UUID });
                if (dbImages1.Count > 0)
                    updateImage1DBButton.Text = "Update in Database";
                else
                    updateImage1DBButton.Text = "Save to Database";

                //Setup Image 2
                nameImage2TextBox.Text = Image2.Name;
                notesImage2TextBox.Text = Image2.Notes;
                uuidImage2textBox.Text = Image2.UUID.ToString();
                image2PictureBox.Image = Image2.ImageBitmap;

                List<ImageAsset> dbImages2 = ImageDatabase.ImagesGet(
                    new List<Guid>() { Image2.UUID });
                if (dbImages2.Count > 0)
                    updateImage2DBButton.Text = "Update in Database";
                else
                    updateImage2DBButton.Text = "Save to Database";

                updateImage1DBButton.BackColor = default(Color);
                updateImage2DBButton.BackColor = default(Color);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void image1PathButton_Click(object sender, EventArgs e)
        {
            //Get file path
            string filePath = getFilePath();
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            dbUpdated1Label.Text = string.Empty;
            pathImage1TextBox.Text = filePath;

            try
            {
                //Get data from DB if available
                int dotIndex = filePath.LastIndexOf(".");
                int startIndex = dotIndex - 36;
                string fileUUID = filePath.Substring(startIndex, 36);

                Guid fileGuid = Guid.Empty;
                if (Guid.TryParse(fileUUID, out fileGuid))
                {
                    List<ImageAsset> dbImages = ImageDatabase.ImagesGet(
                        new List<Guid>() { fileGuid });
                    if (dbImages.Count > 0)
                    {
                        Image1 = dbImages[0];
                        nameImage1TextBox.Text = Image1.Name;
                        notesImage1TextBox.Text = Image1.Notes;
                        uuidImage1textBox.Text = Image1.UUID.ToString();
                        uuidImage1textBox.ReadOnly = true;
                        image1PictureBox.Image = Image.FromFile(filePath);
                        Image1.ImageBitmap = (Bitmap)image1PictureBox.Image;
                        updateImage1DBButton.Enabled = true;
                        updateImage1DBButton.Text = "Update in Database";
                        updateImage1DBButton.BackColor = default(Color);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                //ignore and continue
            }
            //Non database image
            Image1 = new ImageAsset();
            nameImage1TextBox.Text = string.Empty;
            notesImage1TextBox.Text = string.Empty;
            Guid newGuid = Guid.NewGuid();
            uuidImage1textBox.Text = newGuid.ToString();
            Image1.UUID = newGuid;
            uuidImage1textBox.ReadOnly = true;
            image1PictureBox.Image = new Bitmap(filePath);
            Image1.ImageBitmap = new Bitmap(filePath);
            updateImage1DBButton.Enabled = true;
            updateImage1DBButton.Text = "Save to Database";
            updateImage1DBButton.BackColor = oplConfig.HighlightColor;
        }

        private void image2PathButton_Click(object sender, EventArgs e)
        {
            //Get file path
            string filePath = getFilePath();
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            dbUpdated2Label.Text = string.Empty;
            pathImage2TextBox.Text = filePath;

            try
            {
                //Get data from DB if available
                int dotIndex = filePath.LastIndexOf(".");
                int startIndex = dotIndex - 36;
                string fileUUID = filePath.Substring(startIndex, 36);

                Guid fileGuid = Guid.Empty;
                if (Guid.TryParse(fileUUID, out fileGuid))
                {
                    List<ImageAsset> dbImages = ImageDatabase.ImagesGet(
                        new List<Guid>() { fileGuid });
                    if (dbImages.Count > 0)
                    {
                        Image2 = dbImages[0];
                        nameImage2TextBox.Text = Image2.Name;
                        notesImage2TextBox.Text = Image2.Notes;
                        uuidImage2textBox.Text = Image2.UUID.ToString();
                        uuidImage2textBox.ReadOnly = true;

                        image2PictureBox.Image = Image.FromFile(filePath);
                        Image2.ImageBitmap = (Bitmap)image2PictureBox.Image;
                        updateImage2DBButton.Enabled = true;
                        updateImage2DBButton.Text = "Update in Database";
                        updateImage2DBButton.BackColor = default(Color);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                //Ignore and continue
            }
            //Non database image
            Image2 = new ImageAsset();
            nameImage2TextBox.Text = string.Empty;
            notesImage2TextBox.Text = string.Empty;
            Guid newGuid = Guid.NewGuid();
            uuidImage2textBox.Text = newGuid.ToString();
            Image2.UUID = newGuid;
            uuidImage2textBox.ReadOnly = true;
            image2PictureBox.Image = new Bitmap(filePath);
            Image2.ImageBitmap = new Bitmap(filePath);
            updateImage2DBButton.Enabled = true;
            updateImage2DBButton.Text = "Save to Database";
            updateImage2DBButton.BackColor = oplConfig.HighlightColor;
        }

        private string getFilePath()
        {
            string path = string.Empty;
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = oplConfig.AddImagePath;
            dlg.Filter = "All files (*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.FileNames[0];
                oplConfig.AddImagePath = Path.GetDirectoryName(dlg.FileNames[0]);
            }
            return path;
        }

        private void notes1Button_Click(object sender, EventArgs e)
        {
            NotesForm nForm = new NotesForm();
            nForm.notesTextBox.Text = notesImage1TextBox.Text;
            nForm.ShowDialog(this);
            if (nForm.DialogResult == DialogResult.OK)
                notesImage1TextBox.Text = nForm.notesTextBox.Text;
            nForm.Dispose();
        }

        private void notes2Button_Click(object sender, EventArgs e)
        {
            NotesForm nForm = new NotesForm();
            nForm.notesTextBox.Text = notesImage1TextBox.Text;
            nForm.ShowDialog(this);
            if (nForm.DialogResult == DialogResult.OK)
                notesImage2TextBox.Text = nForm.notesTextBox.Text;
            nForm.Dispose();
        }

        private void updateImage1DBButton_Click(object sender, EventArgs e)
        {
            Image1.Name = nameImage1TextBox.Text.Trim();
            Image1.Notes = notesImage1TextBox.Text.Trim();
            Image1.UUID = Guid.Parse(uuidImage1textBox.Text.Trim());
            List<ImageAsset> dbImages1 = ImageDatabase.ImagesGet(
                new List<Guid>() { Image1.UUID });
            if (dbImages1.Count == 0)
                imageUtils.SaveImageToImagesFolder(Image1);
            ImageDatabase.ImageUpsert(Image1);
            dbUpdated1Label.Text = "Database updated";
            updateImage1DBButton.BackColor = default(Color);
        }

        private void updateImage2DBButton_Click(object sender, EventArgs e)
        {
            Image2.Name = nameImage2TextBox.Text.Trim();
            Image2.Notes = notesImage2TextBox.Text.Trim();
            Image2.UUID = Guid.Parse(uuidImage2textBox.Text.Trim());
            List<ImageAsset> dbImages2 = ImageDatabase.ImagesGet(
                new List<Guid>() { Image2.UUID });
            if (dbImages2.Count == 0)
                imageUtils.SaveImageToImagesFolder(Image2);
            ImageDatabase.ImageUpsert(Image2);
            dbUpdated2Label.Text = "Database updated";   
            updateImage2DBButton.BackColor = default(Color);
        }

        private void nameImage1TextBox_TextChanged(object sender, EventArgs e)
        {
            dbUpdated1Label.Text = string.Empty;
            updateImage1DBButton.BackColor = oplConfig.HighlightColor;
        }

        private void notesImage1TextBox_TextChanged(object sender, EventArgs e)
        {
            dbUpdated1Label.Text = string.Empty;
            updateImage1DBButton.BackColor = oplConfig.HighlightColor;
        }

        private void nameImage2TextBox_TextChanged(object sender, EventArgs e)
        {
            dbUpdated2Label.Text = string.Empty;
            updateImage2DBButton.BackColor = oplConfig.HighlightColor;
        }

        private void notesImage2TextBox_TextChanged(object sender, EventArgs e)
        {
            dbUpdated2Label.Text = string.Empty;
            updateImage2DBButton.BackColor = oplConfig.HighlightColor;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Image1 == null || Image2 == null)
            {
                MessageBox.Show("Please select a file for each of the two images to proceed.",
                    "Select Two Files",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Image1.Name = nameImage1TextBox.Text.Trim();
                Image1.Notes = notesImage1TextBox.Text.Trim();
                Image2.Name = nameImage2TextBox.Text.Trim();
                Image2.Notes = notesImage2TextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private void random1button_Click(object sender, EventArgs e)
        {
            List<ImageAsset> ias = sessionController.ImageSetRandomGet(numberOfImages: 1);
            if (ias.Count < 1)
            {
                MessageBox.Show("Before getting a random image you must first add images to the database. " +
                                "To do so go to the menu Tools -> Image Download",
                    "Initialize Image Database", MessageBoxButtons.OK);
                return;
            }

            imageUtils.loadBitmaps(ias);
            ImageAsset im = ias.First();
            Image1 = im;
            image1PictureBox.Image = im.ImageBitmap;
            nameImage1TextBox.Text = im.Name;
            notesImage1TextBox.Text = im.Notes;
            uuidImage1textBox.Text = im.UUID.ToString();

            updateImage1DBButton.Enabled = true;
            updateImage1DBButton.Text = "Update in Database";
            updateImage1DBButton.BackColor = default(Color);
        }

        private void random2button_Click(object sender, EventArgs e)
        {
            List<ImageAsset> ias = sessionController.ImageSetRandomGet(numberOfImages: 1);
            if (ias.Count < 1)
            {
                MessageBox.Show("Before getting a random image you must first add images to the database. " +
                                "To do so go to the menu Tools -> Image Download",
                    "Initialize Image Database", MessageBoxButtons.OK);
                return;
            }

            imageUtils.loadBitmaps(ias);
            ImageAsset im = ias.First();
            Image2 = im;
            image2PictureBox.Image = im.ImageBitmap;
            nameImage2TextBox.Text = im.Name;
            notesImage2TextBox.Text = im.Notes;
            uuidImage2textBox.Text = im.UUID.ToString();

            updateImage2DBButton.Enabled = true;
            updateImage2DBButton.Text = "Update in Database";
            updateImage2DBButton.BackColor = default(Color);
        }
    }
}
