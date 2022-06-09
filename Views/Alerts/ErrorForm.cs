using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenPsiLabWinForms.Views.Alerts
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errorMessage)
        {
            InitializeComponent();

            errorTextBox.Text = errorMessage;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
