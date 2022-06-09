using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms
{
    public partial class SettingsForm : Form
    {
        private OPLConfiguration oplConfig { get; set; }

        public SettingsForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            LongitudeTextBox.Text = oplConfig.Longitude;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                serialPortComboBox.Items.Add(port);
            }
            ComboBox spc = serialPortComboBox;
            if (spc.Items.Count > 0)
            {
                bool portFound = false;
                foreach (object item in spc.Items)
                {
                    if (item.ToString().Trim().ToLower()
                        == oplConfig.RNGSerialPortName.Trim().ToLower())
                    {
                        spc.SelectedItem = item;
                        portFound = true;
                        break;
                    }
                }
                if (portFound == false)
                {
                    spc.SelectedIndex = 0;
                }
            }
            ComboBox rcb = randomSourceComboBox;
            bool randFound = false;
            foreach (object item in rcb.Items)
            {
                if (item.ToString().Trim().ToLower()
                    == oplConfig.RandomnessSource.Trim().ToLower())
                {
                    rcb.SelectedItem = item;
                    randFound = true;
                    break;
                }
            }
            if (randFound == false)
            {
                rcb.SelectedIndex = 0;
            }
            Refresh();
            if (rcb.SelectedItem.ToString().Trim().ToLower() == "truerng")
            {
                spc.Enabled = true;
            }
            else
            {
                spc.Enabled = false;
            }
            highlightColorButton.BackColor = oplConfig.HighlightColor;
            Refresh();
            oplConfig = oplConfig;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            double longitude;
            try
            {
                longitude = double.Parse(LongitudeTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(owner: this, text: "Error: Longitude must be a double. " +
                    "Values have not been saved.",
                    caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            oplConfig.Longitude = longitude.ToString();
            oplConfig.RandomnessSource = randomSourceComboBox.SelectedItem.ToString();
            oplConfig.RNGSerialPortName = serialPortComboBox.SelectedItem.ToString();
            Settings.Default.Save();
            Close();
        }

        private void randomSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox rcb = randomSourceComboBox;
            ComboBox spc = serialPortComboBox;
            if (rcb.SelectedItem.ToString().Trim().ToLower() == "truerng")
            {
                spc.Enabled = true;
                trueRNGButton.Visible = true;
            }
            else
            {
                spc.Enabled = false;
                trueRNGButton.Visible = false;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void sessionDiscardCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void highlightColorButton_Click(object sender, EventArgs e)
        {
            DialogResult dlg = highlightColorDialog.ShowDialog();
            oplConfig.HighlightColor = highlightColorDialog.Color;
            highlightColorButton.BackColor = highlightColorDialog.Color;
        }

        private void trueRNGButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "https://ubld.it/products/truerng-hardware-random-number-generator/");
        }
    }
}
