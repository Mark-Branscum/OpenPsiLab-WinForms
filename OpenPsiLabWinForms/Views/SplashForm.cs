using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Views
{
    public partial class SplashForm : Form
    {
        private OPLConfiguration oplConfig;
        public SplashForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            okButton.Select();
            oplConfig = oplConfiguration;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (dontShowCheckBox.Checked == true)
                oplConfig.SupressSplashScreen = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
