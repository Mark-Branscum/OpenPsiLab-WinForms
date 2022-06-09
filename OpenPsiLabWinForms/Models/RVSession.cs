using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPsiLabWinForms.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using OpenPsiLabWinForms.Views;

namespace OpenPsiLabWinForms.Models
{
    public class RVSession
    {
        
        private Guid _uuid;
        public Guid UUID
        {
            get
            {
                return _uuid;
            }
            set
            {
                _uuid = value;
                
            }
        }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TargetID { get; set; }
        
        public ImageAsset[] ImagesArray { get; set; }
        public ImageAsset Image1
        {
            get
            {
                if (ImagesArray == null)
                    return null;
                if (ImagesArray[0] == null)
                    return null;
                return ImagesArray[0];
            }
            set
            {
                if (ImagesArray == null)
                    ImagesArray = new ImageAsset[2];
                ImagesArray[0] = value;
            }
        }
        public ImageAsset Image2
        {
            get
            {
                if (ImagesArray == null)
                    return null;
                if (ImagesArray[1] == null)
                    return null;
                return ImagesArray[1];
            }
            set
            {
                if (ImagesArray == null)
                    ImagesArray = new ImageAsset[2];
                ImagesArray[1] = value;
            }
        }
        
        public Guid? TargetImageUUID
        {
            get
            {
                if (ImagesArray != null)
                {
                    foreach (ImageAsset image in ImagesArray)
                    {
                        if (image.IsTarget)
                        {
                            return image.UUID;
                        }
                    }
                }
                return null;
            }
        }
        public Guid? ViewerSelectedImageUUID
        {
            get
            {
                if (ImagesArray == null)
                    return null;
                foreach (ImageAsset image in ImagesArray)
                {
                    if (image.IsViewerSelected)
                    {
                        return image.UUID;
                    }
                }
                return null;
            }
        }
        public Guid? JudgeSelectedImageUUID
        {
            get
            {
                if (ImagesArray == null)
                    return null;
                foreach (ImageAsset image in ImagesArray)
                {
                    if (image.IsJudgeSelected)
                    {
                        return image.UUID;
                    }
                }
                return null;
            }
        }
        private DateTimeOffset _startDateTimeLocal;
        public DateTimeOffset StartDateTimeLocal
        {
            get
            {
                return _startDateTimeLocal;
            }
            set
            {
                _startDateTimeLocal = value;
                _startDateTimeUTC = value.ToUniversalTime();
                _startDateTimeSidereal = SideUtils.getSiderealTime(_startDateTimeUTC, Longitude);
            }
        }
        private DateTimeOffset _startDateTimeUTC;
        public DateTimeOffset StartDateTimeUTC
        {
            get
            {
                return _startDateTimeUTC;
            } 
        }
        private DateTime _startDateTimeSidereal;
        public DateTime StartDateTimeSidereal
        {
            get
            {
                return _startDateTimeSidereal;
            }
        }
        private DateTimeOffset _endDateTimeLocal;
        public DateTimeOffset EndDateTimeLocal
        {
            get
            {
                return _endDateTimeLocal;
            }
            set
            {
                _endDateTimeLocal = value;
                _endDateTimeUTC = value.ToUniversalTime();
                _endDateTimeSidereal = SideUtils.getSiderealTime(_endDateTimeUTC, Longitude);
            }
        }
        private DateTimeOffset _endDateTimeUTC;
        public DateTimeOffset EndDateTimeUTC
        {
            get
            {
                return _endDateTimeUTC;
            }
        }
        private DateTime _endDateTimeSidereal;
        public DateTime EndDateTimeSidereal
        {
            get
            {
                return _endDateTimeSidereal;
            }
        }
        private DateTimeOffset _viewerSelectedDateTimeLocal;
        public DateTimeOffset ViewerSelectedDateTimeLocal
        {
            get
            {
                return _viewerSelectedDateTimeLocal;
            }
            set
            {
                _viewerSelectedDateTimeLocal = value;
                _viewerSelectedDateTimeUTC = value.ToUniversalTime();
                _viewerSelectedDateTimeSidereal = SideUtils.getSiderealTime(_viewerSelectedDateTimeUTC, Longitude);
            }
        }
        private DateTimeOffset _viewerSelectedDateTimeUTC;
        public DateTimeOffset ViewerSelectedDateTimeUTC
        {
            get
            {
                return _viewerSelectedDateTimeUTC;
            }
        }
        private DateTime _viewerSelectedDateTimeSidereal;
        public DateTime ViewerSelectedDateTimeSidereal
        {
            get
            {
                return _viewerSelectedDateTimeSidereal;
            }
        }
        private DateTimeOffset _judgeSelectedDateTimeLocal;
        public DateTimeOffset JudgeSelectedDateTimeLocal
        {
            get
            {
                return _judgeSelectedDateTimeLocal;
            }
            set
            {
                _judgeSelectedDateTimeLocal = value;
                _judgeSelectedDateTimeUTC = value.ToUniversalTime();
                _judgeSelectedDateTimeSidereal = SideUtils.getSiderealTime(_judgeSelectedDateTimeUTC, Longitude);
            }
        }
        private DateTimeOffset _judgeSelectedDateTimeUTC;
        public DateTimeOffset JudgeSelectedDateTimeUTC
        {
            get
            {
                return _judgeSelectedDateTimeUTC;
            }
        }
        private DateTime _judgeSelectedDateTimeSidereal;
        public DateTime JudgeSelectedDateTimeSidereal
        {
            get
            {
                return _judgeSelectedDateTimeSidereal;
            }
        }
        private DateTimeOffset _targetedDateTimeLocal;
        public DateTimeOffset TargetedDateTimeLocal
        {
            get
            {
                return _targetedDateTimeLocal;
            }
            set
            {
                _targetedDateTimeLocal = value;
                _targetedDateTimeUTC = value.ToUniversalTime();
                _targetedDateTimeSidereal = SideUtils.getSiderealTime(_targetedDateTimeUTC, Longitude);
            }
        }
        private DateTimeOffset _targetedDateTimeUTC;
        public DateTimeOffset TargetedDateTimeUTC
        {
            get
            {
                return _targetedDateTimeUTC;
            }
        }
        private DateTime _targetedDateTimeSidereal;
        public DateTime TargetedDateTimeSidereal
        {
            get
            {
                return _targetedDateTimeSidereal;
            }
        }
        public int ViewerSelectedIndex
        {
            get
            {
                if (ImagesArray == null)
                    return -1;
                if (ImagesArray[0] == null || ImagesArray[1] == null)
                    return -1;

                if (ImagesArray[0].IsViewerSelected)
                {
                    return 1;
                }
                else if (ImagesArray[1].IsViewerSelected)
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (ImagesArray != null && ImagesArray[0] != null && ImagesArray[1] != null)
                {
                    if (value == 1)
                    {
                        ImagesArray[0].IsViewerSelected = true;
                        ImagesArray[1].IsViewerSelected = false;
                    }
                    else if (value == 2)
                    {
                        ImagesArray[0].IsViewerSelected = false;
                        ImagesArray[1].IsViewerSelected = true;
                    }
                    else
                    {
                        ImagesArray[0].IsViewerSelected = false;
                        ImagesArray[1].IsViewerSelected = false;
                    }
                    SetViewerJudgeSelected();
                    ViewerSelectedDateTimeLocal = DateTimeOffset.Now;
                }
            }
        }
        public int JudgeSelectedIndex
        {
            get
            {
                if (ImagesArray == null)
                    return -1;
                if (ImagesArray[0] == null || ImagesArray[1] == null)
                    return -1;
                if (ImagesArray[0].IsJudgeSelected)
                {
                    return 1;
                }
                else if (ImagesArray[1].IsJudgeSelected)
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (ImagesArray == null || ImagesArray[0] == null || ImagesArray[1] == null)
                    return;
                if (value == 1)
                {
                    ImagesArray[0].IsJudgeSelected = true;
                    ImagesArray[1].IsJudgeSelected = false;
                }
                else if (value == 2)
                {
                    ImagesArray[0].IsJudgeSelected = false;
                    ImagesArray[1].IsJudgeSelected = true;
                }
                else
                {
                    ImagesArray[0].IsJudgeSelected = false;
                    ImagesArray[1].IsJudgeSelected = false;
                }
                SetViewerJudgeSelected();
                JudgeSelectedDateTimeLocal = DateTimeOffset.Now;
            }
        }
        public double Longitude { get; set; }
        
        [JsonIgnore] 
        private SiderealTimeUtilities _sideUtils;
        [JsonIgnore]
        public SiderealTimeUtilities SideUtils
        {
            get
            {
                if (_sideUtils == null)
                {
                    _sideUtils = new SiderealTimeUtilities();
                }
                return _sideUtils;
            }
            set
            {
                _sideUtils = value;
            }
        }
        
        public string SWXOverviewLargeUUID { get; set; }
        public string NotificationsInEffectTimelineUUID { get; set; }
        public Guid? ScreenshotUUID { get; set; }
        public string ViewerSelectedTarget { get; set; }
        public string JudgeSelectedTarget { get; set; }
        public int TargetIndex
        {
            get
            {
                if (ImagesArray == null)
                    return -1;
                if (ImagesArray[0] == null || ImagesArray[1] == null)
                    return -1;
                if (ImagesArray[0].IsTarget)
                {
                    return 1;
                }
                else if (ImagesArray[1].IsTarget)
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (ImagesArray == null || ImagesArray[0] == null || ImagesArray[1] == null)
                    return;

                if (value == 1)
                {
                    ImagesArray[0].IsTarget = true;
                    ImagesArray[1].IsTarget = false;
                    Targeted = "true";
                }
                else if (value == 2)
                {
                    ImagesArray[0].IsTarget = false;
                    ImagesArray[1].IsTarget = true;
                    Targeted = "true";
                }
                else
                {
                    ImagesArray[0].IsTarget = false;
                    ImagesArray[1].IsTarget = false;
                    Targeted = "false";
                }
                SetViewerJudgeSelected();
                TargetedDateTimeLocal = DateTimeOffset.Now;
            }
        }
        public string Targeted { get; set; } = "false";
        public string ViewerName { get; set; }
        public string JudgeName { get; set; }
        public string ARVQuestion { get; set; }
        public string ARVAnswer1 { get; set; }
        public string ARVAnswer2 { get; set; }
        public SessionForm.SessionType SessionType { get; set; }
        
        //Retain
        [JsonIgnore]
        private OPLConfiguration oplConfig;

        public enum TimeType
        {
            StartTime,
            EndTime,
            ViewerSelectedTime,
            JudgeSelectedTime,
            TargetedTime
        }

        [JsonConstructor]
        public RVSession()
        {
            //This this constructor here, otherwise json
            //deserialization freaks out
        }
       
        public RVSession(SiderealTimeUtilities sideUtils,
            double longitude, SessionForm.SessionType typeOfSession, 
            OPLConfiguration oplConfiguration)
        {
            oplConfig = oplConfiguration;
            SideUtils = sideUtils;
            Longitude = longitude;
            UUID = Guid.NewGuid();
            StartDateTimeLocal = DateTime.Now;
            SessionType = typeOfSession;
        }

        public string ToJSON()
        {
            SessionPractieJson spj = new SessionPractieJson(this, oplConfig);
            JsonSerializerOptions opts = new JsonSerializerOptions();
            opts.WriteIndented = true;
            return JsonSerializer.Serialize(spj, opts);
        }

        public string ToCommaSeparatedValues()
        {
            return exportTSVOrCSV("csv");
        }

        public string ToTabSeparatedValues()
        {
            return exportTSVOrCSV("tsv");
        }

        private string exportTSVOrCSV(string TSVOrCSV)
        {
            string div = string.Empty;
            switch (TSVOrCSV.ToLower())
            {
                case "tsv":
                    div = "\t";
                    break;
                case "csv":
                    div = ",";
                    break;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append($"UUID{div}Name{div}Notes{div}TargetID{div}Targeted{div}TargetImageUUID{div}" +
                      $"ViewerSelectedImageUUID{div}JudgeSelectedImageUUID{div}" +
                      $"StartDateTimeLocal{div}StartDateTimeUTC{div}StartDateTimeSidereal{div}" +
                      $"EndDateTimeLocal{div}EndDateTimeUTC{div}EndDateTimeSidereal{div}" +
                      $"ViewerSelectedDateTimeLocal{div}ViewerSelectedDateTimeUTC{div}" +
                      $"ViewerSelectedDateTimeSidereal{div}JudgeSelectedDateTimeLocal{div}" +
                      $"JudgeSelectedDateTimeUTC{div}JudgeSelectedDateTimeSidereal{div}" +
                      $"TargetedDateTimeLocal{div}" +
                      $"TargetedDateTimeUTC{div}TargetedDateTimeSidereal{div}Longitude{div}" +
                      $"SWXOverviewLargeUUID{div}NotificationsInEffectTimelineUUID{div}" +
                      $"ScreenshotUUID{div}ViewerSelectedTarget{div}JudgeSelectedTarget{div}" +
                      $"ViewerName{div}JudgeName\n");
            
            sb.Append($"{UUID}{div}{Name}{div}{Notes}{div}{TargetID}{div}{Targeted}{div}{TargetImageUUID}{div}" +
                      $"{ViewerSelectedImageUUID}{div}{JudgeSelectedImageUUID}{div}" +
                      $"{StartDateTimeLocal}{div}{StartDateTimeUTC}{div}{StartDateTimeSidereal}{div}" +
                      $"{EndDateTimeLocal}{div}{EndDateTimeUTC}{div}{EndDateTimeSidereal}{div}" +
                      $"{ViewerSelectedDateTimeLocal}{div}{ViewerSelectedDateTimeUTC}{div}" +
                      $"{ViewerSelectedDateTimeSidereal}{div}{JudgeSelectedDateTimeLocal}{div}" +
                      $"{JudgeSelectedDateTimeUTC}{div}{JudgeSelectedDateTimeSidereal}{div}" +
                      $"{TargetedDateTimeLocal}{div}" +
                      $"{TargetedDateTimeUTC}{div}{TargetedDateTimeSidereal}{div}{Longitude}{div}" +
                      $"{SWXOverviewLargeUUID}{div}{NotificationsInEffectTimelineUUID}{div}" +
                      $"{ScreenshotUUID}{div}{ViewerSelectedTarget}{div}{JudgeSelectedTarget}{div}" +
                      $"{ViewerName}{div}{JudgeName}\n");
            return sb.ToString();
        }

        public void SetViewerJudgeSelected()
        {
            if (TargetImageUUID == null || ViewerSelectedImageUUID == null || 
                TargetImageUUID == Guid.Empty || ViewerSelectedImageUUID == Guid.Empty)
            {
                ViewerSelectedTarget = "false";
            } else if (TargetImageUUID == ViewerSelectedImageUUID)
            {
                ViewerSelectedTarget = "true";
            }
            else
            {
                ViewerSelectedTarget = "false";
            }
            if (TargetImageUUID == null || JudgeSelectedImageUUID == null ||
                TargetImageUUID == Guid.Empty || JudgeSelectedImageUUID == Guid.Empty)
            {
                JudgeSelectedTarget = "false";
            } else if (TargetImageUUID == JudgeSelectedImageUUID)
            {
                JudgeSelectedTarget = "true";
            }
            else
            {
                JudgeSelectedTarget = "false";
            }
        }
    }
}
