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
    public partial class ARVSetTargetForm : Form
    {
        public ARVSetTargetForm(string arvQuestion, string arvAnswer1,
            string arvAnswer2)
        {
            InitializeComponent();
            arvQuestiontextBox.Text = arvQuestion;
            arvAnswer1textBox.Text = arvAnswer1;
            arvAnswer2textBox.Text = arvAnswer2;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void arvAnswer1textBox_Click(object sender, EventArgs e)
        {
            arvAnswer1RadioButton.Checked = true;
        }

        private void arvAnswer2textBox_Click(object sender, EventArgs e)
        {
            arvAnswer2RadioButton.Checked = true;
        }
    }
}
