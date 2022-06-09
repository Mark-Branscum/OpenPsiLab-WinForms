using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenPsiLabWinForms.Controllers;

namespace OpenPsiLabWinForms.Models
{
    public class OPLConfiguration
    {
        private string _loadSessionPath;
        public string LoadSessionPath
        {
            get
            {
                return _loadSessionPath;
            }
            set
            {
                _loadSessionPath = value;
                Save();
            }
        }

        private string _exportSessionPath;
        public string ExportSessionPath
        {
            get
            {
                return _exportSessionPath;
            }
            set
            {
                _exportSessionPath = value;
                Save();
            }
        }

        private string _addImagePath;
        public string AddImagePath
        {
            get
            {
                return _addImagePath;
            }
            set
            {
                _addImagePath = value;
                Save();
            }
        }

        private string _imageFolderPath;
        public string ImageFolderPath
        {
            get
            {
                return _imageFolderPath;
            }
            set
            {
                _imageFolderPath = value;
                Save();
            }
        }

        private string _addFilePath;
        public string AddFilePath
        {
            get
            {
                return _addFilePath;
            }
            set
            {
                _addFilePath = value;
                Save();
            }
        }

        private string _longitude;
        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
                Save();
            }
        }
        private string _sqlLiteDatabasePath;
        public string SQLiteDatabasePath
        {
            get
            {
                return _sqlLiteDatabasePath;
            }
            set
            {
                _sqlLiteDatabasePath = value;
                Save();
            }
        }
        private string _rngSerialPortName;
        public string RNGSerialPortName
        {
            get
            {
                return _rngSerialPortName;
            }
            set
            {
                _rngSerialPortName = value;
                Save();
            }
        }
        private string _randomnessSource;
        public string RandomnessSource
        {
            get
            {
                return _randomnessSource;
            }
            set
            {
                _randomnessSource = value;
                Save();
                OnRaisePropertyChangedEvent(
                    new CustomEventArgs("RandomnessSource", value));
            }
        }

        private SessionExportConfiguration _sessionExportConfig;
        public SessionExportConfiguration SessionExportConfig
        {
            get
            {
                return _sessionExportConfig;
            }
            set
            {
                _sessionExportConfig = value;
                Save();
            }
        }

        private System.Drawing.Color _highlightColor;
        public System.Drawing.Color HighlightColor
        {
            get
            {
                return _highlightColor;
            }
            set
            {
                _highlightColor = value;
                Save();
            }
        }

        private bool _supressSplashScreen;
        public bool SupressSplashScreen
        {
            get
            {
                return _supressSplashScreen;
            }
            set
            {
                _supressSplashScreen = value;
                Save();
            }
        }

        private string _softwareVersion;
        public string SoftwareVersion
        {
            get
            {
                return _softwareVersion;
            }
            set
            {
                _softwareVersion = value;
                Save();
            }
        }


        public event EventHandler<CustomEventArgs> RaisePropertyChangedEvent;

        public void InitializeNewConfig()
        {
           
            string currentDir = Directory.GetCurrentDirectory();
            //string slash = Path.DirectorySeparatorChar.ToString();
            ImageFolderPath = Path.Combine(currentDir, "Images");
            if (!Directory.Exists(ImageFolderPath))
                Directory.CreateDirectory(ImageFolderPath);
            SQLiteDatabasePath = Path.Combine(currentDir,
                "Database", "OpenPsiLabData.db");
            RNGSerialPortName = "COM1";
            RandomnessSource = "Random.org";
            AddFilePath = currentDir;
            AddImagePath = currentDir;
            LoadSessionPath = currentDir;
            ExportSessionPath = currentDir;

            SessionExportConfiguration sec = new SessionExportConfiguration();
            sec.TargetIdentifier = true;
            sec.NeitherImage = true;
            sec.BothImages = false;
            sec.ControlImage = false;
            sec.TargetImage = false;
            sec.SessionName = true;
            sec.ViewerName = true;
            sec.JudgeName = true;
            sec.ViewerSelected = false;
            sec.JudgeSelected = false;
            sec.TargetSelected = false;
            sec.Screenshot = false;
            sec.Notes = false;
            sec.ARV = false;
            sec.GeomagneticWeather = false;
            SessionExportConfig = sec;

            HighlightColor = Color.FromArgb(197, 201, 243);
            SupressSplashScreen = false;

            JsonSerializerOptions opts = new JsonSerializerOptions()
            {
                Converters = {
                        new ColorJsonConverter()
                    }
            };
            opts.WriteIndented = true;
            string json = JsonSerializer.Serialize(this, opts);
            File.WriteAllText("OPLConfig.json", json);
        }

        public void OnRaisePropertyChangedEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> raiseEvent = RaisePropertyChangedEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                //e.PropertyName = ";

                // Call to raise the event.
                raiseEvent(null, e);
            }
        }


        public void Save()
        {
            JsonSerializerOptions opts = new JsonSerializerOptions()
            {
                Converters = {
                    new ColorJsonConverter()
                }
            };
            opts.WriteIndented = true;
            string json = JsonSerializer.Serialize(this, opts);
            File.WriteAllText("OPLConfig.json", json);
        }
    }

    //================================================
    //                CustomEventArgs
    //================================================
    public class CustomEventArgs : EventArgs
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public CustomEventArgs(string propertyName, string propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }
    }

}
