﻿using System;
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
        private Agent _Manager;
        private int _Money;
        private int _InfluencePoints;
        private int _AgentCount;
        private int _ClientCount;
        private List<SportName> _Licenses = new List<SportName>();
        private List<FreelanceJob> _FreelanceJobsAvailable = new List<FreelanceJob>();
        #endregion
        #region Public Getters
        public string Name { get { return _Name; } }
        public int Level { get { return _Level; } }
        public Office Office { get { return _Office; } }
        public Agent Manager { get { return _Manager; } }
        public int Money { get { return _Money; } }
        public int InfluencePoints { get { return _InfluencePoints; } }
        public int AgentCount { get { return _AgentCount; } }
        public int ClientCount { get { return _ClientCount; } }
        public List<SportName> Licenses { get { return _Licenses; } }
        public List<FreelanceJob> FreelanceJobsAvailable {  get { return _FreelanceJobsAvailable;  } }
        public bool FreelanceBefore = false;
        public MainForm mainForm;
        #endregion

        public Agency(MainForm mf, string name, int level)
        {
            _Name = name;
            _Level = level;
            _InfluencePoints = 0;
            mainForm = mf;
        }
        public void SetManager(Agent agent)
        {
            _Manager = agent;
        }
        public void AddMoney(int i)
        {
            _Money += i;
            mainForm.UpdateAgencyMoneyLabel();
        }
        public void AddInfluencePoints(int i)
        {
            _InfluencePoints += i;
            mainForm.UpdateAgencyInfluencePointsLabel();
        }
        public void SetOffice()
        {
            _Office = new Office(1, 0, 2500, 1);
        }
        public void AddLicense(SportName sport)
        {
            _Licenses.Add(sport);
            if (_Licenses.Count == 1)
                AddFreelanceJob(new FreelanceJob("Minor League Deal", "Large agency paying for minor negotiation", JobType.negotiating, 5, 3, 15000, 2, 2500));
        }
        public void AddFreelanceJob(FreelanceJob job)
        {
            _FreelanceJobsAvailable.Add(job);
        }
        public void PayOfficeMonthlyRent()
        {
            AddMoney(-Office.MonthlyCost);
        }
    }
}
