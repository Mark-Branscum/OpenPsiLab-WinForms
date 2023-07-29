using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views;
using OpenPsiLabWinForms.Views.Alerts;

namespace OpenPsiLabWinForms
{
    public partial class MainForm : Form
    {
        private OPLConfiguration oplConfig;
        
        public MainForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();

            oplConfig = oplConfiguration;

            //Display space weather
            //string curDir = Directory.GetCurrentDirectory();
            Uri url = new Uri(Path.Combine(oplConfig.DocumentsPath, "Resources", "MainPage.html"));

            spaceWeatherwebView2.Source = url;
            
            //Ensure that longitude is configured
            SiderealTimeUtilities sideUtils = new SiderealTimeUtilities();
            double? longitude = null;
            try
            {
                string longitudeString = oplConfig.Longitude;
                longitude = double.Parse(longitudeString);
            }
            catch (Exception)
            {
                while (longitude == null)
                {
                    LongitudeAlert longAlert = new LongitudeAlert(oplConfig);
                    longAlert.ShowDialog();
                    if (longAlert.DialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("Exiting program.", 
                            "Exiting", MessageBoxButtons.OK);
                        Environment.Exit(0);
                    }
                    else
                    {
                        try
                        {
                            longitude = double.Parse(oplConfig.Longitude);
                            oplConfig.Longitude = longitude.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid Longitude Format");
                            continue;
                        }
                    }
                }
            }
            DateTimeOffset side1300DTO = sideUtils.getSidereal1300(DateTimeOffset.Now, (double)longitude);
            string side1300Minute = side1300DTO.Minute.ToString();
            if (side1300DTO.Minute < 10) side1300Minute = "0" + side1300Minute;
            todays1300TextBox.Text = $"Today's 1300 sidereal time is at {side1300DTO.Hour}:" +
                                   $"{side1300Minute} solar time";
            spaceWeatherwebView2.Select();
            Refresh();

            //Display splash screen
            //SplashForm splash = new SplashForm(oplConfig);
            //if (oplConfig.SupressSplashScreen == false)
            //    splash.ShowDialog();
        }

        private void checkForUpdates()
        {
            //Check for updates
            using (WebClient client = new WebClient())
            {
                try
                {
                    string latestVersion =
                        client.DownloadString(
                            "https://mark-branscum.github.io/OpenPsiLab-WinForms/LatestVersion.txt");
                    string[] latestdigits = latestVersion.Split('.');
                    SQLiteDatabase db = new SQLiteDatabase(oplConfig);
                    KeyValuePair<string, string> installedVersion = (KeyValuePair<string, string>)db.AdminKeyValueGet("ProgramVersion");
                    string[] installtedDigits = installedVersion.Value.Split('.');
                    bool needsUpdate = false;
                    for (int i = 0; i < 3; i++)
                    {
                        int installedInt = int.Parse(installtedDigits[i]);
                        int latestInt = int.Parse(latestdigits[i]);
                        if (latestInt > installedInt) needsUpdate = true;
                    }

                    if (needsUpdate == true)
                    {
                        DialogResult dlg = MessageBox.Show("An update is available.  " +
                                                           "Would you like to download the update?", "Update Available",
                            MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {
                            WebForm wf = new WebForm("https://mark-branscum.github.io/OpenPsiLab-WinForms/");
                            wf.ShowDialog();
                        }
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(oplConfig);
            settingsForm.ShowDialog(this);
        }

        private void unsplashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageDownloadForm unsplash = new ImageDownloadForm(oplConfig);
            unsplash.Show();
        }

        private void unsplashWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageDownloadWebForm uWeb = new ImageDownloadWebForm(oplConfig);
            uWeb.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void localImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalImageImportForm localForm = new LocalImageImportForm(oplConfig);
            localForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void imagesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string folderPath = oplConfig.ImageFolderFullPath;
            FolderUtilities.OpenFolder(folderPath);
        }

        private void rVSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = oplConfig.LoadSessionPath; 
            FolderUtilities.OpenFolder(folderPath);
        }

        private void reconcileImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReconcileImagesForm recForm = new ReconcileImagesForm(oplConfig);
            recForm.Show(this);
        }

        private void practiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SessionForm sessionForm = new SessionForm(SessionForm.SessionType.Practice, oplConfig);
            sessionForm.Show();
        }

        private void aRVAssociativeRemoteViewingSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionForm sessionForm = new SessionForm(SessionForm.SessionType.Associative, oplConfig);
            sessionForm.Show();
        }

        private void siderealTimeCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SideralTimeForm sideTimeForm = new SideralTimeForm(oplConfig);
            sideTimeForm.Show();
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localImageToolStripMenuItem_Click(sender: sender, e: e);
            //LocalImageImportForm localForm = new LocalImageImportForm(oplConfig);
            //localForm.Show();
        }
    }
}
