using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class TeamRosterPanelFunctions
    {
        MainForm mainForm;
        World world;

        public TeamRosterPanelFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }
        public void FillTeamComboBox(League l)
        {
            mainForm.cbTeamList.Items.Clear();
            foreach (Team t in l.TeamList)
                mainForm.cbTeamList.Items.Add(t.City + " " + t.Mascot);
        }
        public void FillTeamInfo()
        {
            League selectedLeague = world.Leagues[mainForm.cbLeagueList.SelectedIndex];
            Team selectedTeam = world.Leagues[mainForm.cbLeagueList.SelectedIndex].TeamList[mainForm.cbTeamList.SelectedIndex];

            mainForm.lblTeamAwards.Text = "";
            if (selectedTeam.Awards.Count > 0)
                foreach (Award award in selectedTeam.Awards)
                    mainForm.lblTeamAwards.Text += award.Year + " " + award.AwardName + Environment.NewLine;

            mainForm.lblRoster.Text = "[POS] LAST, FIRST:                CUR/POT          AGE" + Environment.NewLine;
            if (selectedLeague.Sport == Sports.Hockey)
            {
                mainForm.lblTeamInfo.Text = selectedTeam.City + " " + selectedTeam.Mascot + "(" + selectedTeam.Wins + "-" + selectedTeam.Losses + "-" + selectedTeam.OTLosses + ")   Title Contender (" + selectedTeam.TitleConteder + ") || Market Value: (" + selectedTeam.MarketValue + ")";
            }
            else if (selectedLeague.Sport == Sports.Soccer)
            {
                mainForm.lblTeamInfo.Text = selectedTeam.City + " " + selectedTeam.Mascot + "(" + selectedTeam.Wins + "-" + selectedTeam.Losses + "-" + selectedTeam.Ties + ")   Title Contender (" + selectedTeam.TitleConteder + ") || Market Value: (" + selectedTeam.MarketValue + ")";
            }
            else
            {
                mainForm.lblTeamInfo.Text = selectedTeam.City + " " + selectedTeam.Mascot + "(" + selectedTeam.Wins + "-" + selectedTeam.Losses + ")   Title Contender (" + selectedTeam.TitleConteder + ") || Market Value: (" + selectedTeam.MarketValue + ")";
            }

            if (selectedLeague.Sport == Sports.Basketball)
                foreach (BasketballPlayer p in selectedTeam.Roster)
                    mainForm.lblRoster.Text += "[" + p.Position.ToString() + "] " + p.LastName + ", " + p.FirstName + ": " + p.CurrentSkill + "/" + p.PotentialSkill + " - " + p.Age + "-years old" + p.AgencyHappinessString + " " + p.TeamHappinessString + " " + p.PopularityString + Environment.NewLine;
            else if (selectedLeague.Sport == Sports.Football)
                mainForm.lblRoster.Text = DisplayFootballTeamStats(selectedTeam);
            //foreach (FootballPlayer p in selectedTeam.Roster)
            //lblRoster.Text += "[" + p.Position.ToString() + "] " + p.LastName + ", " + p.FirstName + ": " + p.CurrentSkill + "/" + p.PotentialSkill + " - " + p.Age + "-years old" + Environment.NewLine;
            if (selectedLeague.Sport == Sports.Baseball)
                foreach (BaseballPlayer p in selectedTeam.Roster)
                    mainForm.lblRoster.Text += "[" + p.Position.ToString() + "] " + p.LastName + ", " + p.FirstName + ": " + p.CurrentSkill + "/" + p.PotentialSkill + " - " + p.Age + "-years old" + Environment.NewLine;
            if (selectedLeague.Sport == Sports.Hockey)
                foreach (HockeyPlayer p in selectedTeam.Roster)
                    mainForm.lblRoster.Text += "[" + p.Position.ToString() + "] " + p.LastName + ", " + p.FirstName + ": " + p.CurrentSkill + "/" + p.PotentialSkill + " - " + p.Age + "-years old" + Environment.NewLine;
            if (selectedLeague.Sport == Sports.Soccer)
                foreach (SoccerPlayer p in selectedTeam.Roster)
                    mainForm.lblRoster.Text += "[" + p.Position.ToString() + "] " + p.LastName + ", " + p.FirstName + ": " + p.CurrentSkill + "/" + p.PotentialSkill + " - " + p.Age + "-years old" + Environment.NewLine;
        }
        public void FillTeamRosterComboBox(Team t)
        {
            mainForm.cbTeamRoster.Items.Clear();
            foreach (Player p in t.Roster)
                mainForm.cbTeamRoster.Items.Add(p.Position.ToString() + " " + p.FullName);
        }
        public void DisplaySelectedPlayerInfo(Player player)
        {
            League selectedLeague = world.Leagues[mainForm.cbLeagueList.SelectedIndex];
            Team selectedTeam = selectedLeague.TeamList[mainForm.cbTeamList.SelectedIndex];
            Player selectedPlayer = player;

            mainForm.lblDepthChart.Text = "Spot on Depth Chart: " + selectedPlayer.DepthChart.ToString();
            if (selectedPlayer.IsStarter) mainForm.lblStarter.Text = "Starter: yes";
            else mainForm.lblStarter.Text = "Starter: no";

            if (selectedLeague.Sport == Sports.Basketball)
            {
                List<BasketballPlayer> hoopsRoster = new List<BasketballPlayer>();
                foreach (BasketballPlayer bp in selectedTeam.Roster)
                    hoopsRoster.Add(bp);
                DisplayBasketballStats(hoopsRoster[mainForm.cbTeamRoster.SelectedIndex]);
            }
            else if (selectedLeague.Sport == Sports.Football)
            {
                List<FootballPlayer> footballRoster = new List<FootballPlayer>();
                foreach (FootballPlayer fp in selectedTeam.Roster)
                    footballRoster.Add(fp);
                DisplayFootballStats(footballRoster[mainForm.cbTeamRoster.SelectedIndex]);
            }
            else if (selectedLeague.Sport == Sports.Baseball)
            {
                List<BaseballPlayer> baseballRoster = new List<BaseballPlayer>();
                foreach (BaseballPlayer p in selectedTeam.Roster)
                    baseballRoster.Add(p);
                DisplayBaseballStats(baseballRoster[mainForm.cbTeamRoster.SelectedIndex]);
            }
            else if (selectedLeague.Sport == Sports.Hockey)
            {
                List<HockeyPlayer> hockeyRoster = new List<HockeyPlayer>();
                foreach (HockeyPlayer p in selectedTeam.Roster)
                    hockeyRoster.Add(p);
                DisplayHockeyStats(hockeyRoster[mainForm.cbTeamRoster.SelectedIndex]);
            }
            else if (selectedLeague.Sport == Sports.Soccer)
            {
                List<SoccerPlayer> soccerRoster = new List<SoccerPlayer>();
                foreach (SoccerPlayer p in selectedTeam.Roster)
                    soccerRoster.Add(p);
                DisplaySoccerStats(soccerRoster[mainForm.cbTeamRoster.SelectedIndex]);
            }

            if (selectedPlayer.Sport == Sports.Baseball)
            {
                BaseballPlayer baseballPlayer = (BaseballPlayer)selectedPlayer;
                mainForm.lblPosition.Text = "Position: " + baseballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Basketball)
            {
                BasketballPlayer basketballPlayer = (BasketballPlayer)selectedPlayer;
                mainForm.lblPosition.Text = "Position: " + basketballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Football)
            {
                FootballPlayer footballPlayer = (FootballPlayer)selectedPlayer;
                mainForm.lblPosition.Text = "Position: " + footballPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Hockey)
            {
                HockeyPlayer hockeyPlayer = (HockeyPlayer)selectedPlayer;
                mainForm.lblPosition.Text = "Position: " + hockeyPlayer.Position.ToString();
            }
            else if (selectedPlayer.Sport == Sports.Soccer)
            {
                SoccerPlayer soccerPlayer = (SoccerPlayer)selectedPlayer;
                mainForm.lblPosition.Text = "Position: " + soccerPlayer.Position.ToString();
            }
            mainForm.lblFullName.Text = selectedPlayer.FullName;
            mainForm.lblAge.Text = "Age: " + selectedPlayer.Age.ToString();
            mainForm.lblSkillLevel.Text = "Skill Level: " + selectedPlayer.CurrentSkill.ToString() + "/" + selectedPlayer.PotentialSkill.ToString();

            mainForm.lblYearlySalary.Text = "Yearly Salary: " + selectedPlayer.Contract.YearlySalary.ToString("C0");
            mainForm.lblYearsLeft.Text = "Years Left: " + selectedPlayer.Contract.Years.ToString();
            mainForm.lblAgentPaid.Text = "Agent Paid: " + selectedPlayer.Contract.AgentPaySchedule.ToString();
            mainForm.lblAgentPercent.Text = "Agent Percentage: " + selectedPlayer.Contract.AgentPercentage.ToString() + "%";

            mainForm.lblPopularity.Text = "Popularity: " + selectedPlayer.PopularityString;
            mainForm.lblGreed.Text = "Greed: " + selectedPlayer.Greed.ToString();
            mainForm.lblLifestyle.Text = "Lifestyle: " + selectedPlayer.Lifestyle.ToString();
            mainForm.lblLoyalty.Text = "Loyalty: " + selectedPlayer.Loyalty.ToString();
            mainForm.lblPlayForTitle.Text = "Play for Title: " + selectedPlayer.PlayForTitleContender.ToString();
            mainForm.lblTeamHappiness.Text = "Team Happiness: " + selectedPlayer.TeamHappinessString;
            mainForm.lblAgencyHappiness.Text = "Agency Happiness: " + selectedPlayer.AgencyHappinessString;
        }
        public void DisplayBasketballStats(BasketballPlayer player)
        {
            mainForm.lblStats.Text = "PTS: " + player.Points.ToString("0.##") + Environment.NewLine + "REB: " + player.Rebounds.ToString("0.##") + Environment.NewLine
                + "AST: " + player.Assists.ToString("0.##") + Environment.NewLine + "BLK: " + player.Blocks.ToString("0.##") + Environment.NewLine
                + "STL: " + player.Steals.ToString("0.##");
        }
        public void DisplayFootballStats(FootballPlayer player)
        {
            if (player.Position == Position.QB) mainForm.lblStats.Text = DisplayQBStats(player);
            if (player.Position == Position.RB || player.Position == Position.FB) mainForm.lblStats.Text = DisplayRushingStats(player);
            if (player.Position == Position.WR || player.Position == Position.TE) mainForm.lblStats.Text = DisplayReceivingStats(player);
            if (player.Position == Position.OT || player.Position == Position.OG || player.Position == Position.C) mainForm.lblStats.Text = DisplayOLStats(player);
            if (player.Position == Position.LB || player.Position == Position.DE || player.Position == Position.DT) mainForm.lblStats.Text = DisplayFrontSevenStats(player);
            if (player.Position == Position.CB || player.Position == Position.SS || player.Position == Position.FS) mainForm.lblStats.Text = DisplaySecondaryStats(player);
            if (player.Position == Position.K) mainForm.lblStats.Text = DisplayKickingStats(player);
            if (player.Position == Position.P) mainForm.lblStats.Text = DisplayPuntingStats(player);
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
            if (player.Position == Position.SP || player.Position == Position.RP) mainForm.lblStats.Text = DisplayPitchingStats(player);
            else mainForm.lblStats.Text = DisplayHittingStats(player);
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
            if (player.Position == Position.G) mainForm.lblStats.Text = DisplayGoalieStats(player);
            else mainForm.lblStats.Text = DisplaySkaterStats(player);
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
                mainForm.lblStats.Text = DisplayKeeperStats(player);
            else mainForm.lblStats.Text = DisplayNonKeeperStats(player);
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
    }
}
