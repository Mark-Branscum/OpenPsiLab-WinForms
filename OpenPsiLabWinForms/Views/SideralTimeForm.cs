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
using OpenPsiLabWinForms.Views;

namespace OpenPsiLabWinForms
{
    public partial class SideralTimeForm : Form
    {
        private SiderealTimeUtilities sideTimeUtils;
        private DateTimeOffset? side1300 = null;
        private OPLConfiguration oplConfig;

        public SideralTimeForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;
            ClockTimer.Interval = 1000;
            ClockTimer.Enabled = true;
            sideTimeUtils = new SiderealTimeUtilities();
            hourOffsetErrorLabel.Text = "";
            longitudeErrorLabel.Text = "";
            longitudeTextBox.Text = oplConfig.Longitude;
            siderealTimeValueLabel.Text = "";
        }

        private void FormSideralTime_Load(object sender, EventArgs e)
        {

        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {           
            double longitude;

            try //Get longitude
            {
                longitude = double.Parse(longitudeTextBox.Text);
                longitudeErrorLabel.Text = "";
            }
            catch (Exception)
            {
                longitudeErrorLabel.Text = "Error: Longitude must be a double.";
                return;
            }

            if (currentTimeRadioButton.Checked)
            {
                localTimeErrorLabel.Text = "";
                DateTimeOffset nowDateTime = DateTimeOffset.Now;
                string nowString = nowDateTime.ToString();
                nowString = nowString.Substring(0, nowString.Length - 7);
                localTimeTextBox.Text = nowString;
                hourOffsetTextBox.Text = nowDateTime.Offset.TotalHours.ToString();

                siderealTimeValueLabel.Text = 
                sideTimeUtils.getSiderealTime(nowDateTime, longitude).ToString("HH:mm:ss");
                side1300 = sideTimeUtils.getSidereal1300(nowDateTime, longitude);
                string side1300Minute = side1300.Value.Minute.ToString();
                if (side1300.Value.Minute < 10) side1300Minute = "0" + side1300Minute;
                sidereal1300ValueLabel.Text =
                    $"{side1300.Value.Hour}:{side1300Minute} solar time";

            }
            else if (customTimeRadioButton.Checked)
            {
                return;
            }
        }

        private void currentTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (currentTimeRadioButton.Checked)
            {
                localTimeTextBox.ReadOnly = true;
                hourOffsetTextBox.ReadOnly = true;
                longitudeTextBox.ReadOnly = true;
                calculateButton.Enabled = false;
            }
            else if (!currentTimeRadioButton.Checked)
            {
                localTimeTextBox.ReadOnly = false;
                hourOffsetTextBox.ReadOnly = false;
                longitudeTextBox.ReadOnly = false;
                calculateButton.Enabled = true;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            int hourOffsetFromUTC;
            double longitude;
            DateTime customDateTime;

            try
            {
                customDateTime = DateTime.Parse(localTimeTextBox.Text);
                localTimeErrorLabel.Text = "";
            }
            catch (Exception)
            {
                localTimeErrorLabel.Text = "Error: Unable to parse local time.";
                return;
            }

            try //Get hour offset
            {
                hourOffsetFromUTC = int.Parse(hourOffsetTextBox.Text);
                hourOffsetErrorLabel.Text = "";
            }
            catch (Exception)
            {
                //Write error label
                hourOffsetErrorLabel.Text = "Error: Hour Offset must be an integer.";
                return;
            }

            try //Get longitude
            {
                longitude = double.Parse(longitudeTextBox.Text);
                longitudeErrorLabel.Text = "";
            }
            catch (Exception)
            {
                longitudeErrorLabel.Text = "Error: Longitude must be a double.";
                return;
            }

            DateTime cdt = customDateTime;
            DateTimeOffset customDTO = 
                new DateTimeOffset(year: cdt.Year, month: cdt.Month, day: cdt.Day,
                    hour: cdt.Hour, minute: cdt.Minute, second: cdt.Second, 
                    offset: new TimeSpan(days: 0, hours: hourOffsetFromUTC, 
                        minutes: 0, seconds: 0));

            siderealTimeValueLabel.Text =
            sideTimeUtils.getSiderealTime(customDTO, longitude).ToString("HH:mm:ss");

            side1300 = sideTimeUtils.getSidereal1300(customDTO, longitude);
            sidereal1300ValueLabel.Text =
                $"{side1300.Value.Hour}:{side1300.Value.Minute} solar time";

        }

        private void usnoCalcButton_Click(object sender, EventArgs e)
        {
            WebForm wf = new WebForm();
            wf.goToURL("https://aa.usno.navy.mil/data/siderealtime");
            wf.Show();
        }

        private void usnoTechButton_Click(object sender, EventArgs e)
        {
            WebForm wf = new WebForm();
            wf.goToURL("https://aa.usno.navy.mil/faq/GAST");
            wf.Show();
        }
    }
}
