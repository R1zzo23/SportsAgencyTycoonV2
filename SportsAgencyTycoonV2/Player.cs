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

        private SportName _Sport;
        private int _Salary;
        private Archetype _Archetype;

        private int _Skill;
        private double _Stars;
        private int _WorkEthic;
        #endregion
        #region Public Getters
        public string FirstName { get { return _FirstName; } }
        public string LastName { get { return _LastName; } }
        public string FullName { get { return _FullName; } }

        public int Age { get { return _Age;  } }

        public SportName Sport { get { return _Sport; } }
        public int Salary { get { return _Salary; } }
        public Archetype Archetype { get { return _Archetype;  } }

        public int Skill { get { return _Skill; } }
        public double Stars { get { return _Stars; } }
        public int WorkEthic { get { return _WorkEthic; } }
        #endregion
        public Player(string firstName, string lastName, SportName sport)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _FirstName = firstName + " " + lastName;
            _Sport = sport;
        }
        public void SetArchetype(Archetype a)
        {
            _Archetype = a;
        }
        public void SetStarRating(Random r, int agencyLevel)
        {
            double rnd = r.Next(1, agencyLevel + 2);
            _Stars = rnd / 2;
        }
        public void SetSkillRating(Random r)
        {
            double rnd = r.Next(Convert.ToInt32(_Stars * 20), Convert.ToInt32(_Stars * 30));
            _Skill = Convert.ToInt32(200 * (rnd / 100));
        }
        public void SetWorkEthicRating(Random r)
        {
            int rnd = r.Next(_Skill, _Skill * 4);
            _WorkEthic = rnd;
        }
    }
}
