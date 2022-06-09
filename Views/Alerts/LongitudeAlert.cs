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

namespace OpenPsiLabWinForms.Views.Alerts
{
    public partial class LongitudeAlert : Form
    {
        private OPLConfiguration oplConfig;

        public LongitudeAlert(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            double? longitude = null;
            try
            {
                if (string.IsNullOrWhiteSpace(longitudeTextBox.Text.Trim()))
                {
                    oplConfig.Longitude = "0.0";
                }
                else
                {
                    longitude = double.Parse(longitudeTextBox.Text.Trim());
                    oplConfig.Longitude = longitude.ToString();
                }
                
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid longitude format.",
                    "Error", MessageBoxButtons.OK);
            }
            
        }
    }
}
