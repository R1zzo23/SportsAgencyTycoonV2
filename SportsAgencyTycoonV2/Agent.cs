using System;
namespace SportsAgencyTycoonV2
{
    public class Agent
    {
        #region Private Fields
        private string _FirstName;
        private string _LastName;
        private string _FullName;

        private Role _Role;
        private int _Salary;

        private int _Greed;
        private int _Negotiating;
        private int _Power;
        private int _Intelligence;
        private int _Scouting;

        #endregion
        #region Public Getters
        public string FirstName { get { return _FirstName; } }
        public string LastName { get { return _LastName; } }
        public string FullName { get { return _FullName; } }

        public Role Role { get { return _Role; } }
        public int Salary { get { return _Salary; } }

        public int Greed { get { return _Greed; } }
        public int Negotiating { get { return _Negotiating; } }
        public int Power { get { return _Power; } }
        public int Intelligence { get { return _Intelligence; } }
        public int Scouting { get { return _Scouting; } }
        #endregion
        public Agent(string firstName, string lastName, Role role)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _FullName = firstName + " " + lastName;

            _Role = role;
            if (role == Role.Manager)
                _Salary = 0;
            else _Salary = DetermineSalary();

            if (role == Role.Manager)
            {
                _Greed = 100;
                _Negotiating = 100;
                _Power = 100;
                _Intelligence = 100;
                _Scouting = 100;
            }
        }

        int DetermineSalary()
        {
            int salary = 0;


            return salary;
        }
        public void UpdateManagerUI(MainForm mf)
        {
            mf.lblManagerGreed.Text = "GRD: " + Greed.ToString();
            mf.lblManagerIQ.Text = "INT: " + Intelligence.ToString();
            mf.lblManagerNegotiate.Text = "NEG: " + Negotiating.ToString();
            mf.lblManagerPower.Text = "POW: " + Power.ToString();
            mf.lblManagerScouting.Text = "SCT: " + Scouting.ToString();
        }
    }
}
