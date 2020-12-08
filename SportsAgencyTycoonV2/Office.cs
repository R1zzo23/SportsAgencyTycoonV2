using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Office
    {
        #region Private Fields
        private int _Level;
        private int _PurchaseCost;
        private int _MonthlyCost;
        private int _EmployeeCapacity;
        #endregion
        #region Public Getters
        public int Level { get { return _Level; } }
        public int PurchaseCost { get { return _PurchaseCost; } }
        public int MonthlyCost { get { return _MonthlyCost; } }
        public int EmployeeCapacity { get { return _EmployeeCapacity; } }
        #endregion
        public Office(int level, int purchaseCost, int monthlyCost, int employeeCapacity)
        {
            _Level = level;
            _PurchaseCost = purchaseCost;
            _MonthlyCost = monthlyCost;
            _EmployeeCapacity = employeeCapacity;
        }
        public void IncreaseLevel()
        {
            _Level++;
        }
    }
}
