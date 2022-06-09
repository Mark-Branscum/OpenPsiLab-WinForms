namespace OpenPsiLabWinForms
{
    partial class SettingsForm
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
            this.LongitudeTextBox = new System.Windows.Forms.TextBox();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.settingsOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.randomSourceComboBox = new System.Windows.Forms.ComboBox();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.highlightColorDialog = new System.Windows.Forms.ColorDialog();
            this.highlightColorButton = new System.Windows.Forms.Button();
            this.trueRNGButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LongitudeTextBox.Location = new System.Drawing.Point(12, 25);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(277, 20);
            this.LongitudeTextBox.TabIndex = 0;
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(12, 9);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(54, 13);
            this.LongitudeLabel.TabIndex = 1;
            this.LongitudeLabel.Text = "Longitude";
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSettingsButton.Location = new System.Drawing.Point(214, 145);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveSettingsButton.TabIndex = 2;
            this.SaveSettingsButton.Text = "Save";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // settingsOpenFileDialog
            // 
            this.settingsOpenFileDialog.FileName = "openFileDialog1";
            this.settingsOpenFileDialog.InitialDirectory = "Resources";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Randomness Source";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serial Port";
            // 
            // randomSourceComboBox
            // 
            this.randomSourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomSourceComboBox.FormattingEnabled = true;
            this.randomSourceComboBox.Items.AddRange(new object[] {
            "Random.org",
            "Pseudo",
            "TrueRNG"});
            this.randomSourceComboBox.Location = new System.Drawing.Point(12, 102);
            this.randomSourceComboBox.Name = "randomSourceComboBox";
            this.randomSourceComboBox.Size = new System.Drawing.Size(157, 21);
            this.randomSourceComboBox.TabIndex = 8;
            this.randomSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.randomSourceComboBox_SelectedIndexChanged);
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serialPortComboBox.Enabled = false;
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(12, 147);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(157, 21);
            this.serialPortComboBox.TabIndex = 9;
            // 
            // highlightColorButton
            // 
            this.highlightColorButton.Location = new System.Drawing.Point(12, 55);
            this.highlightColorButton.Name = "highlightColorButton";
            this.highlightColorButton.Size = new System.Drawing.Size(106, 23);
            this.highlightColorButton.TabIndex = 12;
            this.highlightColorButton.Text = "Highlight Color";
            this.highlightColorButton.UseVisualStyleBackColor = true;
            this.highlightColorButton.Click += new System.EventHandler(this.highlightColorButton_Click);
            // 
            // trueRNGButton
            // 
            this.trueRNGButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trueRNGButton.Location = new System.Drawing.Point(175, 100);
            this.trueRNGButton.Name = "trueRNGButton";
            this.trueRNGButton.Size = new System.Drawing.Size(116, 23);
            this.trueRNGButton.TabIndex = 13;
            this.trueRNGButton.Text = "Buy TrueRNG";
            this.trueRNGButton.UseVisualStyleBackColor = true;
            this.trueRNGButton.Visible = false;
            this.trueRNGButton.Click += new System.EventHandler(this.trueRNGButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 187);
            this.Controls.Add(this.trueRNGButton);
            this.Controls.Add(this.highlightColorButton);
            this.Controls.Add(this.serialPortComboBox);
            this.Controls.Add(this.randomSourceComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.LongitudeLabel);
            this.Controls.Add(this.LongitudeTextBox);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LongitudeTextBox;
        private System.Windows.Forms.Label LongitudeLabel;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.OpenFileDialog settingsOpenFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox randomSourceComboBox;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.ColorDialog highlightColorDialog;
        private System.Windows.Forms.Button highlightColorButton;
        private System.Windows.Forms.Button trueRNGButton;
    }
}