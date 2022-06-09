namespace OpenPsiLabWinForms.Views
{
    partial class SessionForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.getTargetButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.imagesCheckBox = new System.Windows.Forms.CheckBox();
            this.idsCheckBox = new System.Windows.Forms.CheckBox();
            this.selectionCheckBox = new System.Windows.Forms.CheckBox();
            this.targetCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.arvAnswer1TextBox = new System.Windows.Forms.TextBox();
            this.picBox1TargetTextBox = new System.Windows.Forms.TextBox();
            this.judgeSelect1Button = new System.Windows.Forms.Button();
            this.picBox1IDtextBox = new System.Windows.Forms.TextBox();
            this.viewerSelect1Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.arvAnswer2textBox = new System.Windows.Forms.TextBox();
            this.picBox2TargetTextBox = new System.Windows.Forms.TextBox();
            this.judgeSelect2Button = new System.Windows.Forms.Button();
            this.picBox2IDtextBox = new System.Windows.Forms.TextBox();
            this.viewerSelect2Button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.getImagesButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.sessionUUIDTextBox = new System.Windows.Forms.TextBox();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionNameTextBox = new System.Windows.Forms.TextBox();
            this.sessionStatusStrip = new System.Windows.Forms.StatusStrip();
            this.randomSourceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notesButton = new System.Windows.Forms.Button();
            this.targetImageCheckBox = new System.Windows.Forms.CheckBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.viewerNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.judgeNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.arvCheckBox = new System.Windows.Forms.CheckBox();
            this.arvQuestionTextBox = new System.Windows.Forms.TextBox();
            this.setImageButton = new System.Windows.Forms.Button();
            this.arvQuestionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagesSplitContainer)).BeginInit();
            this.imagesSplitContainer.Panel1.SuspendLayout();
            this.imagesSplitContainer.Panel2.SuspendLayout();
            this.imagesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.sessionStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Identifier:";
            // 
            // targetTextBox
            // 
            this.targetTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.targetTextBox.Enabled = false;
            this.targetTextBox.Location = new System.Drawing.Point(421, 512);
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.Size = new System.Drawing.Size(213, 20);
            this.targetTextBox.TabIndex = 2;
            this.targetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetTextBox.TextChanged += new System.EventHandler(this.targetTextBox_TextChanged);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resetButton.Location = new System.Drawing.Point(12, 596);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(90, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // getTargetButton
            // 
            this.getTargetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.getTargetButton.Location = new System.Drawing.Point(301, 596);
            this.getTargetButton.Name = "getTargetButton";
            this.getTargetButton.Size = new System.Drawing.Size(90, 23);
            this.getTargetButton.TabIndex = 8;
            this.getTargetButton.Text = "Get Target";
            this.getTargetButton.UseVisualStyleBackColor = true;
            this.getTargetButton.Click += new System.EventHandler(this.getTargetButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Display:";
            // 
            // imagesCheckBox
            // 
            this.imagesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.imagesCheckBox.AutoSize = true;
            this.imagesCheckBox.Location = new System.Drawing.Point(64, 573);
            this.imagesCheckBox.Name = "imagesCheckBox";
            this.imagesCheckBox.Size = new System.Drawing.Size(74, 17);
            this.imagesCheckBox.TabIndex = 9;
            this.imagesCheckBox.Text = "All Images";
            this.imagesCheckBox.UseVisualStyleBackColor = true;
            this.imagesCheckBox.CheckedChanged += new System.EventHandler(this.imagesCheckBox_CheckedChanged);
            // 
            // idsCheckBox
            // 
            this.idsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.idsCheckBox.AutoSize = true;
            this.idsCheckBox.Location = new System.Drawing.Point(236, 573);
            this.idsCheckBox.Name = "idsCheckBox";
            this.idsCheckBox.Size = new System.Drawing.Size(42, 17);
            this.idsCheckBox.TabIndex = 12;
            this.idsCheckBox.Text = "IDs";
            this.idsCheckBox.UseVisualStyleBackColor = true;
            this.idsCheckBox.CheckedChanged += new System.EventHandler(this.idsCheckBox_CheckedChanged);
            // 
            // selectionCheckBox
            // 
            this.selectionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.selectionCheckBox.AutoSize = true;
            this.selectionCheckBox.Location = new System.Drawing.Point(285, 573);
            this.selectionCheckBox.Name = "selectionCheckBox";
            this.selectionCheckBox.Size = new System.Drawing.Size(70, 17);
            this.selectionCheckBox.TabIndex = 10;
            this.selectionCheckBox.Text = "Selection";
            this.selectionCheckBox.UseVisualStyleBackColor = true;
            this.selectionCheckBox.CheckedChanged += new System.EventHandler(this.selectionCheckBox_CheckedChanged);
            // 
            // targetCheckBox
            // 
            this.targetCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.targetCheckBox.AutoSize = true;
            this.targetCheckBox.Location = new System.Drawing.Point(360, 573);
            this.targetCheckBox.Name = "targetCheckBox";
            this.targetCheckBox.Size = new System.Drawing.Size(57, 17);
            this.targetCheckBox.TabIndex = 11;
            this.targetCheckBox.Text = "Target";
            this.targetCheckBox.UseVisualStyleBackColor = true;
            this.targetCheckBox.CheckedChanged += new System.EventHandler(this.targetCheckBox_CheckedChanged);
            // 
            // imagesSplitContainer
            // 
            this.imagesSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagesSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagesSplitContainer.Location = new System.Drawing.Point(13, 97);
            this.imagesSplitContainer.Name = "imagesSplitContainer";
            // 
            // imagesSplitContainer.Panel1
            // 
            this.imagesSplitContainer.Panel1.Controls.Add(this.arvAnswer1TextBox);
            this.imagesSplitContainer.Panel1.Controls.Add(this.picBox1TargetTextBox);
            this.imagesSplitContainer.Panel1.Controls.Add(this.judgeSelect1Button);
            this.imagesSplitContainer.Panel1.Controls.Add(this.picBox1IDtextBox);
            this.imagesSplitContainer.Panel1.Controls.Add(this.viewerSelect1Button);
            this.imagesSplitContainer.Panel1.Controls.Add(this.pictureBox1);
            // 
            // imagesSplitContainer.Panel2
            // 
            this.imagesSplitContainer.Panel2.Controls.Add(this.arvAnswer2textBox);
            this.imagesSplitContainer.Panel2.Controls.Add(this.picBox2TargetTextBox);
            this.imagesSplitContainer.Panel2.Controls.Add(this.judgeSelect2Button);
            this.imagesSplitContainer.Panel2.Controls.Add(this.picBox2IDtextBox);
            this.imagesSplitContainer.Panel2.Controls.Add(this.viewerSelect2Button);
            this.imagesSplitContainer.Panel2.Controls.Add(this.pictureBox2);
            this.imagesSplitContainer.Size = new System.Drawing.Size(622, 404);
            this.imagesSplitContainer.SplitterDistance = 308;
            this.imagesSplitContainer.TabIndex = 13;
            // 
            // arvAnswer1TextBox
            // 
            this.arvAnswer1TextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.arvAnswer1TextBox.Enabled = false;
            this.arvAnswer1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvAnswer1TextBox.Location = new System.Drawing.Point(52, 273);
            this.arvAnswer1TextBox.Name = "arvAnswer1TextBox";
            this.arvAnswer1TextBox.Size = new System.Drawing.Size(201, 24);
            this.arvAnswer1TextBox.TabIndex = 0;
            this.arvAnswer1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.arvAnswer1TextBox.Visible = false;
            this.arvAnswer1TextBox.TextChanged += new System.EventHandler(this.arvAnswer1TextBox_TextChanged);
            // 
            // picBox1TargetTextBox
            // 
            this.picBox1TargetTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picBox1TargetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox1TargetTextBox.Location = new System.Drawing.Point(5, 344);
            this.picBox1TargetTextBox.Name = "picBox1TargetTextBox";
            this.picBox1TargetTextBox.ReadOnly = true;
            this.picBox1TargetTextBox.Size = new System.Drawing.Size(298, 20);
            this.picBox1TargetTextBox.TabIndex = 5;
            this.picBox1TargetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // judgeSelect1Button
            // 
            this.judgeSelect1Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.judgeSelect1Button.Location = new System.Drawing.Point(156, 370);
            this.judgeSelect1Button.Name = "judgeSelect1Button";
            this.judgeSelect1Button.Size = new System.Drawing.Size(127, 23);
            this.judgeSelect1Button.TabIndex = 2;
            this.judgeSelect1Button.Text = "Judge Select";
            this.judgeSelect1Button.UseVisualStyleBackColor = true;
            this.judgeSelect1Button.Click += new System.EventHandler(this.judgeSelect1Button_Click);
            // 
            // picBox1IDtextBox
            // 
            this.picBox1IDtextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picBox1IDtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox1IDtextBox.Location = new System.Drawing.Point(5, 318);
            this.picBox1IDtextBox.Name = "picBox1IDtextBox";
            this.picBox1IDtextBox.ReadOnly = true;
            this.picBox1IDtextBox.Size = new System.Drawing.Size(298, 20);
            this.picBox1IDtextBox.TabIndex = 2;
            this.picBox1IDtextBox.Text = "ID:";
            this.picBox1IDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // viewerSelect1Button
            // 
            this.viewerSelect1Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewerSelect1Button.Location = new System.Drawing.Point(25, 370);
            this.viewerSelect1Button.Name = "viewerSelect1Button";
            this.viewerSelect1Button.Size = new System.Drawing.Size(125, 23);
            this.viewerSelect1Button.TabIndex = 1;
            this.viewerSelect1Button.Text = "Viewer Select";
            this.viewerSelect1Button.UseVisualStyleBackColor = true;
            this.viewerSelect1Button.Click += new System.EventHandler(this.viewerSelect1Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // arvAnswer2textBox
            // 
            this.arvAnswer2textBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.arvAnswer2textBox.Enabled = false;
            this.arvAnswer2textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvAnswer2textBox.Location = new System.Drawing.Point(54, 273);
            this.arvAnswer2textBox.Name = "arvAnswer2textBox";
            this.arvAnswer2textBox.Size = new System.Drawing.Size(200, 24);
            this.arvAnswer2textBox.TabIndex = 0;
            this.arvAnswer2textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.arvAnswer2textBox.Visible = false;
            this.arvAnswer2textBox.TextChanged += new System.EventHandler(this.arvAnswer2textBox_TextChanged);
            // 
            // picBox2TargetTextBox
            // 
            this.picBox2TargetTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picBox2TargetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox2TargetTextBox.Location = new System.Drawing.Point(5, 344);
            this.picBox2TargetTextBox.Name = "picBox2TargetTextBox";
            this.picBox2TargetTextBox.ReadOnly = true;
            this.picBox2TargetTextBox.Size = new System.Drawing.Size(300, 20);
            this.picBox2TargetTextBox.TabIndex = 6;
            this.picBox2TargetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // judgeSelect2Button
            // 
            this.judgeSelect2Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.judgeSelect2Button.Location = new System.Drawing.Point(157, 370);
            this.judgeSelect2Button.Name = "judgeSelect2Button";
            this.judgeSelect2Button.Size = new System.Drawing.Size(127, 23);
            this.judgeSelect2Button.TabIndex = 2;
            this.judgeSelect2Button.Text = "Judge Select";
            this.judgeSelect2Button.UseVisualStyleBackColor = true;
            this.judgeSelect2Button.Click += new System.EventHandler(this.judgeSelect2Button_Click);
            // 
            // picBox2IDtextBox
            // 
            this.picBox2IDtextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picBox2IDtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox2IDtextBox.Location = new System.Drawing.Point(4, 318);
            this.picBox2IDtextBox.Name = "picBox2IDtextBox";
            this.picBox2IDtextBox.ReadOnly = true;
            this.picBox2IDtextBox.Size = new System.Drawing.Size(301, 20);
            this.picBox2IDtextBox.TabIndex = 5;
            this.picBox2IDtextBox.Text = "ID:";
            this.picBox2IDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // viewerSelect2Button
            // 
            this.viewerSelect2Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewerSelect2Button.Location = new System.Drawing.Point(25, 370);
            this.viewerSelect2Button.Name = "viewerSelect2Button";
            this.viewerSelect2Button.Size = new System.Drawing.Size(126, 23);
            this.viewerSelect2Button.TabIndex = 1;
            this.viewerSelect2Button.Text = "Viewer Select";
            this.viewerSelect2Button.UseVisualStyleBackColor = true;
            this.viewerSelect2Button.Click += new System.EventHandler(this.viewerSelect2Button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(301, 308);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(12, 13);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(622, 24);
            this.titleTextBox.TabIndex = 14;
            this.titleTextBox.Text = "Practice Session";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // getImagesButton
            // 
            this.getImagesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.getImagesButton.Location = new System.Drawing.Point(108, 596);
            this.getImagesButton.Name = "getImagesButton";
            this.getImagesButton.Size = new System.Drawing.Size(90, 23);
            this.getImagesButton.TabIndex = 7;
            this.getImagesButton.Text = "Get Images";
            this.getImagesButton.UseVisualStyleBackColor = true;
            this.getImagesButton.Click += new System.EventHandler(this.getImagesButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(559, 596);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // sessionUUIDTextBox
            // 
            this.sessionUUIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionUUIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sessionUUIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionUUIDTextBox.Location = new System.Drawing.Point(12, 44);
            this.sessionUUIDTextBox.Name = "sessionUUIDTextBox";
            this.sessionUUIDTextBox.ReadOnly = true;
            this.sessionUUIDTextBox.Size = new System.Drawing.Size(622, 15);
            this.sessionUUIDTextBox.TabIndex = 17;
            this.sessionUUIDTextBox.Text = "ID:";
            this.sessionUUIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sessionUUIDTextBox.Click += new System.EventHandler(this.sessionUUIDTextBox_Click);
            // 
            // addFilesButton
            // 
            this.addFilesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addFilesButton.Enabled = false;
            this.addFilesButton.Location = new System.Drawing.Point(559, 567);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(75, 23);
            this.addFilesButton.TabIndex = 6;
            this.addFilesButton.Text = "Add Files";
            this.addFilesButton.UseVisualStyleBackColor = true;
            this.addFilesButton.Click += new System.EventHandler(this.addFilesButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Session Name:";
            // 
            // sessionNameTextBox
            // 
            this.sessionNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sessionNameTextBox.Enabled = false;
            this.sessionNameTextBox.Location = new System.Drawing.Point(104, 512);
            this.sessionNameTextBox.Name = "sessionNameTextBox";
            this.sessionNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.sessionNameTextBox.TabIndex = 1;
            this.sessionNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sessionNameTextBox.TextChanged += new System.EventHandler(this.sessionNameTextBox_TextChanged);
            // 
            // sessionStatusStrip
            // 
            this.sessionStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomSourceLabel});
            this.sessionStatusStrip.Location = new System.Drawing.Point(0, 630);
            this.sessionStatusStrip.Name = "sessionStatusStrip";
            this.sessionStatusStrip.Size = new System.Drawing.Size(646, 25);
            this.sessionStatusStrip.TabIndex = 22;
            this.sessionStatusStrip.Text = "statusStrip1";
            // 
            // randomSourceLabel
            // 
            this.randomSourceLabel.Name = "randomSourceLabel";
            this.randomSourceLabel.Size = new System.Drawing.Size(145, 20);
            this.randomSourceLabel.Text = "Randomness Source:";
            this.randomSourceLabel.Click += new System.EventHandler(this.randomSourceLabel_Click);
            // 
            // notesButton
            // 
            this.notesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.notesButton.Enabled = false;
            this.notesButton.Location = new System.Drawing.Point(478, 567);
            this.notesButton.Name = "notesButton";
            this.notesButton.Size = new System.Drawing.Size(75, 23);
            this.notesButton.TabIndex = 5;
            this.notesButton.Text = "Notes";
            this.notesButton.UseVisualStyleBackColor = true;
            this.notesButton.Click += new System.EventHandler(this.notesButton_Click);
            // 
            // targetImageCheckBox
            // 
            this.targetImageCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.targetImageCheckBox.AutoSize = true;
            this.targetImageCheckBox.Enabled = false;
            this.targetImageCheckBox.Location = new System.Drawing.Point(143, 573);
            this.targetImageCheckBox.Name = "targetImageCheckBox";
            this.targetImageCheckBox.Size = new System.Drawing.Size(89, 17);
            this.targetImageCheckBox.TabIndex = 15;
            this.targetImageCheckBox.Text = "Target Image";
            this.targetImageCheckBox.UseVisualStyleBackColor = true;
            this.targetImageCheckBox.CheckedChanged += new System.EventHandler(this.targetImageCheckBox_CheckedChanged);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadButton.Location = new System.Drawing.Point(397, 596);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 14;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(478, 596);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 13;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // viewerNameTextBox
            // 
            this.viewerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewerNameTextBox.Enabled = false;
            this.viewerNameTextBox.Location = new System.Drawing.Point(104, 538);
            this.viewerNameTextBox.Name = "viewerNameTextBox";
            this.viewerNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.viewerNameTextBox.TabIndex = 3;
            this.viewerNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.viewerNameTextBox.TextChanged += new System.EventHandler(this.viewerNameTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Viewer Name:";
            // 
            // judgeNameTextBox
            // 
            this.judgeNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.judgeNameTextBox.Enabled = false;
            this.judgeNameTextBox.Location = new System.Drawing.Point(421, 538);
            this.judgeNameTextBox.Name = "judgeNameTextBox";
            this.judgeNameTextBox.Size = new System.Drawing.Size(212, 20);
            this.judgeNameTextBox.TabIndex = 4;
            this.judgeNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.judgeNameTextBox.TextChanged += new System.EventHandler(this.judgeNameTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Judge Name:";
            // 
            // arvCheckBox
            // 
            this.arvCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.arvCheckBox.AutoSize = true;
            this.arvCheckBox.Enabled = false;
            this.arvCheckBox.Location = new System.Drawing.Point(424, 573);
            this.arvCheckBox.Name = "arvCheckBox";
            this.arvCheckBox.Size = new System.Drawing.Size(48, 17);
            this.arvCheckBox.TabIndex = 32;
            this.arvCheckBox.Text = "ARV";
            this.arvCheckBox.UseVisualStyleBackColor = true;
            this.arvCheckBox.CheckedChanged += new System.EventHandler(this.arvCheckBox_CheckedChanged);
            // 
            // arvQuestionTextBox
            // 
            this.arvQuestionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvQuestionTextBox.Enabled = false;
            this.arvQuestionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvQuestionTextBox.Location = new System.Drawing.Point(132, 67);
            this.arvQuestionTextBox.Name = "arvQuestionTextBox";
            this.arvQuestionTextBox.Size = new System.Drawing.Size(503, 24);
            this.arvQuestionTextBox.TabIndex = 0;
            this.arvQuestionTextBox.Visible = false;
            this.arvQuestionTextBox.TextChanged += new System.EventHandler(this.arvQuestionTextBox_TextChanged);
            // 
            // setImageButton
            // 
            this.setImageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.setImageButton.Location = new System.Drawing.Point(205, 596);
            this.setImageButton.Name = "setImageButton";
            this.setImageButton.Size = new System.Drawing.Size(90, 23);
            this.setImageButton.TabIndex = 34;
            this.setImageButton.Text = "Set Images";
            this.setImageButton.UseVisualStyleBackColor = true;
            this.setImageButton.Click += new System.EventHandler(this.setImageButton_Click);
            // 
            // arvQuestionLabel
            // 
            this.arvQuestionLabel.AutoSize = true;
            this.arvQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arvQuestionLabel.Location = new System.Drawing.Point(9, 70);
            this.arvQuestionLabel.Name = "arvQuestionLabel";
            this.arvQuestionLabel.Size = new System.Drawing.Size(117, 18);
            this.arvQuestionLabel.TabIndex = 35;
            this.arvQuestionLabel.Text = "ARV Question:   ";
            this.arvQuestionLabel.Visible = false;
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 655);
            this.Controls.Add(this.arvQuestionLabel);
            this.Controls.Add(this.setImageButton);
            this.Controls.Add(this.arvQuestionTextBox);
            this.Controls.Add(this.arvCheckBox);
            this.Controls.Add(this.viewerNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.judgeNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.targetCheckBox);
            this.Controls.Add(this.selectionCheckBox);
            this.Controls.Add(this.idsCheckBox);
            this.Controls.Add(this.targetImageCheckBox);
            this.Controls.Add(this.imagesCheckBox);
            this.Controls.Add(this.notesButton);
            this.Controls.Add(this.sessionStatusStrip);
            this.Controls.Add(this.sessionNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addFilesButton);
            this.Controls.Add(this.sessionUUIDTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.getImagesButton);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.imagesSplitContainer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getTargetButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.targetTextBox);
            this.Controls.Add(this.label2);
            this.Name = "SessionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SessionForm_FormClosing);
            this.Load += new System.EventHandler(this.SessionForm_Load);
            this.ResizeEnd += new System.EventHandler(this.SessionForm_ResizeEnd);
            this.imagesSplitContainer.Panel1.ResumeLayout(false);
            this.imagesSplitContainer.Panel1.PerformLayout();
            this.imagesSplitContainer.Panel2.ResumeLayout(false);
            this.imagesSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagesSplitContainer)).EndInit();
            this.imagesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.sessionStatusStrip.ResumeLayout(false);
            this.sessionStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button getTargetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox imagesCheckBox;
        private System.Windows.Forms.CheckBox idsCheckBox;
        private System.Windows.Forms.CheckBox selectionCheckBox;
        private System.Windows.Forms.CheckBox targetCheckBox;
        private System.Windows.Forms.SplitContainer imagesSplitContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button viewerSelect1Button;
        private System.Windows.Forms.TextBox picBox1IDtextBox;
        private System.Windows.Forms.TextBox picBox2IDtextBox;
        private System.Windows.Forms.Button viewerSelect2Button;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button getImagesButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox sessionUUIDTextBox;
        private System.Windows.Forms.Button judgeSelect1Button;
        private System.Windows.Forms.Button judgeSelect2Button;
        private System.Windows.Forms.TextBox picBox1TargetTextBox;
        private System.Windows.Forms.TextBox picBox2TargetTextBox;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sessionNameTextBox;
        private System.Windows.Forms.StatusStrip sessionStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel randomSourceLabel;
        private System.Windows.Forms.Button notesButton;
        private System.Windows.Forms.CheckBox targetImageCheckBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox viewerNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox judgeNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox arvCheckBox;
        private System.Windows.Forms.TextBox arvQuestionTextBox;
        private System.Windows.Forms.TextBox arvAnswer1TextBox;
        private System.Windows.Forms.TextBox arvAnswer2textBox;
        private System.Windows.Forms.Button setImageButton;
        private System.Windows.Forms.Label arvQuestionLabel;
    }
}