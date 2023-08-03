namespace OpenPsiLabWinForms.Views
{
    partial class SessionExportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.folderButton = new System.Windows.Forms.Button();
            this.folderNameTextBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.screenshotCheckBox = new System.Windows.Forms.CheckBox();
            this.dataExportGroupBox = new System.Windows.Forms.GroupBox();
            this.filesCheckBox = new System.Windows.Forms.CheckBox();
            this.arvCheckBox = new System.Windows.Forms.CheckBox();
            this.geomagneticCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesGroupBox = new System.Windows.Forms.GroupBox();
            this.targetImageRadioButton = new System.Windows.Forms.RadioButton();
            this.controlImageRadioButton = new System.Windows.Forms.RadioButton();
            this.noImagesRadioButton = new System.Windows.Forms.RadioButton();
            this.allImagesRadioButton = new System.Windows.Forms.RadioButton();
            this.testButton = new System.Windows.Forms.Button();
            this.setToDefaultsButton = new System.Windows.Forms.Button();
            this.filesButton = new System.Windows.Forms.Button();
            this.notesCheckBox = new System.Windows.Forms.CheckBox();
            this.raterNameCheckBox = new System.Windows.Forms.CheckBox();
            this.viewerNameCheckBox = new System.Windows.Forms.CheckBox();
            this.sessionNameCheckBox = new System.Windows.Forms.CheckBox();
            this.raterSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.viewerSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.targetSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.targetIDCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.taskerNameCheckBox = new System.Windows.Forms.CheckBox();
            this.monitorNameCheckBox = new System.Windows.Forms.CheckBox();
            this.dataExportGroupBox.SuspendLayout();
            this.imagesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderButton.Location = new System.Drawing.Point(368, 33);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(44, 23);
            this.folderButton.TabIndex = 4;
            this.folderButton.Text = "...";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // folderNameTextBox
            // 
            this.folderNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderNameTextBox.Location = new System.Drawing.Point(12, 35);
            this.folderNameTextBox.Name = "folderNameTextBox";
            this.folderNameTextBox.Size = new System.Drawing.Size(350, 20);
            this.folderNameTextBox.TabIndex = 3;
            this.folderNameTextBox.TextChanged += new System.EventHandler(this.folderNameTextBox_TextChanged);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(336, 594);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // screenshotCheckBox
            // 
            this.screenshotCheckBox.AutoSize = true;
            this.screenshotCheckBox.Location = new System.Drawing.Point(6, 384);
            this.screenshotCheckBox.Name = "screenshotCheckBox";
            this.screenshotCheckBox.Size = new System.Drawing.Size(244, 17);
            this.screenshotCheckBox.TabIndex = 7;
            this.screenshotCheckBox.Text = "Screenshot - Exposes all data, including target";
            this.screenshotCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataExportGroupBox
            // 
            this.dataExportGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataExportGroupBox.Controls.Add(this.monitorNameCheckBox);
            this.dataExportGroupBox.Controls.Add(this.taskerNameCheckBox);
            this.dataExportGroupBox.Controls.Add(this.filesCheckBox);
            this.dataExportGroupBox.Controls.Add(this.arvCheckBox);
            this.dataExportGroupBox.Controls.Add(this.geomagneticCheckBox);
            this.dataExportGroupBox.Controls.Add(this.imagesGroupBox);
            this.dataExportGroupBox.Controls.Add(this.testButton);
            this.dataExportGroupBox.Controls.Add(this.setToDefaultsButton);
            this.dataExportGroupBox.Controls.Add(this.filesButton);
            this.dataExportGroupBox.Controls.Add(this.notesCheckBox);
            this.dataExportGroupBox.Controls.Add(this.raterNameCheckBox);
            this.dataExportGroupBox.Controls.Add(this.viewerNameCheckBox);
            this.dataExportGroupBox.Controls.Add(this.sessionNameCheckBox);
            this.dataExportGroupBox.Controls.Add(this.raterSelectedCheckBox);
            this.dataExportGroupBox.Controls.Add(this.viewerSelectedCheckBox);
            this.dataExportGroupBox.Controls.Add(this.targetSelectedCheckBox);
            this.dataExportGroupBox.Controls.Add(this.targetIDCheckBox);
            this.dataExportGroupBox.Controls.Add(this.screenshotCheckBox);
            this.dataExportGroupBox.Location = new System.Drawing.Point(12, 70);
            this.dataExportGroupBox.Name = "dataExportGroupBox";
            this.dataExportGroupBox.Size = new System.Drawing.Size(399, 508);
            this.dataExportGroupBox.TabIndex = 8;
            this.dataExportGroupBox.TabStop = false;
            this.dataExportGroupBox.Text = "Data to Export";
            // 
            // filesCheckBox
            // 
            this.filesCheckBox.AutoSize = true;
            this.filesCheckBox.Location = new System.Drawing.Point(6, 455);
            this.filesCheckBox.Name = "filesCheckBox";
            this.filesCheckBox.Size = new System.Drawing.Size(50, 17);
            this.filesCheckBox.TabIndex = 26;
            this.filesCheckBox.Text = "Files:";
            this.filesCheckBox.UseVisualStyleBackColor = true;
            this.filesCheckBox.CheckedChanged += new System.EventHandler(this.filesCheckBox_CheckedChanged);
            // 
            // arvCheckBox
            // 
            this.arvCheckBox.AutoSize = true;
            this.arvCheckBox.Checked = true;
            this.arvCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.arvCheckBox.Location = new System.Drawing.Point(6, 177);
            this.arvCheckBox.Name = "arvCheckBox";
            this.arvCheckBox.Size = new System.Drawing.Size(157, 17);
            this.arvCheckBox.TabIndex = 24;
            this.arvCheckBox.Text = "ARV Question and Answers";
            this.arvCheckBox.UseVisualStyleBackColor = true;
            // 
            // geomagneticCheckBox
            // 
            this.geomagneticCheckBox.AutoSize = true;
            this.geomagneticCheckBox.Location = new System.Drawing.Point(6, 432);
            this.geomagneticCheckBox.Name = "geomagneticCheckBox";
            this.geomagneticCheckBox.Size = new System.Drawing.Size(133, 17);
            this.geomagneticCheckBox.TabIndex = 23;
            this.geomagneticCheckBox.Text = "Geomagnetic Weather";
            this.geomagneticCheckBox.UseVisualStyleBackColor = true;
            // 
            // imagesGroupBox
            // 
            this.imagesGroupBox.Controls.Add(this.targetImageRadioButton);
            this.imagesGroupBox.Controls.Add(this.controlImageRadioButton);
            this.imagesGroupBox.Controls.Add(this.noImagesRadioButton);
            this.imagesGroupBox.Controls.Add(this.allImagesRadioButton);
            this.imagesGroupBox.Location = new System.Drawing.Point(6, 52);
            this.imagesGroupBox.Name = "imagesGroupBox";
            this.imagesGroupBox.Size = new System.Drawing.Size(150, 118);
            this.imagesGroupBox.TabIndex = 22;
            this.imagesGroupBox.TabStop = false;
            this.imagesGroupBox.Text = "Images";
            // 
            // targetImageRadioButton
            // 
            this.targetImageRadioButton.AutoSize = true;
            this.targetImageRadioButton.Location = new System.Drawing.Point(6, 88);
            this.targetImageRadioButton.Name = "targetImageRadioButton";
            this.targetImageRadioButton.Size = new System.Drawing.Size(56, 17);
            this.targetImageRadioButton.TabIndex = 3;
            this.targetImageRadioButton.Text = "Target";
            this.targetImageRadioButton.UseVisualStyleBackColor = true;
            // 
            // controlImageRadioButton
            // 
            this.controlImageRadioButton.AutoSize = true;
            this.controlImageRadioButton.Location = new System.Drawing.Point(6, 65);
            this.controlImageRadioButton.Name = "controlImageRadioButton";
            this.controlImageRadioButton.Size = new System.Drawing.Size(58, 17);
            this.controlImageRadioButton.TabIndex = 2;
            this.controlImageRadioButton.Text = "Control";
            this.controlImageRadioButton.UseVisualStyleBackColor = true;
            // 
            // noImagesRadioButton
            // 
            this.noImagesRadioButton.AutoSize = true;
            this.noImagesRadioButton.Location = new System.Drawing.Point(6, 42);
            this.noImagesRadioButton.Name = "noImagesRadioButton";
            this.noImagesRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noImagesRadioButton.TabIndex = 1;
            this.noImagesRadioButton.Text = "None";
            this.noImagesRadioButton.UseVisualStyleBackColor = true;
            // 
            // allImagesRadioButton
            // 
            this.allImagesRadioButton.AutoSize = true;
            this.allImagesRadioButton.Checked = true;
            this.allImagesRadioButton.Location = new System.Drawing.Point(6, 19);
            this.allImagesRadioButton.Name = "allImagesRadioButton";
            this.allImagesRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allImagesRadioButton.TabIndex = 0;
            this.allImagesRadioButton.TabStop = true;
            this.allImagesRadioButton.Text = "All";
            this.allImagesRadioButton.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(269, 52);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 21;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Visible = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // setToDefaultsButton
            // 
            this.setToDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setToDefaultsButton.Location = new System.Drawing.Point(282, 468);
            this.setToDefaultsButton.Name = "setToDefaultsButton";
            this.setToDefaultsButton.Size = new System.Drawing.Size(111, 23);
            this.setToDefaultsButton.TabIndex = 20;
            this.setToDefaultsButton.Text = "Set to Defaults";
            this.setToDefaultsButton.UseVisualStyleBackColor = true;
            this.setToDefaultsButton.Click += new System.EventHandler(this.setToDefaultsButton_Click);
            // 
            // filesButton
            // 
            this.filesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filesButton.Location = new System.Drawing.Point(62, 452);
            this.filesButton.Name = "filesButton";
            this.filesButton.Size = new System.Drawing.Size(53, 23);
            this.filesButton.TabIndex = 19;
            this.filesButton.Text = "Files";
            this.filesButton.UseVisualStyleBackColor = true;
            this.filesButton.Click += new System.EventHandler(this.filesButton_Click);
            // 
            // notesCheckBox
            // 
            this.notesCheckBox.AutoSize = true;
            this.notesCheckBox.Location = new System.Drawing.Point(6, 408);
            this.notesCheckBox.Name = "notesCheckBox";
            this.notesCheckBox.Size = new System.Drawing.Size(54, 17);
            this.notesCheckBox.TabIndex = 18;
            this.notesCheckBox.Text = "Notes";
            this.notesCheckBox.UseVisualStyleBackColor = true;
            // 
            // raterNameCheckBox
            // 
            this.raterNameCheckBox.AutoSize = true;
            this.raterNameCheckBox.Checked = true;
            this.raterNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.raterNameCheckBox.Location = new System.Drawing.Point(6, 292);
            this.raterNameCheckBox.Name = "raterNameCheckBox";
            this.raterNameCheckBox.Size = new System.Drawing.Size(83, 17);
            this.raterNameCheckBox.TabIndex = 16;
            this.raterNameCheckBox.Text = "Rater Name";
            this.raterNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewerNameCheckBox
            // 
            this.viewerNameCheckBox.AutoSize = true;
            this.viewerNameCheckBox.Checked = true;
            this.viewerNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewerNameCheckBox.Location = new System.Drawing.Point(6, 223);
            this.viewerNameCheckBox.Name = "viewerNameCheckBox";
            this.viewerNameCheckBox.Size = new System.Drawing.Size(89, 17);
            this.viewerNameCheckBox.TabIndex = 15;
            this.viewerNameCheckBox.Text = "Viewer Name";
            this.viewerNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // sessionNameCheckBox
            // 
            this.sessionNameCheckBox.AutoSize = true;
            this.sessionNameCheckBox.Checked = true;
            this.sessionNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sessionNameCheckBox.Location = new System.Drawing.Point(6, 200);
            this.sessionNameCheckBox.Name = "sessionNameCheckBox";
            this.sessionNameCheckBox.Size = new System.Drawing.Size(94, 17);
            this.sessionNameCheckBox.TabIndex = 14;
            this.sessionNameCheckBox.Text = "Session Name";
            this.sessionNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // raterSelectedCheckBox
            // 
            this.raterSelectedCheckBox.AutoSize = true;
            this.raterSelectedCheckBox.Location = new System.Drawing.Point(6, 338);
            this.raterSelectedCheckBox.Name = "raterSelectedCheckBox";
            this.raterSelectedCheckBox.Size = new System.Drawing.Size(99, 17);
            this.raterSelectedCheckBox.TabIndex = 13;
            this.raterSelectedCheckBox.Text = "Rater Selection";
            this.raterSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewerSelectedCheckBox
            // 
            this.viewerSelectedCheckBox.AutoSize = true;
            this.viewerSelectedCheckBox.Location = new System.Drawing.Point(6, 315);
            this.viewerSelectedCheckBox.Name = "viewerSelectedCheckBox";
            this.viewerSelectedCheckBox.Size = new System.Drawing.Size(105, 17);
            this.viewerSelectedCheckBox.TabIndex = 12;
            this.viewerSelectedCheckBox.Text = "Viewer Selection";
            this.viewerSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // targetSelectedCheckBox
            // 
            this.targetSelectedCheckBox.AutoSize = true;
            this.targetSelectedCheckBox.Location = new System.Drawing.Point(6, 361);
            this.targetSelectedCheckBox.Name = "targetSelectedCheckBox";
            this.targetSelectedCheckBox.Size = new System.Drawing.Size(104, 17);
            this.targetSelectedCheckBox.TabIndex = 11;
            this.targetSelectedCheckBox.Text = "Target Selection";
            this.targetSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // targetIDCheckBox
            // 
            this.targetIDCheckBox.AutoSize = true;
            this.targetIDCheckBox.Checked = true;
            this.targetIDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.targetIDCheckBox.Location = new System.Drawing.Point(6, 29);
            this.targetIDCheckBox.Name = "targetIDCheckBox";
            this.targetIDCheckBox.Size = new System.Drawing.Size(100, 17);
            this.targetIDCheckBox.TabIndex = 8;
            this.targetIDCheckBox.Text = "Target Identifier";
            this.targetIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(255, 594);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Destination Folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taskerNameCheckBox
            // 
            this.taskerNameCheckBox.AutoSize = true;
            this.taskerNameCheckBox.Checked = true;
            this.taskerNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.taskerNameCheckBox.Location = new System.Drawing.Point(6, 246);
            this.taskerNameCheckBox.Name = "taskerNameCheckBox";
            this.taskerNameCheckBox.Size = new System.Drawing.Size(90, 17);
            this.taskerNameCheckBox.TabIndex = 27;
            this.taskerNameCheckBox.Text = "Tasker Name";
            this.taskerNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // monitorNameCheckBox
            // 
            this.monitorNameCheckBox.AutoSize = true;
            this.monitorNameCheckBox.Checked = true;
            this.monitorNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.monitorNameCheckBox.Location = new System.Drawing.Point(6, 269);
            this.monitorNameCheckBox.Name = "monitorNameCheckBox";
            this.monitorNameCheckBox.Size = new System.Drawing.Size(92, 17);
            this.monitorNameCheckBox.TabIndex = 28;
            this.monitorNameCheckBox.Text = "Monitor Name";
            this.monitorNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // SessionExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 629);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataExportGroupBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.folderNameTextBox);
            this.Name = "SessionExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Session";
            this.dataExportGroupBox.ResumeLayout(false);
            this.dataExportGroupBox.PerformLayout();
            this.imagesGroupBox.ResumeLayout(false);
            this.imagesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.TextBox folderNameTextBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        public System.Windows.Forms.CheckBox screenshotCheckBox;
        private System.Windows.Forms.GroupBox dataExportGroupBox;
        public System.Windows.Forms.CheckBox raterNameCheckBox;
        public System.Windows.Forms.CheckBox viewerNameCheckBox;
        public System.Windows.Forms.CheckBox sessionNameCheckBox;
        public System.Windows.Forms.CheckBox raterSelectedCheckBox;
        public System.Windows.Forms.CheckBox viewerSelectedCheckBox;
        public System.Windows.Forms.CheckBox targetSelectedCheckBox;
        public System.Windows.Forms.CheckBox targetIDCheckBox;
        private System.Windows.Forms.Button filesButton;
        private System.Windows.Forms.CheckBox notesCheckBox;
        private System.Windows.Forms.Button setToDefaultsButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.GroupBox imagesGroupBox;
        private System.Windows.Forms.RadioButton targetImageRadioButton;
        private System.Windows.Forms.RadioButton controlImageRadioButton;
        private System.Windows.Forms.RadioButton noImagesRadioButton;
        private System.Windows.Forms.RadioButton allImagesRadioButton;
        private System.Windows.Forms.CheckBox geomagneticCheckBox;
        private System.Windows.Forms.CheckBox arvCheckBox;
        private System.Windows.Forms.CheckBox filesCheckBox;
        public System.Windows.Forms.CheckBox monitorNameCheckBox;
        public System.Windows.Forms.CheckBox taskerNameCheckBox;
    }
}