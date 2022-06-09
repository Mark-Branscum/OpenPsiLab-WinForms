namespace OpenPsiLabWinForms
{
    partial class SideralTimeForm
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
            this.components = new System.ComponentModel.Container();
            this.localTimeLabel = new System.Windows.Forms.Label();
            this.hourOffsetLabelCaption = new System.Windows.Forms.Label();
            this.hourOffsetTextBox = new System.Windows.Forms.TextBox();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.hourOffsetErrorLabel = new System.Windows.Forms.Label();
            this.longitudeCaptionLabel = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.siderealCaptionLabel = new System.Windows.Forms.Label();
            this.siderealTimeValueLabel = new System.Windows.Forms.Label();
            this.localTimeTextBox = new System.Windows.Forms.TextBox();
            this.currentCustomGroupBox = new System.Windows.Forms.GroupBox();
            this.usnoGroupBox = new System.Windows.Forms.GroupBox();
            this.usnoTechButton = new System.Windows.Forms.Button();
            this.usnoCalcButton = new System.Windows.Forms.Button();
            this.sidereal1300ValueLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.sidereal1300CaptionLabel = new System.Windows.Forms.Label();
            this.customTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.localTimeErrorLabel = new System.Windows.Forms.Label();
            this.currentTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.longitudeErrorLabel = new System.Windows.Forms.Label();
            this.currentCustomGroupBox.SuspendLayout();
            this.usnoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // localTimeLabel
            // 
            this.localTimeLabel.AutoSize = true;
            this.localTimeLabel.Location = new System.Drawing.Point(6, 53);
            this.localTimeLabel.Name = "localTimeLabel";
            this.localTimeLabel.Size = new System.Drawing.Size(59, 13);
            this.localTimeLabel.TabIndex = 0;
            this.localTimeLabel.Text = "Local Time";
            // 
            // hourOffsetLabelCaption
            // 
            this.hourOffsetLabelCaption.AutoSize = true;
            this.hourOffsetLabelCaption.Location = new System.Drawing.Point(6, 148);
            this.hourOffsetLabelCaption.Name = "hourOffsetLabelCaption";
            this.hourOffsetLabelCaption.Size = new System.Drawing.Size(109, 13);
            this.hourOffsetLabelCaption.TabIndex = 2;
            this.hourOffsetLabelCaption.Text = "Hour Offset from UTC";
            // 
            // hourOffsetTextBox
            // 
            this.hourOffsetTextBox.Location = new System.Drawing.Point(9, 165);
            this.hourOffsetTextBox.Name = "hourOffsetTextBox";
            this.hourOffsetTextBox.ReadOnly = true;
            this.hourOffsetTextBox.Size = new System.Drawing.Size(42, 20);
            this.hourOffsetTextBox.TabIndex = 3;
            // 
            // ClockTimer
            // 
            this.ClockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            // 
            // hourOffsetErrorLabel
            // 
            this.hourOffsetErrorLabel.AutoSize = true;
            this.hourOffsetErrorLabel.Location = new System.Drawing.Point(58, 171);
            this.hourOffsetErrorLabel.Name = "hourOffsetErrorLabel";
            this.hourOffsetErrorLabel.Size = new System.Drawing.Size(78, 13);
            this.hourOffsetErrorLabel.TabIndex = 4;
            this.hourOffsetErrorLabel.Text = "hourOffsetError";
            // 
            // longitudeCaptionLabel
            // 
            this.longitudeCaptionLabel.AutoSize = true;
            this.longitudeCaptionLabel.Location = new System.Drawing.Point(6, 199);
            this.longitudeCaptionLabel.Name = "longitudeCaptionLabel";
            this.longitudeCaptionLabel.Size = new System.Drawing.Size(54, 13);
            this.longitudeCaptionLabel.TabIndex = 5;
            this.longitudeCaptionLabel.Text = "Longitude";
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeTextBox.Location = new System.Drawing.Point(9, 216);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.ReadOnly = true;
            this.longitudeTextBox.Size = new System.Drawing.Size(292, 20);
            this.longitudeTextBox.TabIndex = 6;
            // 
            // siderealCaptionLabel
            // 
            this.siderealCaptionLabel.AutoSize = true;
            this.siderealCaptionLabel.Location = new System.Drawing.Point(9, 102);
            this.siderealCaptionLabel.Name = "siderealCaptionLabel";
            this.siderealCaptionLabel.Size = new System.Drawing.Size(71, 13);
            this.siderealCaptionLabel.TabIndex = 7;
            this.siderealCaptionLabel.Text = "Sidereal Time";
            // 
            // siderealTimeValueLabel
            // 
            this.siderealTimeValueLabel.AutoSize = true;
            this.siderealTimeValueLabel.Location = new System.Drawing.Point(9, 119);
            this.siderealTimeValueLabel.Name = "siderealTimeValueLabel";
            this.siderealTimeValueLabel.Size = new System.Drawing.Size(71, 13);
            this.siderealTimeValueLabel.TabIndex = 8;
            this.siderealTimeValueLabel.Text = "Sidereal Time";
            // 
            // localTimeTextBox
            // 
            this.localTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localTimeTextBox.Location = new System.Drawing.Point(9, 70);
            this.localTimeTextBox.Name = "localTimeTextBox";
            this.localTimeTextBox.ReadOnly = true;
            this.localTimeTextBox.Size = new System.Drawing.Size(281, 20);
            this.localTimeTextBox.TabIndex = 9;
            // 
            // currentCustomGroupBox
            // 
            this.currentCustomGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentCustomGroupBox.Controls.Add(this.usnoGroupBox);
            this.currentCustomGroupBox.Controls.Add(this.sidereal1300ValueLabel);
            this.currentCustomGroupBox.Controls.Add(this.calculateButton);
            this.currentCustomGroupBox.Controls.Add(this.sidereal1300CaptionLabel);
            this.currentCustomGroupBox.Controls.Add(this.customTimeRadioButton);
            this.currentCustomGroupBox.Controls.Add(this.localTimeErrorLabel);
            this.currentCustomGroupBox.Controls.Add(this.currentTimeRadioButton);
            this.currentCustomGroupBox.Controls.Add(this.longitudeErrorLabel);
            this.currentCustomGroupBox.Controls.Add(this.localTimeTextBox);
            this.currentCustomGroupBox.Controls.Add(this.siderealTimeValueLabel);
            this.currentCustomGroupBox.Controls.Add(this.hourOffsetLabelCaption);
            this.currentCustomGroupBox.Controls.Add(this.siderealCaptionLabel);
            this.currentCustomGroupBox.Controls.Add(this.hourOffsetTextBox);
            this.currentCustomGroupBox.Controls.Add(this.localTimeLabel);
            this.currentCustomGroupBox.Controls.Add(this.hourOffsetErrorLabel);
            this.currentCustomGroupBox.Controls.Add(this.longitudeCaptionLabel);
            this.currentCustomGroupBox.Controls.Add(this.longitudeTextBox);
            this.currentCustomGroupBox.Location = new System.Drawing.Point(15, 19);
            this.currentCustomGroupBox.Name = "currentCustomGroupBox";
            this.currentCustomGroupBox.Size = new System.Drawing.Size(314, 316);
            this.currentCustomGroupBox.TabIndex = 10;
            this.currentCustomGroupBox.TabStop = false;
            this.currentCustomGroupBox.Text = "Sidereal Time Mode";
            // 
            // usnoGroupBox
            // 
            this.usnoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usnoGroupBox.Controls.Add(this.usnoTechButton);
            this.usnoGroupBox.Controls.Add(this.usnoCalcButton);
            this.usnoGroupBox.Location = new System.Drawing.Point(12, 254);
            this.usnoGroupBox.Name = "usnoGroupBox";
            this.usnoGroupBox.Size = new System.Drawing.Size(174, 49);
            this.usnoGroupBox.TabIndex = 15;
            this.usnoGroupBox.TabStop = false;
            this.usnoGroupBox.Text = "USNO Sidereal Info";
            // 
            // usnoTechButton
            // 
            this.usnoTechButton.Location = new System.Drawing.Point(88, 19);
            this.usnoTechButton.Name = "usnoTechButton";
            this.usnoTechButton.Size = new System.Drawing.Size(75, 23);
            this.usnoTechButton.TabIndex = 1;
            this.usnoTechButton.Text = "Technical";
            this.usnoTechButton.UseVisualStyleBackColor = true;
            this.usnoTechButton.Click += new System.EventHandler(this.usnoTechButton_Click);
            // 
            // usnoCalcButton
            // 
            this.usnoCalcButton.Location = new System.Drawing.Point(7, 19);
            this.usnoCalcButton.Name = "usnoCalcButton";
            this.usnoCalcButton.Size = new System.Drawing.Size(75, 23);
            this.usnoCalcButton.TabIndex = 0;
            this.usnoCalcButton.Text = "Calculator";
            this.usnoCalcButton.UseVisualStyleBackColor = true;
            this.usnoCalcButton.Click += new System.EventHandler(this.usnoCalcButton_Click);
            // 
            // sidereal1300ValueLabel
            // 
            this.sidereal1300ValueLabel.AutoSize = true;
            this.sidereal1300ValueLabel.Location = new System.Drawing.Point(101, 119);
            this.sidereal1300ValueLabel.Name = "sidereal1300ValueLabel";
            this.sidereal1300ValueLabel.Size = new System.Drawing.Size(71, 13);
            this.sidereal1300ValueLabel.TabIndex = 14;
            this.sidereal1300ValueLabel.Text = "Sidereal Time";
            // 
            // calculateButton
            // 
            this.calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateButton.Enabled = false;
            this.calculateButton.Location = new System.Drawing.Point(213, 273);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(86, 23);
            this.calculateButton.TabIndex = 2;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // sidereal1300CaptionLabel
            // 
            this.sidereal1300CaptionLabel.AutoSize = true;
            this.sidereal1300CaptionLabel.Location = new System.Drawing.Point(101, 102);
            this.sidereal1300CaptionLabel.Name = "sidereal1300CaptionLabel";
            this.sidereal1300CaptionLabel.Size = new System.Drawing.Size(72, 13);
            this.sidereal1300CaptionLabel.TabIndex = 13;
            this.sidereal1300CaptionLabel.Text = "Sidereal 1300";
            // 
            // customTimeRadioButton
            // 
            this.customTimeRadioButton.AutoSize = true;
            this.customTimeRadioButton.Location = new System.Drawing.Point(100, 25);
            this.customTimeRadioButton.Name = "customTimeRadioButton";
            this.customTimeRadioButton.Size = new System.Drawing.Size(86, 17);
            this.customTimeRadioButton.TabIndex = 1;
            this.customTimeRadioButton.Text = "Custom Time";
            this.customTimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // localTimeErrorLabel
            // 
            this.localTimeErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localTimeErrorLabel.AutoSize = true;
            this.localTimeErrorLabel.Location = new System.Drawing.Point(142, 54);
            this.localTimeErrorLabel.Name = "localTimeErrorLabel";
            this.localTimeErrorLabel.Size = new System.Drawing.Size(157, 13);
            this.localTimeErrorLabel.TabIndex = 12;
            this.localTimeErrorLabel.Text = "Error: Unable to parse local time";
            // 
            // currentTimeRadioButton
            // 
            this.currentTimeRadioButton.AutoSize = true;
            this.currentTimeRadioButton.Checked = true;
            this.currentTimeRadioButton.Location = new System.Drawing.Point(9, 25);
            this.currentTimeRadioButton.Name = "currentTimeRadioButton";
            this.currentTimeRadioButton.Size = new System.Drawing.Size(85, 17);
            this.currentTimeRadioButton.TabIndex = 0;
            this.currentTimeRadioButton.TabStop = true;
            this.currentTimeRadioButton.Text = "Current Time";
            this.currentTimeRadioButton.UseVisualStyleBackColor = true;
            this.currentTimeRadioButton.CheckedChanged += new System.EventHandler(this.currentTimeRadioButton_CheckedChanged);
            // 
            // longitudeErrorLabel
            // 
            this.longitudeErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.longitudeErrorLabel.AutoSize = true;
            this.longitudeErrorLabel.Location = new System.Drawing.Point(132, 199);
            this.longitudeErrorLabel.Name = "longitudeErrorLabel";
            this.longitudeErrorLabel.Size = new System.Drawing.Size(169, 13);
            this.longitudeErrorLabel.TabIndex = 11;
            this.longitudeErrorLabel.Text = "Error: Longitude must be a double.";
            // 
            // SideralTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 350);
            this.Controls.Add(this.currentCustomGroupBox);
            this.Name = "SideralTimeForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sideral Time";
            this.Load += new System.EventHandler(this.FormSideralTime_Load);
            this.currentCustomGroupBox.ResumeLayout(false);
            this.currentCustomGroupBox.PerformLayout();
            this.usnoGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label localTimeLabel;
        private System.Windows.Forms.Label hourOffsetLabelCaption;
        private System.Windows.Forms.TextBox hourOffsetTextBox;
        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.Label hourOffsetErrorLabel;
        private System.Windows.Forms.Label longitudeCaptionLabel;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.Label siderealCaptionLabel;
        private System.Windows.Forms.Label siderealTimeValueLabel;
        private System.Windows.Forms.TextBox localTimeTextBox;
        private System.Windows.Forms.GroupBox currentCustomGroupBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.RadioButton customTimeRadioButton;
        private System.Windows.Forms.RadioButton currentTimeRadioButton;
        private System.Windows.Forms.Label longitudeErrorLabel;
        private System.Windows.Forms.Label localTimeErrorLabel;
        private System.Windows.Forms.Label sidereal1300ValueLabel;
        private System.Windows.Forms.Label sidereal1300CaptionLabel;
        private System.Windows.Forms.GroupBox usnoGroupBox;
        private System.Windows.Forms.Button usnoTechButton;
        private System.Windows.Forms.Button usnoCalcButton;
    }
}