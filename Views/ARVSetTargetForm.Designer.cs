namespace OpenPsiLabWinForms.Views
{
    partial class ARVSetTargetForm
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
            this.arvQuestiontextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.arvAnswer2RadioButton = new System.Windows.Forms.RadioButton();
            this.arvAnswer2textBox = new System.Windows.Forms.TextBox();
            this.arvAnswer1RadioButton = new System.Windows.Forms.RadioButton();
            this.arvAnswer1textBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // arvQuestiontextBox
            // 
            this.arvQuestiontextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvQuestiontextBox.Location = new System.Drawing.Point(12, 83);
            this.arvQuestiontextBox.Name = "arvQuestiontextBox";
            this.arvQuestiontextBox.ReadOnly = true;
            this.arvQuestiontextBox.Size = new System.Drawing.Size(492, 20);
            this.arvQuestiontextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick the answer below that correctly answers the ARV question.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ARV Question:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.arvAnswer2RadioButton);
            this.groupBox1.Controls.Add(this.arvAnswer2textBox);
            this.groupBox1.Controls.Add(this.arvAnswer1RadioButton);
            this.groupBox1.Controls.Add(this.arvAnswer1textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set ARV Answer";
            // 
            // arvAnswer2RadioButton
            // 
            this.arvAnswer2RadioButton.AutoSize = true;
            this.arvAnswer2RadioButton.Location = new System.Drawing.Point(6, 87);
            this.arvAnswer2RadioButton.Name = "arvAnswer2RadioButton";
            this.arvAnswer2RadioButton.Size = new System.Drawing.Size(14, 13);
            this.arvAnswer2RadioButton.TabIndex = 7;
            this.arvAnswer2RadioButton.TabStop = true;
            this.arvAnswer2RadioButton.UseVisualStyleBackColor = true;
            // 
            // arvAnswer2textBox
            // 
            this.arvAnswer2textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvAnswer2textBox.Location = new System.Drawing.Point(26, 84);
            this.arvAnswer2textBox.Name = "arvAnswer2textBox";
            this.arvAnswer2textBox.ReadOnly = true;
            this.arvAnswer2textBox.Size = new System.Drawing.Size(460, 20);
            this.arvAnswer2textBox.TabIndex = 6;
            this.arvAnswer2textBox.Click += new System.EventHandler(this.arvAnswer2textBox_Click);
            // 
            // arvAnswer1RadioButton
            // 
            this.arvAnswer1RadioButton.AutoSize = true;
            this.arvAnswer1RadioButton.Location = new System.Drawing.Point(6, 31);
            this.arvAnswer1RadioButton.Name = "arvAnswer1RadioButton";
            this.arvAnswer1RadioButton.Size = new System.Drawing.Size(14, 13);
            this.arvAnswer1RadioButton.TabIndex = 5;
            this.arvAnswer1RadioButton.TabStop = true;
            this.arvAnswer1RadioButton.UseVisualStyleBackColor = true;
            // 
            // arvAnswer1textBox
            // 
            this.arvAnswer1textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arvAnswer1textBox.Location = new System.Drawing.Point(26, 28);
            this.arvAnswer1textBox.Name = "arvAnswer1textBox";
            this.arvAnswer1textBox.ReadOnly = true;
            this.arvAnswer1textBox.Size = new System.Drawing.Size(460, 20);
            this.arvAnswer1textBox.TabIndex = 4;
            this.arvAnswer1textBox.Click += new System.EventHandler(this.arvAnswer1textBox_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(429, 286);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(348, 286);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ARVSetTargetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 321);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arvQuestiontextBox);
            this.Name = "ARVSetTargetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARV Set Target";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox arvQuestiontextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox arvAnswer2textBox;
        private System.Windows.Forms.TextBox arvAnswer1textBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.RadioButton arvAnswer2RadioButton;
        public System.Windows.Forms.RadioButton arvAnswer1RadioButton;
    }
}