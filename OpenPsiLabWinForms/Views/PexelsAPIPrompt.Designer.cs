namespace OpenPsiLabWinForms.Views
{
    partial class PexelsAPIPrompt
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.apiKeyTbx = new System.Windows.Forms.TextBox();
            this.continueBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveConfigFileCbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(471, 74);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Please insert your Pexels API key.  To get an API key go to https://www.pexels.co" +
    "m/api/ and click the Get Started button.";
            // 
            // apiKeyTbx
            // 
            this.apiKeyTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiKeyTbx.Location = new System.Drawing.Point(13, 93);
            this.apiKeyTbx.Name = "apiKeyTbx";
            this.apiKeyTbx.Size = new System.Drawing.Size(470, 20);
            this.apiKeyTbx.TabIndex = 1;
            // 
            // continueBtn
            // 
            this.continueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.continueBtn.Location = new System.Drawing.Point(408, 128);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(75, 23);
            this.continueBtn.TabIndex = 2;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(327, 128);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveConfigFileCbx
            // 
            this.saveConfigFileCbx.AutoSize = true;
            this.saveConfigFileCbx.Location = new System.Drawing.Point(13, 128);
            this.saveConfigFileCbx.Name = "saveConfigFileCbx";
            this.saveConfigFileCbx.Size = new System.Drawing.Size(115, 17);
            this.saveConfigFileCbx.TabIndex = 3;
            this.saveConfigFileCbx.Text = "Save to Config File";
            this.saveConfigFileCbx.UseVisualStyleBackColor = true;
            // 
            // PexelsAPIPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 169);
            this.Controls.Add(this.saveConfigFileCbx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.apiKeyTbx);
            this.Controls.Add(this.textBox1);
            this.Name = "PexelsAPIPrompt";
            this.Text = "Pexels API Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Button cancelBtn;
        public System.Windows.Forms.TextBox apiKeyTbx;
        private System.Windows.Forms.CheckBox saveConfigFileCbx;
    }
}