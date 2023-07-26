namespace OpenPsiLabWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rVSessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconcileImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siderealTimeCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceWeatherwebView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.todays1300TextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WebView2MissingTextBox = new System.Windows.Forms.TextBox();
            this.localFileSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unspalshWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsplashManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceWeatherwebView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.timeToolStripMenuItem,
            this.rVToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1116, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.foldersToolStripMenuItem,
            this.databaseMaintenanceToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localFileSystemToolStripMenuItem,
            this.unspalshWebToolStripMenuItem,
            this.unsplashManualToolStripMenuItem});
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imagesToolStripMenuItem.Text = "Image Import";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.imagesToolStripMenuItem_Click);
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem1,
            this.rVSessionsToolStripMenuItem});
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.foldersToolStripMenuItem.Text = "Folders";
            // 
            // imagesToolStripMenuItem1
            // 
            this.imagesToolStripMenuItem1.Name = "imagesToolStripMenuItem1";
            this.imagesToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.imagesToolStripMenuItem1.Text = "Imported Images";
            this.imagesToolStripMenuItem1.Click += new System.EventHandler(this.imagesToolStripMenuItem1_Click);
            // 
            // rVSessionsToolStripMenuItem
            // 
            this.rVSessionsToolStripMenuItem.Name = "rVSessionsToolStripMenuItem";
            this.rVSessionsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.rVSessionsToolStripMenuItem.Text = "Saved RV Sessions";
            this.rVSessionsToolStripMenuItem.Click += new System.EventHandler(this.rVSessionsToolStripMenuItem_Click);
            // 
            // databaseMaintenanceToolStripMenuItem
            // 
            this.databaseMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reconcileImagesToolStripMenuItem});
            this.databaseMaintenanceToolStripMenuItem.Name = "databaseMaintenanceToolStripMenuItem";
            this.databaseMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.databaseMaintenanceToolStripMenuItem.Text = "Database Maintenance";
            // 
            // reconcileImagesToolStripMenuItem
            // 
            this.reconcileImagesToolStripMenuItem.Name = "reconcileImagesToolStripMenuItem";
            this.reconcileImagesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reconcileImagesToolStripMenuItem.Text = "Reconcile Images";
            this.reconcileImagesToolStripMenuItem.Click += new System.EventHandler(this.reconcileImagesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siderealTimeCalculatorToolStripMenuItem});
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.timeToolStripMenuItem.Text = "Time";
            // 
            // siderealTimeCalculatorToolStripMenuItem
            // 
            this.siderealTimeCalculatorToolStripMenuItem.Name = "siderealTimeCalculatorToolStripMenuItem";
            this.siderealTimeCalculatorToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.siderealTimeCalculatorToolStripMenuItem.Text = "Sidereal Time Calculator";
            this.siderealTimeCalculatorToolStripMenuItem.Click += new System.EventHandler(this.siderealTimeCalculatorToolStripMenuItem_Click);
            // 
            // rVToolStripMenuItem
            // 
            this.rVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.practiceToolStripMenuItem1,
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem});
            this.rVToolStripMenuItem.Name = "rVToolStripMenuItem";
            this.rVToolStripMenuItem.Size = new System.Drawing.Size(33, 20);
            this.rVToolStripMenuItem.Text = "RV";
            // 
            // practiceToolStripMenuItem1
            // 
            this.practiceToolStripMenuItem1.Name = "practiceToolStripMenuItem1";
            this.practiceToolStripMenuItem1.Size = new System.Drawing.Size(297, 22);
            this.practiceToolStripMenuItem1.Text = "Practice Remote Viewing Session";
            this.practiceToolStripMenuItem1.Click += new System.EventHandler(this.practiceToolStripMenuItem1_Click);
            // 
            // aRVAssociativeRemoteViewingSessionToolStripMenuItem
            // 
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem.Name = "aRVAssociativeRemoteViewingSessionToolStripMenuItem";
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem.Text = "ARV (Associative) Remote Viewing Session";
            this.aRVAssociativeRemoteViewingSessionToolStripMenuItem.Click += new System.EventHandler(this.aRVAssociativeRemoteViewingSessionToolStripMenuItem_Click);
            // 
            // spaceWeatherwebView2
            // 
            this.spaceWeatherwebView2.AllowExternalDrop = true;
            this.spaceWeatherwebView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spaceWeatherwebView2.CreationProperties = null;
            this.spaceWeatherwebView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.spaceWeatherwebView2.Location = new System.Drawing.Point(-1, -1);
            this.spaceWeatherwebView2.Name = "spaceWeatherwebView2";
            this.spaceWeatherwebView2.Size = new System.Drawing.Size(1092, 471);
            this.spaceWeatherwebView2.TabIndex = 1;
            this.spaceWeatherwebView2.ZoomFactor = 1D;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(12, 31);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(1078, 28);
            this.titleTextBox.TabIndex = 10;
            this.titleTextBox.Text = "Open Psi Lab";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // todays1300TextBox
            // 
            this.todays1300TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.todays1300TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todays1300TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todays1300TextBox.Location = new System.Drawing.Point(12, 65);
            this.todays1300TextBox.Name = "todays1300TextBox";
            this.todays1300TextBox.ReadOnly = true;
            this.todays1300TextBox.Size = new System.Drawing.Size(1078, 19);
            this.todays1300TextBox.TabIndex = 5;
            this.todays1300TextBox.Text = "Today\'s 1300 Sidereal Time";
            this.todays1300TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.spaceWeatherwebView2);
            this.panel1.Controls.Add(this.WebView2MissingTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 471);
            this.panel1.TabIndex = 11;
            // 
            // WebView2MissingTextBox
            // 
            this.WebView2MissingTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebView2MissingTextBox.Location = new System.Drawing.Point(125, 137);
            this.WebView2MissingTextBox.Multiline = true;
            this.WebView2MissingTextBox.Name = "WebView2MissingTextBox";
            this.WebView2MissingTextBox.ReadOnly = true;
            this.WebView2MissingTextBox.Size = new System.Drawing.Size(632, 194);
            this.WebView2MissingTextBox.TabIndex = 12;
            this.WebView2MissingTextBox.Text = resources.GetString("WebView2MissingTextBox.Text");
            // 
            // localFileSystemToolStripMenuItem
            // 
            this.localFileSystemToolStripMenuItem.Name = "localFileSystemToolStripMenuItem";
            this.localFileSystemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.localFileSystemToolStripMenuItem.Text = "Local File System";
            this.localFileSystemToolStripMenuItem.Click += new System.EventHandler(this.imagesToolStripMenuItem_Click);
            // 
            // unspalshWebToolStripMenuItem
            // 
            this.unspalshWebToolStripMenuItem.Name = "unspalshWebToolStripMenuItem";
            this.unspalshWebToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unspalshWebToolStripMenuItem.Text = "Unspalsh Web";
            this.unspalshWebToolStripMenuItem.Click += new System.EventHandler(this.unsplashWebToolStripMenuItem_Click);
            // 
            // unsplashManualToolStripMenuItem
            // 
            this.unsplashManualToolStripMenuItem.Name = "unsplashManualToolStripMenuItem";
            this.unsplashManualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unsplashManualToolStripMenuItem.Text = "Unsplash Manual";
            this.unsplashManualToolStripMenuItem.Click += new System.EventHandler(this.unsplashToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 593);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.todays1300TextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Psi Lab";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spaceWeatherwebView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 spaceWeatherwebView2;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox todays1300TextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rVSessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconcileImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practiceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aRVAssociativeRemoteViewingSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siderealTimeCalculatorToolStripMenuItem;
        private System.Windows.Forms.TextBox WebView2MissingTextBox;
        private System.Windows.Forms.ToolStripMenuItem localFileSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unspalshWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsplashManualToolStripMenuItem;
    }
}

