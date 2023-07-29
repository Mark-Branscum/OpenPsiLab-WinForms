namespace OpenPsiLabWinForms.Views
{
    partial class ImageDownloadWebForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.webImageSavePanel = new System.Windows.Forms.Panel();
            this.notesButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageDownloadWebView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1.SuspendLayout();
            this.webImageSavePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDownloadWebView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.webImageSavePanel);
            this.panel1.Controls.Add(this.ImageDownloadWebView2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 793);
            this.panel1.TabIndex = 0;
            // 
            // webImageSavePanel
            // 
            this.webImageSavePanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.webImageSavePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webImageSavePanel.Controls.Add(this.notesButton);
            this.webImageSavePanel.Controls.Add(this.urlTextBox);
            this.webImageSavePanel.Controls.Add(this.notesTextBox);
            this.webImageSavePanel.Controls.Add(this.label2);
            this.webImageSavePanel.Controls.Add(this.nameTextBox);
            this.webImageSavePanel.Controls.Add(this.saveButton);
            this.webImageSavePanel.Controls.Add(this.label1);
            this.webImageSavePanel.Location = new System.Drawing.Point(228, 668);
            this.webImageSavePanel.Name = "webImageSavePanel";
            this.webImageSavePanel.Size = new System.Drawing.Size(564, 100);
            this.webImageSavePanel.TabIndex = 1;
            this.webImageSavePanel.Visible = false;
            // 
            // notesButton
            // 
            this.notesButton.Location = new System.Drawing.Point(434, 51);
            this.notesButton.Name = "notesButton";
            this.notesButton.Size = new System.Drawing.Size(32, 23);
            this.notesButton.TabIndex = 7;
            this.notesButton.Text = "...";
            this.notesButton.UseVisualStyleBackColor = true;
            this.notesButton.Click += new System.EventHandler(this.notesButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlTextBox.Location = new System.Drawing.Point(19, 14);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(528, 13);
            this.urlTextBox.TabIndex = 6;
            this.urlTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.Location = new System.Drawing.Point(186, 53);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(242, 20);
            this.notesTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description/Notes";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameTextBox.Location = new System.Drawing.Point(19, 53);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(161, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(472, 51);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // ImageDownloadWebView2
            // 
            this.ImageDownloadWebView2.AllowExternalDrop = true;
            this.ImageDownloadWebView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageDownloadWebView2.CreationProperties = null;
            this.ImageDownloadWebView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.ImageDownloadWebView2.Location = new System.Drawing.Point(0, -1);
            this.ImageDownloadWebView2.Name = "ImageDownloadWebView2";
            this.ImageDownloadWebView2.Size = new System.Drawing.Size(1021, 792);
            this.ImageDownloadWebView2.Source = new System.Uri("https://www.pexels.com/", System.UriKind.Absolute);
            this.ImageDownloadWebView2.TabIndex = 0;
            this.ImageDownloadWebView2.ZoomFactor = 1D;
            this.ImageDownloadWebView2.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.unsplashWebView2_NavigationCompleted);
            this.ImageDownloadWebView2.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.unsplashWebView2_SourceChanged);
            // 
            // ImageDownloadWebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 817);
            this.Controls.Add(this.panel1);
            this.Name = "ImageDownloadWebForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Images";
            this.panel1.ResumeLayout(false);
            this.webImageSavePanel.ResumeLayout(false);
            this.webImageSavePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDownloadWebView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button saveButton;
        private Microsoft.Web.WebView2.WinForms.WebView2 ImageDownloadWebView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Panel webImageSavePanel;
        private System.Windows.Forms.Button notesButton;
    }
}