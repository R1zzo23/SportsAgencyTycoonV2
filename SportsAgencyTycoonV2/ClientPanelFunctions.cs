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
        public Sports selectedSport;
        Agent selectedAgent;
        List<SoccerPlayer> scoutedSoccerPlayers = new List<SoccerPlayer>();
        List<Player> availableClients = new List<Player>();
        List<Player> scoutedPlayers = new List<Player>();
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
        public void FillAgentComboBox()
        {
            mainForm.cbAgentToScout.Items.Clear();
            mainForm.cbAgentToScout.Items.Add(world.MyAgency.Manager.FullName);
            if (world.MyAgency.AgentList.Count > 0)
                foreach (Agent a in world.MyAgency.AgentList)
                    mainForm.cbAgentToScout.Items.Add(a.FullName);
        }
        public void SearchForClient()
        {
            DetermineSportAndPlayerStatus();
        }
        private void DetermineSportAndPlayerStatus()
        {
            if (mainForm.cbClientSport.SelectedIndex > -1)
            {
                if (mainForm.cbAgentToScout.SelectedIndex == -1)
                {
                    MessageBox.Show("Must select an agent to do the scouting.");
                }
                else
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

                        FillAvailableClientList();
                        DetermineWhichPlayersGetScouted();
                        FillScoutedClientComboBox();
                    }
                }
            }
        }
        public void SelectAgentToScout()
        {
            if (mainForm.cbAgentToScout.SelectedIndex == 0)
                selectedAgent = world.MyAgency.Manager;
            else
                selectedAgent = world.MyAgency.AgentList[mainForm.cbAgentToScout.SelectedIndex - 1];
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
            if (!p.ScoutedByAgency)
            {
                p.ScoutedByAgency = true;
                double variation = (1 - Convert.ToDouble(scoutingSkills) / 100) * Convert.ToDouble(p.CurrentSkill);
                p.ScoutedSkill = world.rnd.Next(Convert.ToInt32((Convert.ToDouble(p.CurrentSkill) - variation)), Convert.ToInt32(Convert.ToDouble(p.CurrentSkill) + variation));
                scoutedPlayers.Add(p);
            }            
        }
        private void FillAvailableClientList()
        {
            availableClients.Clear();
            scoutingSkills = (int)(selectedAgent.Scouting * .5);
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
        public void FillScoutedClientComboBox()
        {
            mainForm.cbScoutedPlayers.Items.Clear();
            foreach (Player p in scoutedPlayers)
            {
                if (p.Sport == selectedSport)
                {
                    string abbrev;
                    if (p.Team != null)
                        abbrev = p.Team.Abbreviation;
                    else abbrev = "Free Agent";
                    mainForm.cbScoutedPlayers.Items.Add("[" + abbrev + "] " + p.Position.ToString() + " " + p.FullName + " Scouted: " + p.ScoutedSkill.ToString() + " Actual: " + p.CurrentSkill.ToString());
                }
            }
        }
        public void DisplayScoutedPlayerInfo()
        {
            if (mainForm.cbScoutedPlayers.SelectedIndex > -1)
            {
                List<Player> players = new List<Player>();
                foreach (Player p in scoutedPlayers)
                    if (p.Sport == selectedSport)
                        players.Add(p);
                Player scoutedPlayer = players[mainForm.cbScoutedPlayers.SelectedIndex];
                if (scoutedPlayer.ScoutedSkill <= 20)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._1star;
                else if (scoutedPlayer.ScoutedSkill <= 40)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._2star;
                else if (scoutedPlayer.ScoutedSkill <= 60)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._3star;
                else if (scoutedPlayer.ScoutedSkill <= 80)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._4star;
                else mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._5star;
            }
            else mainForm.starRatingPicture.Image = null;
        }
    }
}
