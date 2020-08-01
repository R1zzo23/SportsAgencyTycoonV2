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
        NegotiateAgentPercentage negotiateAgentPercentage = new NegotiateAgentPercentage();
        bool freeAgent = false;
        bool onTeam = false;
        public Sports selectedSport;
        Agent selectedAgent;
        Player selectedPlayer;
        List<SoccerPlayer> scoutedSoccerPlayers = new List<SoccerPlayer>();
        List<Player> availableClients = new List<Player>();
        List<Player> scoutedPlayers = new List<Player>();
        int scoutingSkills;
        int agentSkills;
        List<Player> players = new List<Player>();
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
            mainForm.cbAgentToScout.Items.Add(world.MyAgency.Manager.FullName + " (" + world.MyAgency.Manager.Status.ToString() + ")");
            if (world.MyAgency.AgentList.Count > 0)
                foreach (Agent a in world.MyAgency.AgentList)
                    mainForm.cbAgentToScout.Items.Add(a.FullName + " (" + a.Status.ToString() + ")");

            mainForm.cbAgentToScout.Text = "";
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
                        {
                            freeAgent = true;
                            onTeam = false;
                        }
                        else if (mainForm.rbOnTeam.Checked)
                        {
                            onTeam = true;
                            freeAgent = false;
                        }
                            

                        FillAvailableClientList();
                        DetermineWhichPlayersGetScouted();
                        FillScoutedClientComboBox();
                        FillAgentComboBox();
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
            if (selectedAgent.Status != AgentStatus.Available)
            {
                MessageBox.Show("Agent is currently busy and cannot scout.");
            }
            else
            {
                if (!p.ScoutedByAgency)
                {
                    p.ScoutedByAgency = true;
                    double variation = (1 - Convert.ToDouble(scoutingSkills) / 100) * Convert.ToDouble(p.CurrentSkill);
                    p.ScoutedSkill = world.rnd.Next(Convert.ToInt32((Convert.ToDouble(p.CurrentSkill) - variation)), Convert.ToInt32(Convert.ToDouble(p.CurrentSkill) + variation));
                    //scoutedPlayers.Add(p);
                    p.AgentThatScoutedPlayer = selectedAgent;
                    p.AgentScoutingRating = selectedAgent.Scouting;
                    selectedAgent.Status = AgentStatus.Scouting;
                    selectedAgent.PlayerBeingScouted = p;
                    selectedAgent.WorkTime = DetermineTimeToScout();
                }
            }     
        }
        public int DetermineTimeToScout()
        {
            int ticks = Convert.ToInt32(((200 - selectedAgent.Scouting) / 10));

            Console.WriteLine(selectedAgent.FullName + "'s time to scout: " + ticks);

            return ticks;
        }
        public void AddScoutedPlayerToScoutedPlayersList(Player p)
        {
            scoutedPlayers.Add(p);
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
                    if (!p.MemberOfAgency)
                    {
                        string abbrev;
                        if (p.Team != null)
                            abbrev = p.Team.Abbreviation;
                        else abbrev = "Free Agent";
                        mainForm.cbScoutedPlayers.Items.Add("[" + abbrev + "] " + p.Position.ToString() + " " + p.FullName + " [" + p.IPtoSign.ToString() + " IP]");
                    }
                }
            }
        }
        public void DisplayScoutedPlayerInfo()
        {
            DisplayStarRating();
            mainForm.lblScoutedPlayerDescription.Text = ShowScoutedPlayerDescription();
            DisplayScoutedPlayerInfo(selectedPlayer);
            mainForm.lblScoutedBy.Text = "Scouted By: " + selectedPlayer.AgentThatScoutedPlayer.FullName + " (" + selectedPlayer.AgentScoutingRating + ")";
        }
        private void DisplayStarRating()
        {
            if (mainForm.cbScoutedPlayers.SelectedIndex > -1)
            {
                mainForm.lblWSSAScouting.Visible = true;
                mainForm.lblScoutedBy.Visible = true;

                players.Clear();

                foreach (Player p in scoutedPlayers)
                    if (p.Sport == selectedSport && !p.MemberOfAgency)
                        players.Add(p);
                selectedPlayer = players[mainForm.cbScoutedPlayers.SelectedIndex];
                if (selectedPlayer.ScoutedSkill <= 20)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._1star;
                else if (selectedPlayer.ScoutedSkill <= 40)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._2star;
                else if (selectedPlayer.ScoutedSkill <= 60)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._3star;
                else if (selectedPlayer.ScoutedSkill <= 80)
                    mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._4star;
                else mainForm.starRatingPicture.Image = SportsAgencyTycoonV2.Properties.Resources._5star;

                if (selectedPlayer.WSSAScoutedSkill <= 20)
                    mainForm.wssaStarRating.Image = SportsAgencyTycoonV2.Properties.Resources._1star;
                else if (selectedPlayer.WSSAScoutedSkill <= 40)
                    mainForm.wssaStarRating.Image = SportsAgencyTycoonV2.Properties.Resources._2star;
                else if (selectedPlayer.WSSAScoutedSkill <= 60)
                    mainForm.wssaStarRating.Image = SportsAgencyTycoonV2.Properties.Resources._3star;
                else if (selectedPlayer.WSSAScoutedSkill <= 80)
                    mainForm.wssaStarRating.Image = SportsAgencyTycoonV2.Properties.Resources._4star;
                else mainForm.wssaStarRating.Image = SportsAgencyTycoonV2.Properties.Resources._5star;
            }
            else
            {
                mainForm.starRatingPicture.Image = null;
                mainForm.wssaStarRating.Image = null;
                mainForm.lblWSSAScouting.Visible = false;
                mainForm.lblScoutedBy.Visible = false;
            }
            
        }
        public void SignPlayerToAgency()
        {
            if (mainForm.cbScoutedPlayers.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a player to sign.");
            }
            else if (selectedPlayer.IPtoSign > world.MyAgency.InfluencePoints)
                MessageBox.Show("You do not have enough IP to sign this player.");
            else if (mainForm.cbAgentToScout.Text == "")
            {
                MessageBox.Show("Must select an agent to work the negotiations.");
            }
            else if (mainForm.cbAgentToScout.Text != "" && selectedAgent.Status != AgentStatus.Available)
            {
                MessageBox.Show("Agent is not available to run these negotiations.");
            }
            else
            {
                world.MyAgency.AddInfluencePoints(-selectedPlayer.IPtoSign);
                world.MyAgency.AddClient(selectedPlayer);
                selectedPlayer.MemberOfAgency = true;
                if (!selectedPlayer.FreeAgent)
                {
                    if (selectedAgent.Role == Role.Manager)
                        world.MyAgency.Manager.UpdateManagerUI(mainForm);
                    else world.MyAgency.DisplayAllAgents();
                    // negotiate agent percentage
                    negotiateAgentPercentage.NegotiatePercentage(selectedPlayer, selectedAgent, world.rnd);
                }
                mainForm.cbScoutedPlayers.Text = "";
                mainForm.cbScoutedPlayers.SelectedIndex = -1;
                FillScoutedClientComboBox();
            }
        }
        private string ShowScoutedPlayerDescription()
        {
            string description = "";

            description += selectedPlayer.LeadershipString + " " + selectedPlayer.GreedString + " " + selectedPlayer.ComposureString + " " + selectedPlayer.BehaviorString + " " + selectedPlayer.WorkEthicString;

            return description;
        }
        #region DisplayScoutedPlayerInfo
        public void DisplayScoutedPlayerInfo(Player player)
        {
            Player selectedPlayer = player;

            mainForm.lblScoutedDepthChart.Text = "Spot on Depth Chart: " + selectedPlayer.DepthChart.ToString();
            if (selectedPlayer.IsStarter) mainForm.lblStarter.Text = "Starter: yes";
            else mainForm.lblScoutedIsStarter.Text = "Starter: no";

            if (selectedPlayer.Sport == Sports.Basketball)
            {
                DisplayBasketballStats((BasketballPlayer)selectedPlayer);
            }
            else if (selectedPlayer.Sport == Sports.Football)
            {
                
                DisplayFootballStats((FootballPlayer)selectedPlayer);
            }
            else if (selectedPlayer.Sport == Sports.Baseball)
            {
                DisplayBaseballStats((BaseballPlayer)selectedPlayer);
            }
            else if (selectedPlayer.Sport == Sports.Hockey)
            {
                DisplayHockeyStats((HockeyPlayer)selectedPlayer);
            }
            else if (selectedPlayer.Sport == Sports.Soccer)
            {
                DisplaySoccerStats((SoccerPlayer)selectedPlayer);
            }

            if (selectedPlayer.Sport == Sports.Baseball)
            {
                BaseballPlayer baseballPlayer = (BaseballPlayer)selectedPlayer;
                mainForm.lblScoutedPosition.Text = "Position: " + baseballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Basketball)
            {
                BasketballPlayer basketballPlayer = (BasketballPlayer)selectedPlayer;
                mainForm.lblScoutedPosition.Text = "Position: " + basketballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Football)
            {
                FootballPlayer footballPlayer = (FootballPlayer)selectedPlayer;
                mainForm.lblScoutedPosition.Text = "Position: " + footballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Hockey)
            {
                HockeyPlayer hockeyPlayer = (HockeyPlayer)selectedPlayer;
                mainForm.lblScoutedPosition.Text = "Position: " + hockeyPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Soccer)
            {
                SoccerPlayer soccerPlayer = (SoccerPlayer)selectedPlayer;
                mainForm.lblScoutedPosition.Text = "Position: " + soccerPlayer.Position.ToString();
            }
            mainForm.lblScoutedAge.Text = "Age: " + selectedPlayer.Age.ToString();

            if (selectedPlayer.Contract != null)
            {
                mainForm.lblScoutedYearlySalary.Text = "Yearly Salary: " + selectedPlayer.Contract.YearlySalary.ToString("C0");
                mainForm.lblScoutedYearsLeft.Text = "Years Left: " + selectedPlayer.Contract.Years.ToString();
                mainForm.lblScoutedAgentPaid.Text = "Agent Paid: " + selectedPlayer.Contract.AgentPaySchedule.ToString();
                mainForm.lblScoutedAgentPercent.Text = "Agent Percentage: " + selectedPlayer.Contract.AgentPercentage.ToString() + "%";
            }
            else
            {
                mainForm.lblScoutedYearlySalary.Text = "Yearly Salary: n/a";
                mainForm.lblScoutedYearsLeft.Text = "Years Left: n/a";
                mainForm.lblScoutedAgentPaid.Text = "Agent Paid: n/a";
                mainForm.lblScoutedAgentPercent.Text = "Agent Percentage: n/a";
            }
            
            mainForm.lblScoutedPopularity.Text = "Popularity: " + selectedPlayer.PopularityString;
            mainForm.lblScoutedTeamHappiness.Text = "Team Happiness: " + selectedPlayer.TeamHappinessString;
            mainForm.lblScoutedAgencyHappiness.Text = "Agency Happiness: " + selectedPlayer.AgencyHappinessString;
        }
        public void DisplayBasketballStats(BasketballPlayer player)
        {
            mainForm.lblScoutedStats.Text = "PTS: " + player.Points.ToString("0.##") + Environment.NewLine + "REB: " + player.Rebounds.ToString("0.##") + Environment.NewLine
                + "AST: " + player.Assists.ToString("0.##") + Environment.NewLine + "BLK: " + player.Blocks.ToString("0.##") + Environment.NewLine
                + "STL: " + player.Steals.ToString("0.##");
        }
        public void DisplayFootballStats(FootballPlayer player)
        {
            if (player.Position == Position.QB) mainForm.lblScoutedStats.Text = DisplayQBStats(player);
            if (player.Position == Position.RB || player.Position == Position.FB) mainForm.lblScoutedStats.Text = DisplayRushingStats(player);
            if (player.Position == Position.WR || player.Position == Position.TE) mainForm.lblScoutedStats.Text = DisplayReceivingStats(player);
            if (player.Position == Position.OT || player.Position == Position.OG || player.Position == Position.C) mainForm.lblScoutedStats.Text = DisplayOLStats(player);
            if (player.Position == Position.LB || player.Position == Position.DE || player.Position == Position.DT) mainForm.lblScoutedStats.Text = DisplayFrontSevenStats(player);
            if (player.Position == Position.CB || player.Position == Position.SS || player.Position == Position.FS) mainForm.lblScoutedStats.Text = DisplaySecondaryStats(player);
            if (player.Position == Position.K) mainForm.lblScoutedStats.Text = DisplayKickingStats(player);
            if (player.Position == Position.P) mainForm.lblScoutedStats.Text = DisplayPuntingStats(player);
        }
        public string DisplayQBStats(FootballPlayer player)
        {
            string stats = "YDS: " + player.PassingYards.ToString() + Environment.NewLine + "TDS: " + player.PassingTDs.ToString()
                + Environment.NewLine + "INT: " + player.Interceptions.ToString();
            return stats;
        }
        public string DisplayRushingStats(FootballPlayer player)
        {
            string stats = "YDS: " + player.RushingYards.ToString() + Environment.NewLine + "TDS: " + player.RushingTDs.ToString()
                + Environment.NewLine + "CAR: " + player.Carries.ToString() + Environment.NewLine + "YPC: " + player.YardsPerCarry.ToString("0.##")
                + Environment.NewLine + "CHNK: " + player.ChunkPlays.ToString() + Environment.NewLine + "FUM: " + player.Fumbles.ToString();
            return stats;
        }
        public string DisplayReceivingStats(FootballPlayer player)
        {
            string stats = "REC: " + player.Receptions.ToString() + Environment.NewLine +
                "YDS: " + player.ReceivingYards.ToString() + Environment.NewLine +
                "TDS: " + player.ReceivingTDs.ToString();
            return stats;
        }
        public string DisplayOLStats(FootballPlayer player)
        {
            string stats = "Pancakes: " + player.PancakeBlocks + Environment.NewLine + "Sacks Allowed: " + player.SacksAllowed +
                Environment.NewLine + "Rushing YPC: " + player.YardsPerCarry.ToString("0.##") + Environment.NewLine + "Rushing TDS: " + player.RushingTDs;
            return stats;
        }
        public string DisplayFrontSevenStats(FootballPlayer player)
        {
            string stats = "Tackles: " + player.Tackles + Environment.NewLine + "TFLs: " + player.TacklesForLoss
                + Environment.NewLine + "Sacks: " + player.Sacks;
            return stats;
        }
        public string DisplaySecondaryStats(FootballPlayer player)
        {
            string stats = "Tackles: " + player.Tackles + Environment.NewLine + "PDs: " + player.PassesDefended
                + Environment.NewLine + "INTs: " + player.DefensiveInterceptions + Environment.NewLine + "TFLs: " + player.TacklesForLoss;
            return stats;
        }
        public string DisplayKickingStats(FootballPlayer player)
        {
            string stats = "FGM/FGA: " + player.FGMakes + "/" + player.FGAttempts + Environment.NewLine +
                "XPM/XPA: " + player.XPMakes + "/" + player.XPAttempts;
            return stats;
        }
        public string DisplayPuntingStats(FootballPlayer player)
        {
            string stats = "Punts: " + player.Punts + Environment.NewLine + "Net Average: " + player.NetPuntAverage.ToString("0.##");
            return stats;
        }
        public void DisplayBaseballStats(BaseballPlayer player)
        {
            if (player.Position == Position.SP || player.Position == Position.RP) mainForm.lblScoutedStats.Text = DisplayPitchingStats(player);
            else mainForm.lblScoutedStats.Text = DisplayHittingStats(player);
        }
        public string DisplayHittingStats(BaseballPlayer player)
        {
            string stats = "AVG: " + player.Average.ToString(".###") + Environment.NewLine + "HRS: " + player.HomeRuns + Environment.NewLine + "RBI: " + player.RBI;
            return stats;
        }
        public string DisplayPitchingStats(BaseballPlayer player)
        {
            string stats = "ERA: " + player.ERA.ToString("0.##") + Environment.NewLine + "WINS: " + player.Wins + Environment.NewLine + "LOSSES: " + player.Losses + Environment.NewLine + "SAVES: " + player.Saves;
            return stats;
        }
        public void DisplayHockeyStats(HockeyPlayer player)
        {
            if (player.Position == Position.G) mainForm.lblScoutedStats.Text = DisplayGoalieStats(player);
            else mainForm.lblScoutedStats.Text = DisplaySkaterStats(player);
        }
        public string DisplayGoalieStats(HockeyPlayer player)
        {
            string results = "SAVE%: " + player.SavePercentage.ToString("P2") + Environment.NewLine + "GAA: " + player.GAA.ToString("0.##") + Environment.NewLine + "SHUTOUTS: " + player.ShutOuts;
            return results;
        }
        public string DisplaySkaterStats(HockeyPlayer player)
        {
            string results = "GOALS: " + player.Goals + Environment.NewLine + "ASSISTS: " + player.Assists + Environment.NewLine + "POINTS: " + player.Points;
            return results;
        }
        public string DisplayFootballTeamStats(Team t)
        {
            List<FootballPlayer> QBS = new List<FootballPlayer>();
            List<FootballPlayer> Backs = new List<FootballPlayer>();
            List<FootballPlayer> PassCatchers = new List<FootballPlayer>();
            List<FootballPlayer> OL = new List<FootballPlayer>();
            List<FootballPlayer> DL = new List<FootballPlayer>();
            List<FootballPlayer> LB = new List<FootballPlayer>();
            List<FootballPlayer> Secondary = new List<FootballPlayer>();
            List<FootballPlayer> Kicker = new List<FootballPlayer>();
            List<FootballPlayer> Punter = new List<FootballPlayer>();
            string stats = "";

            foreach (FootballPlayer p in t.Roster)
            {
                if (p.Position == Position.QB) QBS.Add(p);
                else if (p.Position == Position.RB || p.Position == Position.FB) Backs.Add(p);
                else if (p.Position == Position.WR || p.Position == Position.TE) PassCatchers.Add(p);
                else if (p.Position == Position.OT || p.Position == Position.OG || p.Position == Position.C) OL.Add(p);
                else if (p.Position == Position.DE || p.Position == Position.DT) DL.Add(p);
                else if (p.Position == Position.LB) LB.Add(p);
                else if (p.Position == Position.CB || p.Position == Position.SS || p.Position == Position.FS) Secondary.Add(p);
                else if (p.Position == Position.K) Kicker.Add(p);
                else if (p.Position == Position.P) Punter.Add(p);
            }

            QBS = QBS.OrderByDescending(o => o.PassingYards).ToList();
            Backs = Backs.OrderByDescending(o => o.RushingYards).ToList();
            PassCatchers = PassCatchers.OrderByDescending(o => o.Receptions).ToList();
            OL = OL.OrderByDescending(o => o.PancakeBlocks).ThenBy(o => o.SacksAllowed).ToList();
            DL = DL.OrderByDescending(o => o.Tackles).ThenBy(o => o.TacklesForLoss).ThenBy(o => o.Sacks).ToList();
            LB = LB.OrderByDescending(o => o.Tackles).ThenBy(o => o.TacklesForLoss).ThenBy(o => o.Sacks).ToList();
            Secondary = Secondary.OrderByDescending(o => o.Tackles).ThenBy(o => o.DefensiveInterceptions).ToList();

            foreach (FootballPlayer fp in QBS)
                stats += fp.FullName + " " + fp.PassingYards + " YDS || " + fp.PassingTDs + " TDS || " + fp.Interceptions + " INT" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in Backs)
                stats += fp.FullName + " " + fp.Carries + " CAR || " + fp.RushingYards + " YDS || " + fp.RushingTDs + " TDS || " + fp.Fumbles + " fumbles" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in PassCatchers)
                stats += fp.FullName + " " + fp.Receptions + " REC || " + fp.ReceivingYards + " YDS || " + fp.ReceivingTDs + " TDS || " + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in OL)
                stats += fp.FullName + " " + fp.PancakeBlocks + " PANCAKES || " + fp.SacksAllowed + " SACKS ALLOWED" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in DL)
                stats += fp.FullName + " " + fp.Tackles + " TKLS || " + fp.TacklesForLoss + " TFL || " + fp.Sacks + " SACKS" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in LB)
                stats += fp.FullName + " " + fp.Tackles + " TKLS || " + fp.TacklesForLoss + " TFL || " + fp.Sacks + " SACKS" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in Secondary)
                stats += fp.FullName + " " + fp.Tackles + " TKLS || " + fp.DefensiveInterceptions + " INT || " + fp.TacklesForLoss + " TFL" + Environment.NewLine;
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in Kicker)
                stats += fp.FullName + " " + fp.FGMakes + "/" + fp.FGAttempts + " FGM/FGA || " + fp.XPMakes + "/" + fp.XPAttempts + " XPM/XPA";
            stats += Environment.NewLine;
            foreach (FootballPlayer fp in Punter)
                stats += fp.FullName + " " + fp.Punts + " Punts || " + fp.NetPuntAverage.ToString("0.##") + " NET AVG";

            return stats;
        }
        private void DisplaySoccerStats(SoccerPlayer player)
        {
            if (player.Position == Position.GK)
                mainForm.lblScoutedStats.Text = DisplayKeeperStats(player);
            else mainForm.lblScoutedStats.Text = DisplayNonKeeperStats(player);
        }
        private string DisplayKeeperStats(SoccerPlayer player)
        {
            string results = "SAVES: " + player.Saves + Environment.NewLine + "SAVE%: " + player.SavePercentage.ToString("P2") + Environment.NewLine + "GA: " + player.GoalsAllowed + Environment.NewLine + "GAA: " + player.GAA.ToString("0.##") + Environment.NewLine + "Clean Sheets: " + player.CleanSheets;
            return results;
        }
        private string DisplayNonKeeperStats(SoccerPlayer player)
        {
            string stats = "GOALS: " + player.Goals + Environment.NewLine + "ASSISTS: " + player.Assists + Environment.NewLine + "Rating: " + player.MatchRating.ToString("#.00");
            return stats;
        }
        #endregion
    }
}
