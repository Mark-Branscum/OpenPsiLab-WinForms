using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPsiLabWinForms.Views
{
    public partial class PexelsAPIPrompt : Form
    {
        public string UserInput { get; set; }
        public bool SaveToConfig { get; set; }

        public PexelsAPIPrompt()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            this.UserInput = this.apiKeyTbx.Text;
            this.SaveToConfig = this.saveConfigFileCbx.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
