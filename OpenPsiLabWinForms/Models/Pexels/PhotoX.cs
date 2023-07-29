using PexelsDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPsiLabWinForms.Models.Pexels
{
    public class PhotoX
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
        public string Photographer_url { get; set; }
        public int Photographer_id { get; set; }
        public string Avg_color { get; set; }
        public SourceX Src { get; set; }
        public bool Liked { get; set; }
        public string Alt { get; set; }
    }
}
