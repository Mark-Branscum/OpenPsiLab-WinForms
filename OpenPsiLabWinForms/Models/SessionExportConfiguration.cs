using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenPsiLabWinForms.Models
{
    public class SessionExportConfiguration
    {
        public bool TargetIdentifier { get; set; }
        
        private bool _bothImages;
        public bool BothImages
        {
            get { return _bothImages; }
            set
            {
                if (value == true)
                {
                    NeitherImage = false;
                    TargetImage = false;
                    ControlImage = false;
                }
                _bothImages = value;
            }
        }

        private bool _neitherImage;
        public bool NeitherImage
        {
            get { return _neitherImage;}
            set
            {
                if (value == true)
                {
                    BothImages = false;
                    TargetImage = false;
                    ControlImage = false;
                }
                _neitherImage = value;
            }
        }

        private bool _targetImage;
        public bool TargetImage
        {
            get { return _targetImage;}
            set
            {
                if (value == true)
                {
                    BothImages = false;
                    NeitherImage = false;
                    ControlImage = false;
                }
                _targetImage = value;
            }
        }

        private bool _controlImage;
        public bool ControlImage
        {
            get { return _controlImage;}
            set
            {
                if (value == true)
                {
                    BothImages = false;
                    NeitherImage = false;
                    TargetImage = false;
                }
                _controlImage = value;
            }
        }
        
        public bool SessionName { get; set; }
        public bool ViewerName { get; set; }
        public bool JudgeName { get; set; }
        public bool ViewerSelected { get; set; }
        public bool JudgeSelected { get; set; }
        public bool TargetSelected { get; set; }
        public bool Screenshot { get; set; }
        public bool Notes { get; set; }
        public bool GeomagneticWeather { get; set; }
        public bool ARV { get; set; }
        public bool Files { get; set; }
    }
}
