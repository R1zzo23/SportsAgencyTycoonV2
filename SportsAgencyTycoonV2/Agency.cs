using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Agency
    {
        private string _Name;
        private int _Level;
        private Office _Office;
        private int _Money;
        private int _InfluencePoints;
        private int _AgentCount;
        private int _ClientCount;

        public Agency(string name, int level)
        {
            _Name = name;
            _Level = level;
        }
    }
}
