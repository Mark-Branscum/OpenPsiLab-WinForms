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
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using WK.Libraries.BetterFolderBrowserNS;

namespace OpenPsiLabWinForms.Views
{
    public partial class SessionFolderSelectForm : Form
    {
        public string FolderPath { get; set; }
        public OPLConfiguration oplConfig { get; set; }
        public SessionFolderSelectForm(OPLConfiguration oplConfiguration)
        {
            this.oplConfig = oplConfiguration;
            InitializeComponent();
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser fBrow = new BetterFolderBrowser();
            fBrow.Title = "Select Folder";
            fBrow.Multiselect = false;
            string dir = oplConfig.LoadSessionPath;
            fBrow.RootFolder = dir;

            if (fBrow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FolderPath = fBrow.SelectedPath;
                    folderNameTextBox.Text = FolderPath;
                    openButton.Enabled = true;
                    oplConfig.LoadSessionPath = fBrow.SelectedPath;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Can't load image {FolderPath}",
                        "Image Load Error", MessageBoxButtons.OK);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(folderNameTextBox.Text))
                DialogResult = DialogResult.Cancel;
            else 
                DialogResult = DialogResult.OK;
        }

        private void folderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FolderPath = folderNameTextBox.Text.Trim();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
