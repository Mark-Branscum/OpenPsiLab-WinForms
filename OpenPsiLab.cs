using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views.Alerts;

namespace OpenPsiLabWinForms
{
    internal static class OpenPsiLab
    {
        private static string programVersion = "0.0.001";
        private static string databaseVersion = "0.0.001";
        public static OPLConfiguration oplConfig;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                oplConfig = new OPLConfiguration();
                if (!File.Exists("OPLConfig.json"))
                {
                    oplConfig.InitializeNewConfig();
                }

                string configJson = File.ReadAllText("OPLConfig.json");
                JsonSerializerOptions opts = new JsonSerializerOptions()
                {
                    Converters = {
                        new ColorJsonConverter()
                    }
                };
                oplConfig = JsonSerializer.Deserialize<OPLConfiguration>(configJson, opts);

                SQLiteDatabase db = new SQLiteDatabase(oplConfig);
                db.DatabaseVersionSave(databaseVersion);
                db.ProgramVersionSave(programVersion);
                
                oplConfig.SoftwareVersion = programVersion;
                Application.Run(new MainForm(oplConfig));
            }
            catch (Exception e)
            {
                string message = "Fatal Error Encountered.  If you would like " +
                                 "to send the following information to the developers it will " +
                                 "help diagnose the issue. Please also include a description " +
                                 "of the steps that led up to the error in order to help " +
                                 "the developers recreate the error.\r\n\r\n";
                message += e.Message + "\r\n\r\n";
                message += e.StackTrace;
                ErrorForm ef = new ErrorForm(message);
                ef.ShowDialog();
                Environment.Exit(-1);
            }
            
        }
    }
}
