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

        public ManagerPanelFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
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
                agentsToFind = 3;
            }                

            agentPoints = managerPoints * percent;

            for (int i = 0; i < agentsToFind; i++)
            {
                CreateNewAgent(Convert.ToInt32(agentPoints));
            }
            foreach (Agent a in agentsFound)
                Console.WriteLine(a.FullName + " " + a.Greed + " " + a.Negotiating + " " + a.Power + " " + a.Intelligence + " " + a.Scouting + " " + a.MaxEfficiency);
        }
        private void CreateNewAgent(int points)
        {
            numbers.Clear();
            int power;
            int greed;
            int negotiating;
            int scouting;
            int intelligence;
            int pointsRemaining = points;

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
    }
}
