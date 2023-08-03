using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views.Alerts;
using System.Text.Json;
using System.Security.Policy;

namespace OpenPsiLabWinForms.Views
{
    public partial class SessionForm : Form
    {
        private SessionController sessionController { get; set; }
        private RVSession _rvSession;
        private RVSession rvSession
        {
            get
            {
                return _rvSession;
            }
            set
            {
                _rvSession = value;
            }
        }
        private SessionExportForm exportForm;
        private KeyValuePair<string, string> VIEWER_TARGET;
        private bool disableImageCheckboxes = false;
        private SessionType _typeOfSession;
        private SessionType typeOfSession
        {
            get
            {
                return _typeOfSession;
            }
            set
            {
                _typeOfSession = value;
                switchMode(value);
            }
        }
        public enum SessionType
        {
            Practice,
            Associative
        }
        private OPLConfiguration oplConfig { get; set; }
        private ImageUtilities imageUtils { get; set; }


        public SessionForm(SessionType sessionType, OPLConfiguration oplConfiguration)
        {
            InitializeComponent();

            oplConfig = oplConfiguration;
            typeOfSession = sessionType;
            

            imageUtils = new ImageUtilities(oplConfiguration);

            sessionController = new SessionController(new SQLiteDatabase(oplConfig), oplConfig);
            string randSource = oplConfig.RandomnessSource;
            if (randSource.ToLower() == "truerng")
            {
                randSource += $" {oplConfig.RNGSerialPortName}";
            }
            randomSourceLabel.Text = $"Randomness Source: {randSource}" + " (Click to change)";
                
            reset();
            createSession();

            if (sessionType == SessionType.Practice)
                titleTextBox.Text = "Practice Session";
            else if (sessionType == SessionType.Associative)
            {
                titleTextBox.Text = "ARV Session";
                arvQuestionTextBox.Text = "Enter ARV question";
                arvAnswer1TextBox.Text = "Enter ARV answer 1";
                arvAnswer2textBox.Text = "Enter ARV answer 2";
            }

            oplConfig.RaisePropertyChangedEvent += HandleOPLConfigPropertyChanged;
        }
        
        private void SessionForm_ResizeEnd(object sender, EventArgs e)
        {
            //imagesSplitContainer.SplitterDistance = imagesSplitContainer.Width / 2;
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {

        }

        private void idsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setIDTextBox();
        }

        private void setIDTextBox()
        {


            if (rvSession == null || rvSession.ImagesArray == null) return;

            if (!(rvSession.ImagesArray.Length == 2))
            {
                return;
            }
            if (idsCheckBox.Checked)
            {
                picBox1IDtextBox.Text = $"ID: {rvSession.Image1.UUID.ToString()}";
                picBox2IDtextBox.Text = $"ID: {rvSession.Image2.UUID.ToString()}";
            }
            else
            {
                picBox1IDtextBox.Text = $"ID:";
                picBox2IDtextBox.Text = $"ID:";
            }
        }

        private void setTargetTextBox()
        {
            if (!targetCheckBox.Checked)
            {
                picBox1TargetTextBox.Text = "";
                setControlDeselected(picBox1TargetTextBox);
                picBox2TargetTextBox.Text = "";
                setControlDeselected(picBox2TargetTextBox);
            }
            else
            {
                switch (rvSession.TargetIndex)
                {
                    case 1:
                        picBox1TargetTextBox.Text = "TARGET";
                        picBox2TargetTextBox.Text = string.Empty;
                        picBox1TargetTextBox.BackColor = oplConfig.HighlightColor;
                        picBox2TargetTextBox.BackColor = default(Color);
                        break;
                    case 2:
                        picBox2TargetTextBox.Text = "TARGET";
                        picBox1TargetTextBox.Text = string.Empty;
                        picBox2TargetTextBox.BackColor = oplConfig.HighlightColor;
                        picBox1TargetTextBox.BackColor = default(Color);
                        break;
                }
            }
        }

        private void enableSaveButton()
        {
            saveButton.Enabled = true;
            exportButton.Enabled = true;
        }

        private void selectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectionCheckBox.Checked)
            {
                setSelectionControlsSelected();
            }
            else
            {
                setAllSelectionControlsDeslected();
            }
            setTargetTextBox();
        }

        private void targetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            setTargetTextBox();
        }

        private void getTargetButton_Click(object sender, EventArgs e)
        {
            if (typeOfSession == SessionType.Practice)
                getTarget();
            else if (typeOfSession == SessionType.Associative)
                setTarget();
        }

        private void setTarget()
        {
            ARVSetTargetForm targetForm = new ARVSetTargetForm(
                arvQuestionTextBox.Text, arvAnswer1TextBox.Text,
                arvAnswer2textBox.Text);
            DialogResult dlgResult = targetForm.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (targetForm.arvAnswer1RadioButton.Checked == true)
                {
                    rvSession.TargetIndex = 1;
                } else if (targetForm.arvAnswer2RadioButton.Checked == true)
                {
                    rvSession.TargetIndex = 2;
                }
                targetCheckBox.Enabled = true;
                targetImageCheckBox.Enabled = true;
                setTargetTextBox();
                targetImageCheckBox.Enabled = true;
                targetImageCheckBox.BackColor = oplConfig.HighlightColor;
                targetCheckBox.BackColor = oplConfig.HighlightColor;
                rvSession.Targeted = "true";
                setRandomTargetID();
            }
        }

        private void getTarget()
        {
            if (rvSession.ImagesArray == null) return;
            RandomNumberController randyCont = new RandomNumberController(oplConfig);

            rvSession.TargetedDateTimeLocal = DateTimeOffset.Now;

            if (oplConfig.RandomnessSource.ToLower() == "truerng")
            {
                string rngSerialPort = oplConfig.RNGSerialPortName;
            }

            RandomNumberResult randTargetResult = randyCont.GetRandomNumberNormalized();
            if (randTargetResult.randomNumber < 0.5)
            {
                rvSession.TargetIndex = 1;
            }
            else
            {
                rvSession.TargetIndex = 2;
            }

            setRandomTargetID();

            targetCheckBox.Enabled = true;
            targetCheckBox.BackColor = oplConfig.HighlightColor;
            targetImageCheckBox.Enabled = true;
            targetImageCheckBox.BackColor = oplConfig.HighlightColor;
            setTargetTextBox();
            targetTextBox.Select();
            targetImageCheckBox.Enabled = true;
            rvSession.Targeted = "true";
        }

        private void setRandomTargetID()
        {
            if (string.IsNullOrWhiteSpace(targetTextBox.Text))
            {
                RandomNumberController randyCont = new RandomNumberController(oplConfig);
                string id = "";
                for (int i = 1; i < 7; i++)
                {
                    RandomNumberResult randID = randyCont.GetRandomNumberNormalized();
                    double idDouble = (double)(randID.randomNumber * 10.0);
                    if (idDouble >= 9.5)
                    {
                        //if idDouble is >= to 9.5 it will be rounded 
                        //up to 10 instead of a single digit number
                        //which is what we need
                        i = i - 1;
                        continue;
                    }
                    int idInt = (int)(Math.Round(idDouble));
                    id = id + idInt;
                    Debug.WriteLine(idInt);
                    Thread.Sleep(50);
                }
                string idString = id.ToString();
                idString = idString.Substring(0, 3) + " -- " + idString.Substring(3);
                targetTextBox.Text = idString;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
            createSession();
        }

        private void reset()
        {
            if (rvSession != null)
            {
                deleteSessionTempFolder();
            }
            sessionController = new SessionController(
                new SQLiteDatabase(oplConfig), oplConfig);
            rvSession = null;

            targetTextBox.Text = string.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            picBox1IDtextBox.Text = "ID:";
            picBox2IDtextBox.Text = "ID:";
            sessionUUIDTextBox.Text = "ID:";

            viewerSelect1Button.Enabled = false;
            viewerSelect2Button.Enabled = false;
            raterSelect1Button.Enabled = false;
            raterSelect2Button.Enabled = false;
            getTargetButton.Enabled = false;
            getImagesButton.Enabled = true;

            idsCheckBox.Checked = false;
            idsCheckBox.Enabled = false;
            idsCheckBox.BackColor = default(Color);

            targetCheckBox.Checked = false;
            targetCheckBox.Enabled = false;
            targetCheckBox.BackColor = default(Color);

            imagesCheckBox.Checked = false;
            imagesCheckBox.Enabled = false;
            imagesCheckBox.BackColor = default(Color);

            targetImageCheckBox.Checked = false;
            targetImageCheckBox.Enabled = false;
            targetImageCheckBox.BackColor = default(Color);

            selectionCheckBox.Checked = false;
            selectionCheckBox.Enabled = false;
            selectionCheckBox.BackColor = default(Color);

            sessionNameTextBox.Text = string.Empty;
            targetTextBox.Text = string.Empty;
            viewerNameTextBox.Text = string.Empty;
            raterNameTextBox.Text = string.Empty;

            notesButton.Enabled = false;
            addFilesButton.Enabled = false;
            exportButton.Enabled = false;
            saveButton.Enabled = false;

            notesButton.BackColor = default(Color);
            addFilesButton.BackColor = default(Color);
            
            getImagesButton.Select();

            if (typeOfSession == SessionType.Practice)
            {
                arvCheckBox.Enabled = false;
                arvCheckBox.Visible = false;
                arvCheckBox.Checked = false;
            } else if (typeOfSession == SessionType.Associative)
            {
                arvCheckBox.Enabled = true;
                arvCheckBox.Visible = true;
                arvCheckBox.Checked = true;
            }

            arvQuestionTextBox.Text = "Enter ARV question";
            arvAnswer1TextBox.Text = "Enter ARV answer 1";
            arvAnswer2textBox.Text = "Enter ARV answer 2";

        }

        private void setControlSelected(object sender)
        {
            Control c = (Control)sender;
            c.BackColor = oplConfig.HighlightColor;
        }

        private void setControlDeselected(object sender)
        {
            Control c = (Control)sender;
            c.BackColor = default(Color);
            if (c.GetType() == typeof(Button))
            {
                Button b = (Button)c;
                b.UseVisualStyleBackColor = true;
            }
            c.Font = new Font(c.Font, FontStyle.Regular);
        }

        private void setAllSelectionControlsDeslected()
        {
            viewerSelect1Button.Text = "Viewer Select";
            setControlDeselected(viewerSelect1Button);
            viewerSelect2Button.Text = "Viewer Select";
            setControlDeselected(viewerSelect2Button);
            raterSelect1Button.Text = "Rater Select";
            setControlDeselected(raterSelect1Button);
            raterSelect2Button.Text = "Rater Select";
            setControlDeselected(raterSelect2Button);
        }

        private void setSelectionControlsSelected()
        {
            if (!selectionCheckBox.Checked)
            {
                setAllSelectionControlsDeslected();
            }
            else
            {
                if (rvSession.ViewerSelectedIndex == 1)
                {
                    viewerSelect1Button.Text = "Viewer Selected";
                    setControlSelected(viewerSelect1Button);
                    viewerSelect2Button.Text = "Viewer Select";
                    setControlDeselected(viewerSelect2Button);
                }
                else if (rvSession.ViewerSelectedIndex == 2)
                {
                    viewerSelect2Button.Text = "Viewer Selected";
                    viewerSelect1Button.Text = "Viewer Select";
                    setControlSelected(viewerSelect2Button);
                    setControlDeselected(viewerSelect1Button);
                }

                if (rvSession.RaterSelectedIndex == 1)
                {
                    raterSelect1Button.Text = "Rater Selected";
                    raterSelect2Button.Text = "Rater Select";
                    setControlSelected(raterSelect1Button);
                    setControlDeselected(raterSelect2Button);
                }
                else if (rvSession.RaterSelectedIndex == 2)
                {
                    raterSelect2Button.Text = "Rater Selected";
                    raterSelect1Button.Text = "Rater Select";
                    setControlSelected(raterSelect2Button);
                    setControlDeselected(raterSelect1Button);
                }

                viewerSelect1Button.Enabled = true;
                viewerSelect2Button.Enabled = true;
                raterSelect1Button.Enabled = true;
                raterSelect2Button.Enabled = true;
            }
        }

        private void viewerSelect1Button_Click(object sender, EventArgs e)
        {
            setViewerSelection(1);
        }
        private void viewerSelect2Button_Click(object sender, EventArgs e)
        {
            setViewerSelection(2);
        }

        private void setViewerSelection(int selectedIndex)
        {
            rvSession.ViewerSelectedDateTimeLocal = DateTimeOffset.Now;
            rvSession.ViewerSelectedIndex = selectedIndex;
            selectionCheckBox.Enabled = true;
            setTargetTextBox();
            setSelectionControlsSelected();
            selectionCheckBox.BackColor = oplConfig.HighlightColor; 
            enableSaveButton();
        }

        private void raterSelect1Button_Click(object sender, EventArgs e)
        {
            setRaterSelection(1);
        }

        private void raterSelect2Button_Click(object sender, EventArgs e)
        {
            setRaterSelection(2);
        }

        private void setRaterSelection(int selectedIndex)
        {
            rvSession.RaterSelectedDateTimeLocal = DateTimeOffset.Now;
            rvSession.RaterSelectedIndex = selectedIndex;
            selectionCheckBox.Enabled = true;
            setTargetTextBox();
            setSelectionControlsSelected();
            selectionCheckBox.BackColor = oplConfig.HighlightColor; 
            Refresh();
            enableSaveButton();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveToFolderAndDB();
            sessionUUIDTextBox.Text = rvSession.UUID.ToString() + " (Click to change)";
            MessageBox.Show("Save completed", "Save Completed", MessageBoxButtons.OK);
        }
        
        public void screenshot(string filePath, string uuid)
        {
            bool imagesChecked = imagesCheckBox.Checked;
            bool selectionChecked = selectionCheckBox.Checked;
            bool idsChecked = idsCheckBox.Checked;
            bool targetChecked = targetCheckBox.Checked;

            imagesCheckBox.Checked = true;
            selectionCheckBox.Checked = true;
            idsCheckBox.Checked = true;
            targetCheckBox.Checked = true;
            Refresh();

            Rectangle bounds = Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    imagesCheckBox.Checked = true;
                    selectionCheckBox.Checked = true;
                    idsCheckBox.Checked = true;
                    targetCheckBox.Checked = true;
                    Refresh();
                    Activate();
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    imagesCheckBox.Checked = imagesChecked;
                    selectionCheckBox.Checked = selectionChecked;
                    idsCheckBox.Checked = idsChecked;
                    targetCheckBox.Checked = targetChecked;
                    Refresh();
                }

                string savePath = Path.Combine(filePath, $"SessionScreenShot-{uuid}.jpg");
                bitmap.Save(savePath, ImageFormat.Jpeg);
            }
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            AddFilesForm fileForm = new AddFilesForm(sessionController.sessionFilesList, 
                oplConfig, AddFilesForm.Modes.Session);

            DialogResult dlgResult = fileForm.ShowDialog(this);

            if (dlgResult == DialogResult.OK)
            {
                if (fileForm.fileDataGridView.Rows.Count > 0)
                {
                    sessionController.sessionFilesList.Clear();
                    foreach (DataGridViewRow row in fileForm.fileDataGridView.Rows)
                    {
                        sessionController.sessionFilesList.Add(row.Cells[1].Value.ToString());
                    }
                    addFilesButton.BackColor = oplConfig.HighlightColor; 
                }
                else
                {
                    sessionController.sessionFilesList.Clear();
                    addFilesButton.BackColor = default(Color);
                    return;
                }
            }
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            NotesForm nForm = new NotesForm();
            nForm.notesTextBox.Text = rvSession.Notes;
            nForm.ShowDialog(this);
            if (nForm.DialogResult == DialogResult.OK)
            {
                rvSession.Notes = nForm.notesTextBox.Text;
                if (string.IsNullOrWhiteSpace(rvSession.Notes))
                {
                    notesButton.BackColor = default(Color);
                }
                else
                {
                    notesButton.BackColor = oplConfig.HighlightColor; 
                }
            }
            nForm.Dispose();
        }

        private void SessionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteSessionTempFolder();
        }

        private void deleteSessionTempFolder()
        {
            if (rvSession != null)
            {
                string tempDirectory = Path.Combine(oplConfig.AppDataPath, 
                    "Temp", rvSession.UUID.ToString());
                try
                {
                    Directory.Delete(tempDirectory, true);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        private void targetImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (disableImageCheckboxes == false)
            {
                disableImageCheckboxes = true;
                imagesCheckBox.Checked = false;
                disableImageCheckboxes = false;
                showImages();
            }
        }

        private void imagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (disableImageCheckboxes == false)
            {
                disableImageCheckboxes = true;
                targetImageCheckBox.Checked = false;
                disableImageCheckboxes = false;
                showImages();
            }
                
        }

        private void showImages()
        {
            if (disableImageCheckboxes == true)
                return;

            if (imagesCheckBox.Checked == false && targetImageCheckBox.Checked == false)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                viewerSelect1Button.Enabled = false;
                viewerSelect2Button.Enabled = false;
                raterSelect1Button.Enabled = false;
                raterSelect2Button.Enabled = false;
                setAllSelectionControlsDeslected();
                selectionCheckBox.Enabled = false;
                return;
            }
            else
            {
                if (imagesCheckBox.Checked)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    viewerSelect1Button.Enabled = true;
                    viewerSelect2Button.Enabled = true;
                    raterSelect1Button.Enabled = true;
                    raterSelect2Button.Enabled = true;
                    if (selectionCheckBox.Checked)
                    {
                        setSelectionControlsSelected();
                    }
                    else
                    {
                        setAllSelectionControlsDeslected();
                    }
                    selectionCheckBox.Enabled = true;
                }
                else if (targetImageCheckBox.Checked)
                {
                    switch (rvSession.TargetIndex)
                    {
                        case 1:
                            pictureBox1.Visible = true;
                            pictureBox2.Visible = false;
                            break;
                        case 2:
                            pictureBox1.Visible = false;
                            pictureBox2.Visible = true;
                            break;
                    }
                }

            }
        }

        private void randomSourceLabel_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(oplConfig);
            settingsForm.ShowDialog(this);
             string randomnessSource = $"Randomness Source: {oplConfig.RandomnessSource}";
             if (oplConfig.RandomnessSource.ToLower().Trim() == "truerng")
                 randomnessSource = randomnessSource + $": {oplConfig.RNGSerialPortName}";
             randomSourceLabel.Text = randomnessSource + " (Click to change)";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            SessionFolderSelectForm loadForm = new SessionFolderSelectForm(oplConfig);
            try
            {
                loadForm.ShowDialog(this);
                if (loadForm.DialogResult == DialogResult.OK)
                {
                    
                    string folderPath = loadForm.FolderPath;
                    RVSession sp = sessionController.SessionPracticeGetFromDirectory(folderPath);

                    if (sp.SessionType == SessionType.Associative && rvSession.SessionType == SessionType.Practice)
                    {
                        MessageBox.Show("Unalbe to load ARV Session in Practice Session window.  Pleae " +
                                        "launch an ARV Session window and try again.", "Load Error",
                            MessageBoxButtons.OK);
                        return;
                    }
                    if (sp.SessionType == SessionType.Practice && rvSession.SessionType == SessionType.Associative)
                    {
                        MessageBox.Show("Unalbe to load Practice Session in ARV Session window.  Pleae " +
                                        "launch a Practice Session window and try again.", "Load Error",
                            MessageBoxButtons.OK);
                        return;
                    }

                    reset();
                    rvSession = sp;
                    sessionController.sessionFilesList.Clear();
                    string[] filePaths = Directory.GetFiles(Path.Combine(folderPath, "Files"));

                    if (filePaths.Length > 0)
                        addFilesButton.BackColor = oplConfig.HighlightColor;
                    foreach (string filePath in filePaths)
                    {
                        sessionController.sessionFilesList.Add(filePath);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load session from directory.", "Error");
                return;
            }
            finally
            {
                loadForm.Close();
                loadForm.Dispose();
            }

            //Setup images on form
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            imagesCheckBox.Enabled = false;
            imagesCheckBox.BackColor = default(Color);
            selectionCheckBox.Enabled = false;
            selectionCheckBox.Checked = false;
            viewerSelect1Button.Enabled = false;
            viewerSelect2Button.Enabled = false;
            raterSelect1Button.Enabled = false;
            raterSelect2Button.Enabled = false;
            if (rvSession.ImagesArray != null)
            {
                if (rvSession.Image1.UUID != Guid.Empty ||
                    rvSession.Image2.UUID != Guid.Empty)
                {
                    imagesCheckBox.Enabled = true;
                    imagesCheckBox.Checked = false;
                    imagesCheckBox.BackColor = oplConfig.HighlightColor;
                    //getImagesButton.Enabled = false;
                    idsCheckBox.Enabled = true;
                    idsCheckBox.Checked = false;
                    idsCheckBox.BackColor = oplConfig.HighlightColor;

                    if (rvSession.Image1.IsRaterSelected || rvSession.Image1.IsViewerSelected ||
                        rvSession.Image2.IsRaterSelected || rvSession.Image2.IsViewerSelected)
                    { selectionCheckBox.BackColor = oplConfig.HighlightColor; }
                    else { selectionCheckBox.BackColor = default(Color); }
                        

                    if (rvSession.Image1.UUID != Guid.Empty)
                    {
                        pictureBox1.Image = rvSession.Image1.ImageBitmap;
                    }

                    if (rvSession.Image2.UUID != Guid.Empty)
                    {
                        pictureBox2.Image = rvSession.Image2.ImageBitmap;
                    }

                    if (rvSession.Image1.IsViewerSelected || rvSession.Image1.IsRaterSelected
                                                          || rvSession.Image2.IsViewerSelected || rvSession.Image2.IsRaterSelected)
                    {
                        selectionCheckBox.Enabled = false;
                    }
                }
            }

            //Setup session ID
            sessionUUIDTextBox.Text = rvSession.UUID.ToString() + " (Click to change)";

            //Setup textboxes
            viewerNameTextBox.Text = rvSession.ViewerName;
            raterNameTextBox.Text = rvSession.RaterName;
            targetTextBox.Text = rvSession.TargetID;
            sessionNameTextBox.Text = rvSession.Name;
            taskerNameTextBox.Text = rvSession.TaskerName;
            monitorNameTextBox.Text = rvSession.MonitorName;

            //Setup target button
            if (rvSession.Targeted == "true")
            {
                //getTargetButton.Enabled = false;
                targetCheckBox.Enabled = true;
                targetCheckBox.BackColor = oplConfig.HighlightColor;
                targetImageCheckBox.Enabled = true;
                targetImageCheckBox.BackColor = oplConfig.HighlightColor;
            }
            else
            {
                //getTargetButton.Enabled = true;
                targetCheckBox.Enabled = false;
                targetImageCheckBox.Enabled = false;
            }
            getTargetButton.Enabled = true;

            //Setup ARV fields
            if (rvSession.SessionType == SessionType.Associative)
            {
                arvQuestionTextBox.Text = rvSession.ARVQuestion;
                arvAnswer1TextBox.Text = rvSession.ARVAnswer1;
                arvAnswer2textBox.Text = rvSession.ARVAnswer2;
            }

            //Setup notes button
            notesButton.Enabled = true;
            if (!string.IsNullOrWhiteSpace(rvSession.Notes))
                notesButton.BackColor = oplConfig.HighlightColor;


            viewerNameTextBox.Enabled = true;
            raterNameTextBox.Enabled = true;
            targetTextBox.Enabled = true;
            sessionNameTextBox.Enabled = true;

            
            addFilesButton.Enabled = true;
            exportButton.Enabled = true;
            saveButton.Enabled = true;

            setIDTextBox();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sessionFiles = new List<string>();
                foreach (string filePath in sessionController.sessionFilesList)
                {
                    sessionFiles.Add(filePath.ToString());
                }
                exportForm = new SessionExportForm(sessionFilesList: sessionFiles, 
                    rvSessionSource: rvSession, oplConfiguration: oplConfig, 
                    sessionController: sessionController);
                exportForm.ShowDialog(this);

                if (exportForm.DialogResult == DialogResult.OK)
                {
                    string folderPath = exportForm.FolderPath;
                    try
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            MessageBox.Show("Error: Folder path is not valid.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: Folder path is not valid.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    sessionController.SessionPracticeSaveToFolder(rvSession: exportForm.RvSessionExport,
                        sessionForm: this, fileList: exportForm.ExportFileList, exportFolderFullPath: folderPath, 
                        exportConfig: exportForm.exportConfig);

                    MessageBox.Show("Export complete.", "Export Complete", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                var x = ex; //To suppress warning
                MessageBox.Show("Unable to export to directory.", "Error");
            }
            finally
            {
                exportForm.Close();
                exportForm.Dispose();
            }
        }

        private void sessionNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession == null) return;
            rvSession.Name = sessionNameTextBox.Text.Trim();
        }

        private void targetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession != null)
            {
                rvSession.TargetID = targetTextBox.Text.Trim();

                //Create an in-memory association of target ID to image
                //so the viewer has something physical to target
                if (rvSession.TargetImageUUID != null)
                {
                    VIEWER_TARGET = new KeyValuePair<string, string>(targetTextBox.Text.Trim(),
                        rvSession.TargetImageUUID.ToString());
                }
            }
        }

        private void viewerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession == null) return;
            rvSession.ViewerName = viewerNameTextBox.Text;
        }

        private void taskerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession == null) return;
            rvSession.TaskerName = taskerNameTextBox.Text;
        }

        private void monitorNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession == null) return;
            rvSession.MonitorName = monitorNameTextBox.Text;
        }


        private void saveToFolderAndDB()
        {
            rvSession.SessionType = typeOfSession;
            rvSession.EndDateTimeLocal = DateTimeOffset.Now;
            string doWhat = sessionController.SessionPracticeSaveToFolder(rvSession: rvSession,
                sessionForm: this, includeScreenshot: true, fileList: sessionController.sessionFilesList);
            if (doWhat == "cancel") return;
            if (doWhat == "overwrite")
                sessionController.SessionPracticeSaveToDatabase(rvSession, true);
            else
                sessionController.SessionPracticeSaveToDatabase(rvSession);
        }

        private void raterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (rvSession == null) return;
            rvSession.RaterName = raterNameTextBox.Text;
        }

        private void arvCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (arvCheckBox.Checked)
            {
                arvQuestionTextBox.Enabled = true;
                arvQuestionTextBox.Visible = true;
                arvQuestionLabel.Visible = true;
                arvAnswer1TextBox.Enabled = true;
                arvAnswer1TextBox.Visible = true;
                arvAnswer2textBox.Enabled = true;
                arvAnswer2textBox.Visible = true;
            }
            else
            {
                arvQuestionTextBox.Enabled = false;
                arvQuestionTextBox.Visible = false;
                arvQuestionLabel.Visible = false;
                arvAnswer1TextBox.Enabled = false;
                arvAnswer1TextBox.Visible = false;
                arvAnswer2textBox.Enabled = false;
                arvAnswer2textBox.Visible = false;
            }
        }

        private void arvButton_Click(object sender, EventArgs e)
        {
            if (typeOfSession == SessionType.Practice)
                typeOfSession = SessionType.Associative;
            else if (typeOfSession == SessionType.Associative)
                typeOfSession = SessionType.Practice;
        }

        private void switchMode(SessionType sessionType)
        {
            if (sessionType == SessionType.Practice)
            {
                arvCheckBox.BackColor = default(Color);
                arvCheckBox.Enabled = false;
                arvCheckBox.Checked = false;
                arvQuestionTextBox.Text = string.Empty;
                arvAnswer1TextBox.Text = string.Empty;
                arvAnswer2textBox.Text = string.Empty;
                getTargetButton.Text = "Get Target";
                titleTextBox.Text = "Practice Session";
            } else if (sessionType == SessionType.Associative)
            {
                arvCheckBox.BackColor = oplConfig.HighlightColor;
                arvCheckBox.Enabled = true;
                arvCheckBox.Checked = false;
                arvQuestionTextBox.Text = "ENTER ARV QUESTION";
                arvAnswer1TextBox.Text = "ARV ANSWER 1";
                arvAnswer2textBox.Text = "ARV ANSWER 2";
                getTargetButton.Text = "Set Target";
                titleTextBox.Text = "ARV Session";
            }
        }

        private void arvQuestionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (arvQuestionTextBox.Enabled == true  && rvSession != null)
                rvSession.ARVQuestion = arvQuestionTextBox.Text.Trim();
        }

        private void arvAnswer1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (arvAnswer1TextBox.Enabled == true && rvSession != null)
                rvSession.ARVAnswer1 = arvAnswer1TextBox.Text.Trim();
        }

        private void arvAnswer2textBox_TextChanged(object sender, EventArgs e)
        {
            if (arvAnswer2textBox.Enabled == true && rvSession != null)
                rvSession.ARVAnswer2 = arvAnswer2textBox.Text.Trim();
        }

        private void setImageButton_Click(object sender, EventArgs e)
        {
            SetImagesForm imgForm = new SetImagesForm(rvSession, 
                new SQLiteDatabase(oplConfig), sessionController, oplConfig);

            DialogResult dlgResult = imgForm.ShowDialog(this);
            if (dlgResult == DialogResult.OK)
            {
                try
                {
                    if (rvSession.ImagesArray == null)
                    {
                        rvSession.ImagesArray = new ImageAsset[2];
                    }
                    //Base on image UUID in filename get info from DB
                    rvSession.Image1 = imgForm.Image1;
                    pictureBox1.Image = rvSession.Image1.ImageBitmap;
                    rvSession.Image2 = imgForm.Image2;
                    pictureBox2.Image = rvSession.Image2.ImageBitmap;
                    setIDTextBox();

                    if (rvSession.ImagesArray.Length < 2)
                    {
                        MessageBox.Show("Before starting a session you must first add images to the database. " +
                                        "To do so go to the menu Tools -> Image Download -> Unsplash Web",
                            "Initialize Image Database", MessageBoxButtons.OK);
                        return;
                    }

                    imagesCheckBox.Enabled = true;
                    imagesCheckBox.BackColor = oplConfig.HighlightColor;
                    idsCheckBox.Enabled = true;
                    idsCheckBox.BackColor = oplConfig.HighlightColor;
                    getTargetButton.Enabled = true;
                    getTargetButton.Select();
                    Refresh();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                
            }
        }

        private void createSession()
        {
            rvSession =
                new RVSession(new SiderealTimeUtilities(),
                    double.Parse(oplConfig.Longitude), 
                    typeOfSession, oplConfig);
            sessionUUIDTextBox.Text = rvSession.UUID.ToString() + " (Click to change)";

            enableSaveButton();

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;

            selectionCheckBox.Checked = false;
            targetCheckBox.Checked = false;

            viewerSelect1Button.Enabled = false;
            viewerSelect2Button.Enabled = false;
            targetCheckBox.Enabled = false;

            viewerNameTextBox.Enabled = true;
            raterNameTextBox.Enabled = true;
            targetTextBox.Enabled = true;
            sessionNameTextBox.Enabled = true;

            notesButton.Enabled = true;
            addFilesButton.Enabled = true;

            //This is necessary because the ARV controls are disabled 
            //until the session is created.
            if (typeOfSession == SessionType.Associative)
            {
                arvCheckBox.BackColor = oplConfig.HighlightColor;
                arvCheckBox.Enabled = true;
                //arvCheckBox.Checked = false;
                getTargetButton.Text = "Set Target";
                titleTextBox.Text = "ARV Session";
            }
            setIDTextBox();
        }

        private List<ImageAsset> getImageAssets(int recursionCount = 0)
        {
            int maxRecursion = 5;
            recursionCount += 1;
            if (recursionCount > maxRecursion)
                throw new Exception("Image file not found in Images folder");
            try
            {
                List<ImageAsset> ias = sessionController.ImageSetRandomGet(numberOfImages: 2);
                if (ias.Count < 2) return null; // return ias;

                imageUtils.loadBitmaps(ias);
                
                if (ias.Count < 2 )
                    return getImageAssets(recursionCount);
                bool recurse = false;
                foreach (ImageAsset img in ias)
                {
                    if (img.ImageBitmap == null)
                        recurse = true;
                }

                if (recurse == true)
                    return getImageAssets(recursionCount);
                else
                    return ias;
            }
            catch (Exception)
            {
                return getImageAssets(recursionCount);
            }
        }

        private void getImagesButton_Click(object sender, EventArgs e)
        {
            List<ImageAsset> ias = getImageAssets();
            if (ias == null || ias.Count < 2)
            {
                MessageBox.Show("Before starting a session you must first add images to the database. " +
                                "To do so go to the menu Tools -> Image Download ",
                    "Initialize Image Database", MessageBoxButtons.OK);

                return;
            } 

            rvSession.ImagesArray = ias.ToArray();

            pictureBox1.Image = rvSession.ImagesArray[0].ImageBitmap;
            pictureBox2.Image = rvSession.ImagesArray[1].ImageBitmap;
            if (idsCheckBox.Checked)
            {
                picBox1IDtextBox.Text = $"ID: {rvSession.ImagesArray[0].UUID}";
                picBox2IDtextBox.Text = $"ID: {rvSession.ImagesArray[1].UUID}";
            }
            else
            {
                picBox1IDtextBox.Text = $"ID: ";
                picBox2IDtextBox.Text = $"ID: ";
            }
            
            imagesCheckBox.Enabled = true;
            imagesCheckBox.BackColor = oplConfig.HighlightColor;
            idsCheckBox.Enabled = true;
            idsCheckBox.BackColor = oplConfig.HighlightColor;
            getTargetButton.Enabled = true;
            getTargetButton.Select();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rvSession == null || rvSession.ImagesArray == null 
                                       || rvSession.Image1 == null)
                return;

            string filePath = Path.Combine(oplConfig.ImageFolderFullPath, rvSession.Image1.FileName);
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception)
            {
                MessageBox.Show("It appears that this image is not in the images folder. " +
                                "Only images that have been added to the database and image " +
                                "folder can be opened in the native viewer.", "Missing Image File",
                    MessageBoxButtons.OK);
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (rvSession == null || rvSession.ImagesArray == null
                                       || rvSession.Image2 == null)
                return;
            
            string filePath = Path.Combine(oplConfig.ImageFolderFullPath, rvSession.Image2.FileName);

            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception)
            {
                MessageBox.Show("It appears that this image is not in the images folder. " +
                                "Only images that have been added to the database and image " +
                                "folder can be opened in the native viewer.", "Missing Image File",
                    MessageBoxButtons.OK);
            }
        }

        private void sessionUUIDTextBox_Click(object sender, EventArgs e)
        {
            newSessionID();
        }

        private void newSessionID()
        {
            DialogResult dlg = MessageBox.Show("Would you like to create a new ID for " +
                                               "this session?", "New ID", MessageBoxButtons.YesNo);
            if (dlg == DialogResult.Yes)
            {
                rvSession.UUID = Guid.NewGuid();
                sessionUUIDTextBox.Text = rvSession.UUID.ToString() + " (Click to change)";
            }
        }

        private void HandleOPLConfigPropertyChanged(object sender, CustomEventArgs e)
        {
            if (e.PropertyName == "RandomnessSource" || 
                e.PropertyName == "RNGSerialPortName")
            {
                string randSource = $"Randomness Source: " +
                                    oplConfig.RandomnessSource;
                if (oplConfig.RandomnessSource == "TrueRNG")
                {
                    randSource += "-" + oplConfig.RNGSerialPortName;
                }
                randomSourceLabel.Text = randSource + " (Click to change)";
            }


        }

        
    }
}
