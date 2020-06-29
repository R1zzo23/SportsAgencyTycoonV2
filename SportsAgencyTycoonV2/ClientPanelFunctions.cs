using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public class ClientPanelFunctions
    {
        MainForm mainForm;
        World world;
        bool freeAgent = false;
        bool onTeam = false;
        Sports selectedSport;
        List<SoccerPlayer> scoutedSoccerPlayers = new List<SoccerPlayer>();
        List<Player> availableClients = new List<Player>();
        int scoutingSkills;
        int agentSkills;
        public ClientPanelFunctions (MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }
        public void FillSportComboBox()
        {
            mainForm.cbClientSport.Items.Clear();
            foreach (Sports s in world.MyAgency.Licenses)
            {
                mainForm.cbClientSport.Items.Add(s.ToString());
            }
        }
        public void SearchForClient()
        {
            DetermineSportAndPlayerStatus();
            FillAvailableClientList();
            DetermineWhichPlayersGetScouted();
            FillScoutedClientComboBox();
        }
        private void DetermineSportAndPlayerStatus()
        {
            if (mainForm.cbClientSport.SelectedIndex > -1)
            {
                selectedSport = world.MyAgency.Licenses[mainForm.cbClientSport.SelectedIndex];
                if (!mainForm.rbFreeAgent.Checked && !mainForm.rbOnTeam.Checked && !mainForm.rbEither.Checked)
                    MessageBox.Show("Check one of the options to search.");
                else
                {
                    if (mainForm.rbEither.Checked)
                    {
                        freeAgent = true;
                        onTeam = true;
                    }
                    else if (mainForm.rbFreeAgent.Checked)
                        freeAgent = true;
                    else if (mainForm.rbOnTeam.Checked)
                        onTeam = true;
                }
            }
        }
        private void DetermineWhichPlayersGetScouted()
        {
            int numberOfPlayersScouted = 1;
            if (scoutingSkills >= 75) numberOfPlayersScouted++;
            if (scoutingSkills >= 125) numberOfPlayersScouted++;
            if (scoutingSkills >= 200) numberOfPlayersScouted++;

            for (int i = 0; i < numberOfPlayersScouted; i++)
            {
                int index = world.rnd.Next(0, availableClients.Count);
                ScoutPlayer(availableClients[index]);
            }
        }
        private void ScoutPlayer(Player p)
        {
            p.ScoutedByAgency = true;
            int variation = (scoutingSkills / 100) * p.CurrentSkill;
            p.ScoutedSkill = world.rnd.Next((p.CurrentSkill - variation), p.CurrentSkill + variation);
        }
        private void FillAvailableClientList()
        {
            availableClients.Clear();
            scoutingSkills = (int)(world.MyAgency.Manager.Scouting * .75);
            agentSkills = (int)((world.MyAgency.Manager.Power + world.MyAgency.Manager.Intelligence + world.MyAgency.Manager.Negotiating) * .25);

            /*foreach (Agent a in world.MyAgency.AgentList)
            {
                scoutingSkills += (int)(a.Scouting * .75);
                agentSkills += (int)((a.Power + a.Intelligence + a.Negotiating) * .75);
            }*/

            Console.WriteLine("Total Scouting Skills: " + scoutingSkills);
            Console.WriteLine("Total Agent Skills: " + agentSkills);

            if (freeAgent)
            {
                foreach (Player p in world.Leagues[world.Leagues.FindIndex(o => o.Sport == selectedSport)].FreeAgents)
                {
                    if ((p.WillingToNegotiate) && (p.AgencyHappinessDescription == HappinessDescription.Disgruntled || p.AgencyHappinessDescription == HappinessDescription.Displeased) && (p.CurrentSkill + p.PotentialSkill) < agentSkills)
                        availableClients.Add(p);
                }
            }
            if (onTeam)
            {
                foreach (Team t in world.Leagues[world.Leagues.FindIndex(o => o.Sport == selectedSport)].TeamList)
                    foreach (Player p in t.Roster)
                    {
                        if ((p.WillingToNegotiate) && (p.AgencyHappinessDescription == HappinessDescription.Disgruntled || p.AgencyHappinessDescription == HappinessDescription.Displeased) && (p.CurrentSkill + p.PotentialSkill) < agentSkills)
                            availableClients.Add(p);
                    }
            }
        }
        private void FillScoutedClientComboBox()
        {
            mainForm.cbScoutedPlayers.Items.Clear();
            foreach (Player p in availableClients)
            {
                if (p.ScoutedByAgency)
                {
                    string abbrev;
                    if (p.Team != null)
                        abbrev = p.Team.Abbreviation;
                    else abbrev = "Free Agent";
                    mainForm.cbScoutedPlayers.Items.Add("[" + abbrev + "] " + p.Position.ToString() + " " + p.FullName + " " + p.ScoutedSkill.ToString());
                }
            }
        }
    }
}
