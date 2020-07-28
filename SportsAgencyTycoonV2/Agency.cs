using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<Player> _ClientList = new List<Player>();
        private List<Sports> _Licenses = new List<Sports>();
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
        public List<Player> Clients = new List<Player>();
        public List<Sports> Licenses { get { return _Licenses; } }
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
            //_AgentList.Add(new Agent("Dirty", "Dave", Role.Agent, 150, 50, 75, 110, 10, 80));
            //_AgentList.Add(new Agent("Clean", "Steven", Role.Agent, 175, 85, 150, 210, 90, 100));
            _AgentCount = _AgentList.Count;
            //_AgentList[0].SetCurrentEfficiency(25);
            //_AgentList[1].SetCurrentEfficiency(50);
        }
        public void AddAgent(Agent a)
        {
            _AgentList.Add(a);
            _AgentCount = _AgentList.Count;
            mainForm.UpdateOfficeInfo();
        }
        public void AddClient(Player p)
        {
            p.AgencyHappiness = 75;
            p.AgencyHappinessDescription = p.DescribeHappiness(p.AgencyHappiness);
            p.AgencyHappinessString = p.EnumToString(p.AgencyHappinessDescription.ToString());
            Clients.Add(p);
            _ClientCount = Clients.Count;
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
        public void AddLicense(Sports sport)
        {
            _Licenses.Add(sport);
            if (_Licenses.Count == 1)
            {
                AddFreelanceJob(new FreelanceJob(mainForm, "Minor League Deal", "Big agency paying for minor negotiation.", JobType.negotiating, 5, 3, 15000, 14, 1750));
                AddFreelanceJob(new FreelanceJob(mainForm, "Diamond In The Rough", "Scout your first unsigned player.", JobType.scouting, 7, 5, 0, 28, 3500));
            }
        }
        public void AddFreelanceJob(FreelanceJob job)
        {
            _FreelanceJobsAvailable.Add(job);
        }
        public void PayOfficeMonthlyRent()
        {
            AddMoney(-Office.MonthlyCost);
            mainForm.UpdateAgencyMoneyLabel();
        }
        public void AddDayWorking(Agent a)
        {
            a.DaysWorkingOnJob++;
            DetermineIfEfficiencyDrops(a);
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
                if (a.Role == Role.Agent)
                    mainForm.world.MyAgency.DisplayAllAgents();
            }
        }
        public void DisplayAllAgents()
        {
            foreach (Control c in mainForm.agentGroupBoxes)
                c.Visible = false;
            if (AgentList.Count > 0)
            {
                for (int i = 0; i < AgentList.Count; i++)
                {
                    mainForm.agentGroupBoxes[i].Visible = true;
                    mainForm.agentNames[i].Text = AgentList[i].FullName;
                    mainForm.agentIntelligences[i].Text = "INT: " + AgentList[i].Intelligence.ToString();
                    mainForm.agentGreeds[i].Text = "GRD: " + AgentList[i].Greed.ToString();
                    mainForm.agentNegotiations[i].Text = "NEG: " + AgentList[i].Negotiating.ToString();
                    mainForm.agentScoutings[i].Text = "SCT: " + AgentList[i].Scouting.ToString();
                    mainForm.agentPowers[i].Text = "POW: " + AgentList[i].Power.ToString();
                    mainForm.agentEfficiencies[i].Text = "EFF: " + AgentList[i].CurrentEfficiency.ToString() + "/" + AgentList[i].MaxEfficiency.ToString();
                    mainForm.agentStatusLabels[i].Text = "Status: " + AgentList[i].Status.ToString();
                    if (AgentList[i].Status == AgentStatus.Available && AgentList[i].CurrentEfficiency < AgentList[i].MaxEfficiency)
                        mainForm.agentRestButtons[i].Enabled = true;
                    else mainForm.agentRestButtons[i].Enabled = false;
                }
            }
        }
        public void AgentRest(int i)
        {
            AgentList[i].Status = AgentStatus.Resting;
            AgentList[i].DaysResting = 0;
        }
        /*public Agent FindAgent(Player player)
        {
            for (int i = 0; i < AgentList.Count; i++)
            {
                int index = AgentList[i].Clients.FindIndex(o => (o.FullName == player.FullName) && (o.Id == player.Id) && (o.Sport == player.Sport));
                if (index >= 0) return AgentList[i];
            }
            return null;
        }*/
    }
}
