using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class League
    {
        public string name;
        public string abbreviation;
        public List<Team> teamList = new List<Team>();
        public int minSalary;
        public int maxSalary;
    }
}
