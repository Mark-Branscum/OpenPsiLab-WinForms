using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using WK.Libraries.BetterFolderBrowserNS;

namespace OpenPsiLabWinForms.Views
{
    public partial class SessionExportForm : Form
    {
        public string FolderPath { get; set; }
        public SessionExportConfiguration exportConfig { get; set; }
        private RVSession RVSessionSource;
        public RVSession RvSessionExport;
        private List<string> sourceAddFileList;
        public List<string> addFilesList { get; set; }
        private bool _addFileListFirstLoad = true;
        private OPLConfiguration oplConfig { get; set; }
        
        public SessionExportForm(List<string> filesList, 
            RVSession rvSessionSource, OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            RVSessionSource = rvSessionSource;
            sourceAddFileList = filesList;
            addFilesList = new List<string>();
            oplConfig = oplConfiguration;
            setupExportConfig();
            folderNameTextBox.Text = oplConfiguration.ExportSessionPath;
        }

        private void  setupExportConfig()
        {
            try
            {
                SessionExportConfiguration ep = oplConfig.SessionExportConfig;
                if (ep == null)
                {
                    setToDefaults();
                    exportConfig = new SessionExportConfiguration();
                    ep = exportConfig;
                    setExportConfigToUI();
                }

                targetIDCheckBox.Checked = ep.TargetIdentifier;
                allImagesRadioButton.Checked = ep.BothImages;
                noImagesRadioButton.Checked = ep.NeitherImage;
                controlImageRadioButton.Checked = ep.ControlImage;
                targetImageRadioButton.Checked = ep.TargetImage;
                sessionNameCheckBox.Checked = ep.SessionName;
                viewerNameCheckBox.Checked = ep.ViewerName;
                judgeNameCheckBox.Checked = ep.JudgeName;
                viewerSelectedCheckBox.Checked = ep.ViewerSelected;
                judgeSelectedCheckBox.Checked = ep.JudgeSelected;
                targetSelectedCheckBox.Checked = ep.TargetSelected;
                screenshotCheckBox.Checked = ep.Screenshot;
                notesCheckBox.Checked = ep.Notes;
                geomagneticCheckBox.Checked = ep.GeomagneticWeather;
                if (ep.Files)
                {
                    filesCheckBox.Checked = ep.Files;
                    addFilesList.Clear();
                    filesButton.Enabled = true;
                    foreach (string sourceFile in sourceAddFileList)
                    {
                        addFilesList.Add(sourceFile);
                        _addFileListFirstLoad = false;
                    }
                }
                else
                {
                    addFilesList.Clear();
                    filesButton.Enabled = false;
                }

                exportConfig = ep;

                if (RVSessionSource.Targeted.ToLower() == "false")
                    targetSelectedCheckBox.Enabled = false;

                if (RVSessionSource.SessionType != SessionForm.SessionType.Associative)
                    arvCheckBox.Enabled = false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser fBrow = new BetterFolderBrowser();
            fBrow.Title = "Select Folder";
            fBrow.Multiselect = false;
            string dir = oplConfig.ExportSessionPath;
            fBrow.RootFolder = dir;

            if (fBrow.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FolderPath = fBrow.SelectedFolder;
                    folderNameTextBox.Text = FolderPath;
                    exportButton.Enabled = true;
                    oplConfig.ExportSessionPath = fBrow.SelectedFolder;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Can't load image {FolderPath}",
                        "Image Load Error", MessageBoxButtons.OK);
                }
            }
        }

        private void folderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FolderPath = folderNameTextBox.Text.Trim();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            setExportConfigToUI();

            if (string.IsNullOrWhiteSpace(FolderPath) || !Directory.Exists(FolderPath))
            {
                MessageBox.Show("Please select a destination path first.", "Destination Path Needed",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (!filesCheckBox.Checked)
                addFilesList.Clear();
            RvSessionExport = cloneSession(RVSessionSource, exportConfig);
            DialogResult = DialogResult.OK;
        }

        private void setExportConfigToUI()
        {
            exportConfig.TargetIdentifier = targetIDCheckBox.Checked;
            exportConfig.BothImages = allImagesRadioButton.Checked;
            exportConfig.NeitherImage = noImagesRadioButton.Checked;
            exportConfig.ControlImage = controlImageRadioButton.Checked;
            exportConfig.TargetImage = targetImageRadioButton.Checked;
            exportConfig.SessionName = sessionNameCheckBox.Checked;
            exportConfig.ViewerName = viewerNameCheckBox.Checked;
            exportConfig.JudgeName = judgeNameCheckBox.Checked;
            exportConfig.ViewerSelected = viewerSelectedCheckBox.Checked;
            exportConfig.JudgeSelected = judgeSelectedCheckBox.Checked;
            exportConfig.TargetSelected = targetSelectedCheckBox.Checked;
            exportConfig.Screenshot = screenshotCheckBox.Checked;
            exportConfig.Notes = notesCheckBox.Checked;
            exportConfig.GeomagneticWeather = geomagneticCheckBox.Checked;
            exportConfig.ARV = arvCheckBox.Checked;
            JsonSerializerOptions jsonOpts = new JsonSerializerOptions();
            jsonOpts.WriteIndented = true;
            oplConfig.SessionExportConfig = exportConfig;
            Settings.Default.Save();
        }

        private RVSession cloneSession(RVSession rvSessionSource, SessionExportConfiguration exportConfig)
        {
            RVSession sourceSP = rvSessionSource;
            if (sourceSP.Image1 == null) sourceSP.Image1 = new ImageAsset();
            if (sourceSP.Image2 == null) sourceSP.Image2 = new ImageAsset();


            RVSession newSP;
            try
            {
                //This converter will ensure the session type is saved
                //as a string and not an int
                JsonSerializerOptions opts = new JsonSerializerOptions
                {
                    Converters ={
                        new JsonStringEnumConverter()
                    }
                };
                opts.WriteIndented = true;
                string jsonSP = JsonSerializer.Serialize<RVSession>(sourceSP, opts);
                newSP = JsonSerializer.Deserialize<RVSession>(jsonSP, opts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            //Apply export restrictions
            SessionExportConfiguration ec = exportConfig;

            if (exportConfig.TargetIdentifier == false)
                newSP.TargetID = string.Empty;

            //Setup images
            if (ec.NeitherImage == true) 
            {
                newSP.Image1 = new ImageAsset();
                newSP.Image2 = new ImageAsset();
            } else if (ec.BothImages == true)
            {
                newSP.Image1 = sourceSP.Image1.DeepCopy();
                newSP.Image2 = sourceSP.Image2.DeepCopy();
            } else if (ec.ControlImage == true)
            {
                if (newSP.Image1.IsTarget == true)
                    newSP.Image1 = new ImageAsset();
                if (newSP.Image2.IsTarget == true)
                    newSP.Image2 = new ImageAsset();
            }else if (ec.TargetImage == true)
            {
                if (newSP.Image1.IsTarget != true)
                    newSP.Image1 = new ImageAsset();
                if (newSP.Image2.IsTarget != true)
                    newSP.Image2 = new ImageAsset();
            }

            if (ec.SessionName == false)
                newSP.Name = string.Empty;

            if (ec.ViewerName == false)
                newSP.ViewerName = string.Empty;

            if (ec.JudgeName == false)
                newSP.JudgeName = string.Empty;

            if (ec.ViewerSelected == false)
            {
                newSP.ViewerSelectedIndex = -1;
                newSP.ViewerSelectedTarget = string.Empty;
            }
            
            if (ec.JudgeSelected == false)
            {
                newSP.JudgeSelectedIndex = -1;
                newSP.JudgeSelectedTarget = string.Empty;
            }

            if (ec.TargetSelected == false)
                newSP.TargetIndex = -1;

            if (ec.Notes == false)
                newSP.Notes = string.Empty;

            if (ec.ARV == false)
            {
                newSP.ARVQuestion = string.Empty;
                newSP.ARVAnswer1 = string.Empty;
                newSP.ARVAnswer2 = string.Empty;
            }
            
            return newSP;
        }

        private void setToDefaultsButton_Click(object sender, EventArgs e)
        {
            setToDefaults();
        }

        private void setToDefaults()
        {
            targetIDCheckBox.Checked = true;
            noImagesRadioButton.Checked = true;
            sessionNameCheckBox.Checked = true;
            viewerNameCheckBox.Checked = true;
            judgeNameCheckBox.Checked = true;
            viewerSelectedCheckBox.Checked = false;
            judgeSelectedCheckBox.Checked = false;
            targetSelectedCheckBox.Checked = false;
            screenshotCheckBox.Checked = false;
            notesCheckBox.Checked = false;
            arvCheckBox.Checked = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void testButton_Click(object sender, EventArgs e)
        {
            RVSession newSP = cloneSession(RVSessionSource, exportConfig);
        }

        private void filesButton_Click(object sender, EventArgs e)
        {
            AddFilesForm filesForm = new AddFilesForm(addFilesList, oplConfig);

            DialogResult dlgResult = filesForm.ShowDialog(this);

            if (dlgResult == DialogResult.OK)
            {
                if (filesForm.fileDataGridView.Rows.Count > 0)
                {
                    addFilesList.Clear();
                    foreach (DataGridViewRow row in filesForm.fileDataGridView.Rows)
                    {
                        addFilesList.Add(row.Cells[1].Value.ToString());
                    }

                    filesButton.BackColor = oplConfig.HighlightColor;
                }
                else
                {
                    addFilesList.Clear();
                    filesButton.BackColor = default(Color);
                    return;
                }


                //    //addFilesList.Clear();
                //    //sourceAddFileList.Clear();

                //    addFilesList.Clear();
                //    foreach (DataGridViewRow row in filesForm.fileDataGridView.Rows)
                //    {
                //        addFilesList.Add(row.Cells[1].Value.ToString());
                //    }

                //    //sourceAddFileList = addFilesList;
                //}
                //if (addFilesList.Count > 0)
                //{
                //    filesButton.BackColor = oplConfig.HighlightColor;
                //}
                //else
                //{
                //    filesButton.BackColor = default(Color);
                //}
            }
        }


        private void filesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (filesCheckBox.Checked)
            {
                if (_addFileListFirstLoad)
                {
                    _addFileListFirstLoad = false;
                    addFilesList.Clear();
                    foreach (string sourceFile in sourceAddFileList)
                    {
                        addFilesList.Add(sourceFile);
                        _addFileListFirstLoad = false;
                    }
                }
                filesButton.Enabled = true;
            }
            else
            {
                filesButton.Enabled = false;
            }

            if (addFilesList.Count > 0)
                filesButton.BackColor = oplConfig.HighlightColor;
            else
                filesButton.BackColor = default(Color);

        }
    }

}

