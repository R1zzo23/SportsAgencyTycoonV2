﻿using System;
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
        }

        int DetermineSalary()
        {
            int salary = 0;


            return salary;
        }
    }
}
