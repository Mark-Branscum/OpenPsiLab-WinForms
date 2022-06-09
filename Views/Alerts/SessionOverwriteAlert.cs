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
    public partial class SessionOverwriteAlertForm : Form
    {
        public string CustomDialogResult { get; set; }
        public SessionOverwriteAlertForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void overwriteButton_Click(object sender, EventArgs e)
        {
            CustomDialogResult = "overwrite";
            DialogResult = DialogResult.OK;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CustomDialogResult = "create";
            DialogResult = DialogResult.OK;
        }
    }
}
