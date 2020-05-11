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

        public Random rnd;

        public bool RandomLicenseOrder;
        public int NextLicenseCost = 10;
        public List<Sport> LicenseOrder = new List<Sport>();

        public World(Random r)
        {
            rnd = r;
            LicenseOrder.Add(Sport.Soccer);
            LicenseOrder.Add(Sport.Hockey);
            LicenseOrder.Add(Sport.Baseball);
            LicenseOrder.Add(Sport.Basketball);
            LicenseOrder.Add(Sport.Football);
        }

        public Agency MyAgency { get { return _MyAgency; } }
        public Agent Manager { get { return _Manager; } }
        public void SetMyAgency(Agency a)
        {
            _MyAgency = a;
            _MyAgency.AddMoney(35000);
        }
        public void SetManager(Agent a)
        {
            _Manager = a;
            _MyAgency.SetManager(a);
        }
        public void SetLicenseOrder()
        {
            List<Sport> temp = new List<Sport>();
            foreach (Sport s in LicenseOrder) temp.Add(s);

            LicenseOrder.Clear();

            for (int i = temp.Count; i > 0; i--)
            {
                int index = rnd.Next(0, i);
                LicenseOrder.Add(temp[index]);
                temp.RemoveAt(index);
            }
        }
        public void ObtainNextLicense()
        {
            if (_MyAgency.Licenses.Count == 0)
                _MyAgency.AddLicense(LicenseOrder[0]);
            else if (_MyAgency.Licenses.Count == 1)
                _MyAgency.AddLicense(LicenseOrder[1]);
            else if (_MyAgency.Licenses.Count == 2)
                _MyAgency.AddLicense(LicenseOrder[2]);
            else if (_MyAgency.Licenses.Count == 3)
                _MyAgency.AddLicense(LicenseOrder[3]);
            else if (_MyAgency.Licenses.Count == 4)
                _MyAgency.AddLicense(LicenseOrder[4]);

            _MyAgency.AddInfluencePoints(-NextLicenseCost);
            SetNextLicenseCost();
        }
        public void SetNextLicenseCost()
        {
            if (NextLicenseCost == 10)
                NextLicenseCost = 25;
            else if (NextLicenseCost == 25)
                NextLicenseCost = 50;
            else if (NextLicenseCost == 50)
                NextLicenseCost = 100;
            else if (NextLicenseCost == 100)
                NextLicenseCost = 250;
        }
    }
}
