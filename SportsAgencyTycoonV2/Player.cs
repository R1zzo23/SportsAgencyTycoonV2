using System;
namespace SportsAgencyTycoonV2
{
    public class Player
    {
        #region Private Fields
        private string _FirstName;
        private string _LastName;
        private string _FullName;

        private int _Age;

        private Sport _Sport;
        private int _Salary;
        private Archetype _Archetype;

        private int _Skill;
        private int _WorkEthic;
        #endregion
        #region Public Getters
        public string FirstName { get { return _FirstName; } }
        public string LastName { get { return _LastName; } }
        public string FullName { get { return _FullName; } }

        public int Age { get { return _Age;  } }

        public Sport Sport { get { return _Sport; } }
        public int Salary { get { return _Salary; } }
        public Archetype Archetype { get { return _Archetype;  } }

        public int Skill { get { return _Skill; } }
        public int WorkEthic { get { return _WorkEthic; } }
        #endregion
        public Player(string firstName, string lastName, Sport sport)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _FirstName = firstName + " " + lastName;
            _Sport = sport;
        }
    }
}
