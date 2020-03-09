using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class World
    {
        private Agency _MyAgency;
        private Agent _Manager;

        public int NextLicenseCost = 10;

        public Agency MyAgency { get { return _MyAgency; } }
        public Agent Manager { get { return _Manager; } }
        public void SetMyAgency(Agency a)
        {
            _MyAgency = a;
            _MyAgency.AddMoney(35000);
            _MyAgency.AddInfluencePointws(10);
        }
        public void SetManager(Agent a)
        {
            _Manager = a;
            _MyAgency.SetManager(a);
        }
        public void ObtainNextLicense()
        {
            if (_MyAgency.Level == 0)
                _MyAgency.AddLicense(Sport.Soccer);
            else if (_MyAgency.Level == 1)
                _MyAgency.AddLicense(Sport.Hockey);
            else if (_MyAgency.Level == 2)
                _MyAgency.AddLicense(Sport.Baseball);
            else if (_MyAgency.Level == 3)
                _MyAgency.AddLicense(Sport.Basketball);
            else if (_MyAgency.Level == 4)
                _MyAgency.AddLicense(Sport.Football);

            _MyAgency.AddInfluencePointws(-NextLicenseCost);
        }
    }
}
