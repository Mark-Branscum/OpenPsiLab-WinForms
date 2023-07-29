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
        private string _appDataPath = "";
        public string AppDataPath
        {
            get
            {
                return _appDataPath;
            }
            set
            {
                _appDataPath = value;
                Save();
            }
        }

        public string _documentsPath = "";

        public string DocumentsPath
        {
            get
            {
                return _documentsPath;
            }
            set
            {
                _documentsPath = value;
                Save();
            }
        }

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

        private string _imageFolderFullPath;
        public string ImageFolderFullPath
        {
            get
            {
                return _imageFolderFullPath;
            }
            set
            {
                _imageFolderFullPath = value;
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
        private string _sqlLiteDatabaseFullPath;
        public string SQLiteDatabaseFullPath
        {
            get
            {
                return _sqlLiteDatabaseFullPath;
            }
            set
            {
                _sqlLiteDatabaseFullPath = value;
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

        private string _imageDownloadURL;
        public string ImageDownloadURL
        {
            get
            {
                return _imageDownloadURL;
            }
            set
            {
                _imageDownloadURL = value;
                Save();
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

        private bool _installOrUpdateConfigured = false;
        public bool InstallOrUpdateConfigured
        {
            get
            {
                return _installOrUpdateConfigured;
            }
            set
            {
                _installOrUpdateConfigured = value;
            }
        }
        
        public event EventHandler<CustomEventArgs> RaisePropertyChangedEvent;

        public void InitializeNewConfig(string appDataPath, string documentsPath)
        {
            //If there is alread a config file then skip this method
            string configFilePath = Path.Combine(appDataPath, "OPLConfig.json");
            if (File.Exists(configFilePath) == true)
                return;

            //ImageFolderFullPath = "";
            _imageFolderFullPath = Path.Combine(documentsPath, "Images");  

            _sqlLiteDatabaseFullPath = Path.Combine(appDataPath, "Database", "OpenPsiLabData.db");
            string dbDirectory = Path.GetDirectoryName(SQLiteDatabaseFullPath);
            if (Directory.Exists(dbDirectory) == false)
                Directory.CreateDirectory(dbDirectory);

            _loadSessionPath = Path.Combine(documentsPath, "RVSessions");
            if (Directory.Exists(LoadSessionPath) == false)
                Directory.CreateDirectory(LoadSessionPath);

            _exportSessionPath = Path.Combine(documentsPath, "RVSessions");
            if (Directory.Exists(ExportSessionPath) == false)
                Directory.CreateDirectory(ExportSessionPath);

            _addImagePath = Path.Combine(documentsPath);
            if (Directory.Exists(AddImagePath) == false)
                Directory.CreateDirectory(AddImagePath);

            _addFilePath = Path.Combine(documentsPath);
            if (Directory.Exists(AddFilePath) == false)
                Directory.CreateDirectory(AddFilePath);
            
            _rngSerialPortName = "COM1";
            _randomnessSource = "Random.org";
          
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
            _sessionExportConfig = sec;

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

            _appDataPath = appDataPath;
            _documentsPath = documentsPath;

            _imageDownloadURL = "https://www.pexels.com/";


            if (File.Exists(configFilePath) == false)
            {
                FileStream fs = File.Create(configFilePath);
                fs.Close();
            }
            File.WriteAllText(configFilePath, json);
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
            File.WriteAllText(Path.Combine(this.AppDataPath, "OPLConfig.json"), json);
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
