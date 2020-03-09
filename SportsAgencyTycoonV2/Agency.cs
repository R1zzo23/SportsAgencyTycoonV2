using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Agency
    {
        #region Private Fields
        private string _Name;
        private int _Level;
        private Office _Office;
        private int _Money;
        private int _InfluencePoints;
        private int _AgentCount;
        private int _ClientCount;
        #endregion
        #region Public Getters
        public string Name { get { return _Name; } }
        public int Level { get { return _Level; } }
        public int Money { get { return _Money; } }
        public int InfluencePoints { get { return _InfluencePoints; } }
        public int AgentCount { get { return _AgentCount; } }
        public int ClientCount { get { return _ClientCount; } }
        #endregion

        public Agency(string name, int level)
        {
            _Name = name;
            _Level = level;
        }
    }
}
