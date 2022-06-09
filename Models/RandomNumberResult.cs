using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPsiLabWinForms.Models
{
    public class RandomNumberResult
    {
        public double? randomNumber = null;
        public randomSources? randomSource = null;
        public enum randomSources
        {
            Pseudo,
            TrueRNG,
            RandomOrg
        }
    }
}
