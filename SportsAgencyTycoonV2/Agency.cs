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
        #region Public Methods to Return Private Variables
        public string ReturnName()
        {
            return _Name;
        }
        public int ReturnLevel()
        {
            return _Level;
        }
        public Office ReturnOffice()
        {
            return _Office;
        }
        public int ReturnMoney()
        {
            return _Money;
        }
        public int ReturnIP()
        {
            return _InfluencePoints;
        }
        public int ReturnAgentCount()
        {
            return _AgentCount;
        }
        public int ReturnClientCount()
        {
            return _ClientCount;
        }
#endregion
    }
}
