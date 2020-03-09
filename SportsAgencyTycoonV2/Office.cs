using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Office
    {
        private int _Level;
        private int _PurchaseCost;
        private int _MonthlyCost;
        private int _EmployeeCapacity;

        public Office(int level, int purchaseCost, int monthlyCost, int employeeCapacity)
        {
            _Level = level;
            _PurchaseCost = purchaseCost;
            _MonthlyCost = monthlyCost;
            _EmployeeCapacity = employeeCapacity;
        }

        #region Methods that Return Private Variables
        public int ReturnOfficeLevel()
        {
            return _Level;
        }
        public int ReturnPurchaseCost()
        {
            return _PurchaseCost;
        }
        public int ReturnMonthlyCost()
        {
            return _MonthlyCost;
        }
        public int ReturnEmployeeCapacity()
        {
            return _EmployeeCapacity;
        }
        #endregion
    }
}
