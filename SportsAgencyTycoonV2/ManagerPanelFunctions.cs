using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public class ManagerPanelFunctions
    {
        MainForm mainForm;
        World world;
        string focus = "";
        int searchInvestment = 0;
        List<Agent> agentsFound = new List<Agent>();
        List<int> numbers = new List<int>();

        public List<Control> agentNames = new List<Control>();
        public List<Control> agentGreeds = new List<Control>();
        public List<Control> agentNegotiations = new List<Control>();
        public List<Control> agentScoutings = new List<Control>();
        public List<Control> agentPowers = new List<Control>();
        public List<Control> agentEfficiencies = new List<Control>();
        public List<Control> agentIntelligences = new List<Control>();
        public List<Control> agentGroupBoxes = new List<Control>();
        public List<Control> agentSalaries = new List<Control>();
        public List<Control> agentHireButtons = new List<Control>();

        int totalIncome = 0;
        int totalExpenses = 0;

        public ManagerPanelFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
            AddAgentLabelsToList();
            HideAgentGroupBoxes();
            FillManagerActionsCB();
            HideManagerPanelFunctionPanels();
        }
        #region Panel Visibility
        public void ShowManagerPanel()
        {
            mainForm.managerPanel.Visible = true;
            HideManagerPanelFunctionPanels();
        }
        public void HideManagerPanelFunctionPanels()
        {
            mainForm.agentHiringPanel.Visible = false;
            mainForm.agencyFinancesPanel.Visible = false;
        }
        public void ShowAgencyFinancesPanel()
        {
            HideManagerPanelFunctionPanels();
            mainForm.agencyFinancesPanel.Visible = true;
            DisplayIncomeSources();
            DisplayExpenses();
        }
        public void ShowAgentHiringPanel()
        {
            HideManagerPanelFunctionPanels();
            mainForm.agentHiringPanel.Visible = true;
        }
        #endregion
        public void FillManagerActionsCB()
        {
            mainForm.cbManagerPanelActions.Items.Clear();
            mainForm.cbManagerPanelActions.Items.Add("View Agency Finances");
            mainForm.cbManagerPanelActions.Items.Add("Hire New Agent");
        }
        #region Hire Agent Region
        private void AddAgentLabelsToList()
        {
            agentGroupBoxes.Add(mainForm.gbScoutedAgent1);
            agentGroupBoxes.Add(mainForm.gbScoutedAgent2);
            agentGroupBoxes.Add(mainForm.gbScoutedAgent3);
            agentGroupBoxes.Add(mainForm.gbScoutedAgent4);
            agentNames.Add(mainForm.lblScoutedAgent1Name);
            agentNames.Add(mainForm.lblScoutedAgent2Name);
            agentNames.Add(mainForm.lblScoutedAgent3Name);
            agentNames.Add(mainForm.lblScoutedAgent4Name);
            agentNegotiations.Add(mainForm.lblScoutedAgent1NEG);
            agentNegotiations.Add(mainForm.lblScoutedAgent2NEG);
            agentNegotiations.Add(mainForm.lblScoutedAgent3NEG);
            agentNegotiations.Add(mainForm.lblScoutedAgent4NEG);
            agentGreeds.Add(mainForm.lblScoutedAgent1GRD);
            agentGreeds.Add(mainForm.lblScoutedAgent2GRD);
            agentGreeds.Add(mainForm.lblScoutedAgent3GRD);
            agentGreeds.Add(mainForm.lblScoutedAgent4GRD);
            agentScoutings.Add(mainForm.lblScoutedAgent1SCT);
            agentScoutings.Add(mainForm.lblScoutedAgent2SCT);
            agentScoutings.Add(mainForm.lblScoutedAgent3SCT);
            agentScoutings.Add(mainForm.lblScoutedAgent4SCT);
            agentPowers.Add(mainForm.lblScoutedAgent1POW);
            agentPowers.Add(mainForm.lblScoutedAgent2POW);
            agentPowers.Add(mainForm.lblScoutedAgent3POW);
            agentPowers.Add(mainForm.lblScoutedAgent4POW);
            agentEfficiencies.Add(mainForm.lblScoutedAgent1EFF);
            agentEfficiencies.Add(mainForm.lblScoutedAgent2EFF);
            agentEfficiencies.Add(mainForm.lblScoutedAgent3EFF);
            agentEfficiencies.Add(mainForm.lblScoutedAgent4EFF);
            agentIntelligences.Add(mainForm.lblScoutedAgent1INT);
            agentIntelligences.Add(mainForm.lblScoutedAgent2INT);
            agentIntelligences.Add(mainForm.lblScoutedAgent3INT);
            agentIntelligences.Add(mainForm.lblScoutedAgent4INT);
            agentSalaries.Add(mainForm.lblScoutedAgent1Salary);
            agentSalaries.Add(mainForm.lblScoutedAgent2Salary);
            agentSalaries.Add(mainForm.lblScoutedAgent3Salary);
            agentSalaries.Add(mainForm.lblScoutedAgent4Salary);
            agentHireButtons.Add(mainForm.btnHireAgent1);
            agentHireButtons.Add(mainForm.btnHireAgent2);
            agentHireButtons.Add(mainForm.btnHireAgent3);
            agentHireButtons.Add(mainForm.btnHireAgent4);
        }
        public void DisplayInfo()
        {
            mainForm.lblManagerActionsAndName.Text = world.MyAgency.Manager.FullName + "'s Office";
            mainForm.rbBalancedAgent.Checked = false;
            mainForm.rbNegotiatingAgent.Checked = false;
            mainForm.rbGreedAgent.Checked = false;
            mainForm.rbScoutingAgent.Checked = false;
            mainForm.rbPowerAgent.Checked = false;
            mainForm.rb25kAgent.Checked = false;
            mainForm.rb50kAgent.Checked = false;
            mainForm.rb100kAgent.Checked = false;
            mainForm.rb250kAgent.Checked = false;
            mainForm.rb500kAgent.Checked = false;
            focus = "";
            searchInvestment = 0;
        }
        public void ChangeFocus(string s)
        {
            focus = s;
            Console.WriteLine(focus);
        }
        public void ChangeInvestmentAmount(int i)
        {
            searchInvestment = i;
            Console.WriteLine(searchInvestment.ToString("C0"));
        }
        public void SearchForAgent()
        {
            if (focus == "")
                MessageBox.Show("Select a focus for your agent search.");
            else if (searchInvestment == 0)
                MessageBox.Show("Select how much money to invest in the agenct search.");
            else if (searchInvestment > world.MyAgency.Money)
                MessageBox.Show(world.MyAgency.Name + " does not have enough money.");
            else
            {
                // agent search
                FindAgents();
            }
        }
        private void FindAgents()
        {
            agentsFound.Clear();
            HideAgentGroupBoxes();
            int agentsToFind = 2;
            Agent manager = world.MyAgency.Manager;
            double managerPoints = manager.Power + manager.Intelligence + manager.Negotiating + manager.Greed + manager.Scouting;
            double agentPoints = 0;
            double percent = 0;
            if (searchInvestment == 25000)
                percent = .75;
            else if (searchInvestment == 50000)
                percent = .9;
            else if (searchInvestment == 100000)
                percent = 1.0;
            else if (searchInvestment == 250000)
            {
                percent = 1.15;
                agentsToFind = 3;
            }                
            else //if (searchInvestment == 500000)
            {
                percent = 1.3;
                agentsToFind = 4;
            }                

            agentPoints = managerPoints * percent;

            for (int i = 0; i < agentsToFind; i++)
            {
                CreateNewAgent(Convert.ToInt32(agentPoints));
            }
            foreach (Agent a in agentsFound)
                Console.WriteLine(a.FullName + " " + a.Greed + " " + a.Negotiating + " " + a.Power + " " + a.Intelligence + " " + a.Scouting + " " + a.MaxEfficiency);

            // remove money spent on search
            world.MyAgency.AddMoney(-searchInvestment);

            DisplayScoutedAgents();
        }
        private void HideAgentGroupBoxes()
        {
            foreach (Control gb in agentGroupBoxes) gb.Visible = false;
        }
        private void DisplayScoutedAgents()
        {
            HideAgentGroupBoxes();
            for (int i = 0; i < agentsFound.Count; i++)
            {
                agentGroupBoxes[i].Visible = true;
                agentNames[i].Text = agentsFound[i].FullName;
                agentSalaries[i].Text = "Salary: " + agentsFound[i].Salary.ToString("C0");
                agentIntelligences[i].Text = "INT: " + agentsFound[i].Intelligence;
                agentNegotiations[i].Text = "NEG: " + agentsFound[i].Negotiating;
                agentPowers[i].Text = "POW: " + agentsFound[i].Power;
                agentGreeds[i].Text = "GRD: " + agentsFound[i].Greed;
                agentScoutings[i].Text = "SCT: " + agentsFound[i].Scouting;
                agentEfficiencies[i].Text = "EFF: " + agentsFound[i].MaxEfficiency;
            }
        }
        public void HireSelectedAgent(int i)
        {
            world.MyAgency.AddAgent(agentsFound[i]);
            agentsFound.RemoveAt(i);
            DisplayScoutedAgents();
        }
        private void CreateNewAgent(int points)
        {
            numbers.Clear();
            int power;
            int greed;
            int negotiating;
            int scouting;
            int intelligence;
            int pointsRemaining = points + world.rnd.Next(-10, 11);

            int averageRating = points / 5;

            int focusPoints = averageRating + world.rnd.Next(5, 16);
            pointsRemaining -= focusPoints;

            averageRating = pointsRemaining / 4;

            for (int i = 0; i < 3; i++)
            {
                int rating = averageRating + world.rnd.Next(-10, 11);
                numbers.Add(rating);
                pointsRemaining -= rating;
            }
            numbers.Add(pointsRemaining);

            if (focus == "power")
                power = focusPoints;
            else
                power = SelectRandomItem();
            if (focus == "greed")
                greed = focusPoints;
            else greed = SelectRandomItem();
            if (focus == "negotiating")
                negotiating = focusPoints;
            else negotiating = SelectRandomItem();
            if (focus == "scouting")
                scouting = focusPoints;
            else scouting = SelectRandomItem();
            if (focus == "balanced")
                intelligence = focusPoints;
            else intelligence = SelectRandomItem();

            Player p = world.MLS.FreeAgents[0];

            agentsFound.Add(new Agent(p.randomFirstName(world.rnd).ToString(), p.randomLastName(world.rnd).ToString(), Role.Agent, greed, negotiating, power, intelligence, scouting, world.rnd.Next(75, 101)));
        }
        private int SelectRandomItem()
        {
            int index = world.rnd.Next(0, numbers.Count);
            int output = numbers[index];
            numbers.RemoveAt(index);
            return output;
        }
        #endregion
        #region Agency Finances Region
        private void DisplayIncomeSources()
        {
            int moneyFromClients = 0;
            int moneyFromEndorsements = 0;


            foreach (Player client in world.MyAgency.Clients)
                moneyFromClients += Convert.ToInt32((double)client.Contract.MonthlySalary * (double)(client.Contract.AgentPercentage / 100));

            // calculate money for endorsements

            totalIncome = moneyFromClients + moneyFromEndorsements;

            mainForm.lblIncomeList.Text = "Money From Clients' Salary: " + moneyFromClients.ToString("C0") + Environment.NewLine + 
                "Money From Client Endorsements: " + moneyFromEndorsements.ToString("C0") + Environment.NewLine + 
                "TOTAL: " + totalIncome.ToString("C0"); ;
        }
        private void DisplayExpenses()
        {
            int officeRent = world.MyAgency.Office.MonthlyCost;
            int agentSalaries = 0;

            foreach (Agent a in world.MyAgency.AgentList)
                agentSalaries += a.Salary;

            totalExpenses = officeRent + agentSalaries;

            mainForm.lblExpenses.Text = "Office Rent: " + officeRent.ToString("C0") + Environment.NewLine + 
                "Agent Salaries: " + agentSalaries.ToString("C0") + Environment.NewLine + 
                "TOTAL: " + totalExpenses.ToString("C0");
        }
        #endregion

    }
}
