using System;
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
        private List<Agent> _AgentList = new List<Agent>();
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
        public List<Agent> AgentList { get { return _AgentList; } }
        public List<SportName> Licenses { get { return _Licenses; } }
        public List<FreelanceJob> FreelanceJobsAvailable {  get { return _FreelanceJobsAvailable;  } }
        public bool FreelanceBefore = false;
        public bool AttemptingJob;
        public int DaysAttemptingJob = 0;
        public MainForm mainForm;
        #endregion

        public Agency(MainForm mf, string name, int level)
        {
            _Name = name;
            _Level = level;
            _InfluencePoints = 0;
            mainForm = mf;
            AttemptingJob = false;
            _AgentList.Add(new Agent("Rose", "Rizzo", Role.Agent, 150, 50, 75, 110, 10, 80));
            _AgentCount = _AgentList.Count;
        }
        public void AddAgent(Agent a)
        {
            _AgentList.Add(a);
            _AgentCount = _AgentList.Count;
            mainForm.UpdateOfficeInfo();
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
            {
                AddFreelanceJob(new FreelanceJob("Minor League Deal", "Large agency paying for minor negotiation", JobType.negotiating, 5, 3, 15000, 14, 1750));
                AddFreelanceJob(new FreelanceJob("Diamond In The Rough", "Scout your first unsigned player.", JobType.scouting, 7, 5, 0, 28, 3500));
            }
        }
        public void AddFreelanceJob(FreelanceJob job)
        {
            _FreelanceJobsAvailable.Add(job);
        }
        public void PayOfficeMonthlyRent()
        {
            AddMoney(-Office.MonthlyCost);
        }
        public void AddDaysWorking()
        {
            Manager.DaysWorkingOnJob++;
            DetermineIfEfficiencyDrops(Manager);
            if (AgentCount > 0)
                foreach (Agent a in AgentList)
                    if (a.WorkingOnJob)
                    {
                        a.DaysWorkingOnJob++;
                        DetermineIfEfficiencyDrops(a);
                    }
        }
        public void DetermineIfEfficiencyDrops(Agent a)
        {
            int daysForDecrease = 0;
            if (a.Role == Role.Manager)
            {
                daysForDecrease = 5;
            }
            else daysForDecrease = 3;

            if (a.DaysWorkingOnJob % daysForDecrease == 0)
            {
                a.AddEfficiency(-1);
                a.DaysWorkingOnJob = 0;
                if (a.Role == Role.Manager)
                    a.UpdateManagerUI(mainForm);
            }
        }
    }
}
