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
    public partial class WebForm : Form
    {
        public WebForm(string url = "")
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(url)) goToURL(url);
        }

        public void goToURL(string sourceUrl)
        {
            try
            {
                string url;
                if (!sourceUrl.ToLower().StartsWith("https://") && !sourceUrl.ToLower().StartsWith("http://"))
                {
                    try
                    {
                        url = "https://" + sourceUrl;
                        customWebView2.Source = new Uri(url);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            url = "https://www." + sourceUrl;
                            customWebView2.Source = new Uri(url);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                url = "http://" + sourceUrl;
                                customWebView2.Source = new Uri(url);
                            }
                            catch (Exception)
                            {
                                url = "http://www." + sourceUrl;
                                customWebView2.Source = new Uri(url);
                            }
                        }
                    }
                }
                else
                {
                    customWebView2.Source = new Uri(sourceUrl);
                }
            }
            catch (Exception)
            {
                //Ignore
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            customWebView2.GoForward();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            customWebView2.GoBack();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            goToURL(urlTextBox.Text);
        }

        private void customWebView2_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            urlTextBox.Text = customWebView2.Source.ToString();
        }

        private void urlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                goToURL(urlTextBox.Text);
            }
        }
    }
}
