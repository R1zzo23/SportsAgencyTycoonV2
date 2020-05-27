using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Team
    {
        public string city;
        public string mascot;
        public string abbreviation;
        public List<Player> roster = new List<Player>();
    }
}
