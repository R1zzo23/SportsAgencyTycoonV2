﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Hockey
    {
        public MainForm mainForm;
        public Random rnd;
        public League NHL;
        public World World;
        public HockeyDraft hockeyDraft;
        public int gamesThisWeek = 0;
        public int gamesForStarter = 0;
        public int gamesForBackup = 0;
        public int starterWins = 0;
        public int backupWins = 0;
        public int index;
        public int losingIndex;
        public List<string> Conferences;
        public List<string> Divisions;
        public List<Team> EasternConference = new List<Team>();
        public List<Team> WesternConference = new List<Team>();
        public List<Team> Metropolitan = new List<Team>();
        public List<Team> Atlantic = new List<Team>();
        public List<Team> Central = new List<Team>();
        public List<Team> Pacific = new List<Team>();
        public List<Team> EasternPlayoffs = new List<Team>();
        public List<Team> WesternPlayoffs = new List<Team>();
        public List<int> EasternLoserIndex = new List<int>();
        public List<int> WesternLoserIndex = new List<int>();
        public List<BasketballPlayer> DPOYCandidates = new List<BasketballPlayer>();
        public Hockey(MainForm mf, Random r, World w, League l)
        {
            mainForm = mf;
            rnd = r;
            World = w;
            NHL = l;
            hockeyDraft = new HockeyDraft(rnd, w, l);
            index = 1;
            Conferences = new List<string>();
            Divisions = new List<string>();
            FillLists();
        }
        private void FillLists()
        {
            foreach (Team t in NHL.TeamList)
                if (t.Conference == "Eastern")
                {
                    EasternConference.Add(t);
                    if (t.Division == "Metropolitan") Metropolitan.Add(t);
                    else Atlantic.Add(t);
                }
                else
                {
                    WesternConference.Add(t);
                    if (t.Division == "Central") Central.Add(t);
                    else Pacific.Add(t);
                }
        }
        public void SimWeek()
        {
            //if (NHL.WeekNumber == 0)
            //InitializeGAA();

            if (World.calendar.Month == 3 && World.calendar.Week == 5)
            {
                //mainForm.newsLabel.Text += Environment.NewLine + "NHL draft entrants finalized!" + Environment.NewLine + mainForm.newsLabel.Text;
                World.Hockey.hockeyDraft.CreateDraftEntrants();
            }

            NHL.WeekNumber++;
            if (!NHL.Playoffs)
            {
                SimulateGames();
                foreach (Team t in NHL.TeamList)
                    CalculateTeamPoints(t);
                UpdateStats();
            }
            if (NHL.WeekNumber == 31)
            {
                NHL.Playoffs = true;
                foreach (Team t in NHL.TeamList)
                {
                    foreach (HockeyPlayer p in t.Roster)
                    {
                        if (p.Position == Position.W || p.Position == Position.C || p.Position == Position.D)
                            CalculatePlayerOfTheYearScore(p);
                        else if (p.Position == Position.G)
                            CalculateGoalieOfTheYearScore(p);
                    }
                }
                //mainForm.newsLabel.Text = DisplayForwardOfTheYearTop5() + Environment.NewLine + mainForm.newsLabel.Text;
                //mainForm.newsLabel.Text = DisplayDefensemanOfTheYearTop5() + Environment.NewLine + mainForm.newsLabel.Text;
                //mainForm.newsLabel.Text = DisplayGoalieOfTheYearTop5() + Environment.NewLine + mainForm.newsLabel.Text;

                //mainForm.newsLabel.Text = DeterminePlayoffField() + Environment.NewLine + mainForm.newsLabel.Text;

                DisplayForwardOfTheYearTop5();
                DisplayDefensemanOfTheYearTop5();
                DisplayGoalieOfTheYearTop5();
                DeterminePlayoffField();
            }
            if (NHL.Playoffs)
            {
                if (NHL.WeekNumber == 32 || NHL.WeekNumber == 33 || NHL.WeekNumber == 34) SimulatePlayoffRound();  //mainForm.newsLabel.Text = SimulatePlayoffRound() + Environment.NewLine + mainForm.newsLabel.Text;
                else if (NHL.WeekNumber == 35) SimulateStanleyCup(); //mainForm.newsLabel.Text = SimulateStanleyCup() + Environment.NewLine + mainForm.newsLabel.Text;
            }
        }
        #region Statistics
        private void UpdateStats()
        {
            foreach (Team t in NHL.TeamList)
            {
                int gamesForStarterRoll = DiceRoll();

                if (gamesForStarterRoll >= 8) gamesForStarter = gamesThisWeek - 1;
                else gamesForStarter = gamesThisWeek;

                gamesForBackup = gamesThisWeek - gamesForStarter;

                foreach (HockeyPlayer p in t.Roster)
                {
                    if (p.Position == Position.G)
                    {
                        if (p.DepthChart == 1)
                            p.GamesPlayed += gamesForStarter;
                        else
                            p.GamesPlayed += gamesForBackup;

                        /*if (t.WinsThisWeek > 0)
                            DetermineGoalieWins(t.WinsThisWeek);
                        else
                        {
                            starterWins = 0;
                            backupWins = 0;
                        }*/

                        DetermineShotsFaced(p);
                    }
                    else if (p.Position == Position.C || p.Position == Position.W || p.Position == Position.D)
                    {
                        DetermineGoalsScored(p);
                        DetermineAssists(p);
                        CalculatePoints(p);
                    }
                }
            }

        }
        private void DetermineGoalsScored(HockeyPlayer p)
        {
            int playerDiceRoll = 0;
            int neededDiceNumber = 0;
            int numberOfRolls = 0;
            if (p.Position == Position.W || p.Position == Position.C)
            {
                if (p.CurrentSkill >= 70)
                    numberOfRolls = 3;
                else if (p.CurrentSkill >= 50)
                    numberOfRolls = 2;
                else numberOfRolls = 1;
            }
            else
            {
                if (p.CurrentSkill >= 55) numberOfRolls = 2;
                else numberOfRolls = 1;
            }
            if (p.Position == Position.W || p.Position == Position.C)
            {
                if (p.CurrentSkill >= 70)
                    neededDiceNumber = 8;
                else if (p.CurrentSkill >= 60)
                    neededDiceNumber = 9;
                else if (p.CurrentSkill >= 50)
                    neededDiceNumber = 10;
                else if (p.CurrentSkill >= 40)
                    neededDiceNumber = 11;
                else if (p.CurrentSkill >= 30)
                    neededDiceNumber = 11;
                else neededDiceNumber = 12;
            }
            else if (p.Position == Position.D)
            {
                if (p.CurrentSkill >= 70)
                    neededDiceNumber = 9;
                else if (p.CurrentSkill >= 60)
                    neededDiceNumber = 10;
                else if (p.CurrentSkill >= 50)
                    neededDiceNumber = 10;
                else if (p.CurrentSkill >= 40)
                    neededDiceNumber = 11;
                else if (p.CurrentSkill >= 30)
                    neededDiceNumber = 11;
                else neededDiceNumber = 12;
            }

            for (int i = 0; i < numberOfRolls; i++)
            {
                playerDiceRoll = DiceRoll();
                if (playerDiceRoll >= neededDiceNumber) p.Goals++;
            }
        }
        private void DetermineAssists(HockeyPlayer p)
        {
            int playerDiceRoll = 0;
            int neededDiceNumber = 0;
            int numberOfRolls = 0;

            if (p.CurrentSkill >= 70)
                numberOfRolls = 3;
            else if (p.CurrentSkill >= 50)
                numberOfRolls = 2;
            else numberOfRolls = 1;

            if (p.CurrentSkill >= 70)
                neededDiceNumber = 6;
            else if (p.CurrentSkill >= 60)
                neededDiceNumber = 7;
            else if (p.CurrentSkill >= 50)
                neededDiceNumber = 8;
            else if (p.CurrentSkill >= 40)
                neededDiceNumber = 9;
            else if (p.CurrentSkill >= 30)
                neededDiceNumber = 10;
            else neededDiceNumber = 12;

            for (int i = 0; i < numberOfRolls; i++)
            {
                playerDiceRoll = DiceRoll();
                if (playerDiceRoll >= neededDiceNumber) p.Assists++;
            }

        }
        private void CalculatePoints(HockeyPlayer p)
        {
            p.Points = p.Goals + p.Assists;
        }
        private void DetermineGoalieWins(int teamWins)
        {
            if (gamesForBackup == 0)
                starterWins = teamWins;
            else
            {
                int diceRoll = DiceRoll();
                if (diceRoll >= 10)
                {
                    backupWins = 1;
                    starterWins = teamWins - 1;
                }
                else starterWins = teamWins;
            }
        }
        private void DetermineShotsFaced(HockeyPlayer p)
        {
            int shotsFaced = 0;
            int numberOfGames = 0;
            if (p.DepthChart == 1)
            {
                //p.Wins += starterWins;
                numberOfGames = gamesForStarter;
                //p.GamesPlayed += gamesForStarter;
            }
            else
            {
                //p.Wins += backupWins;
                numberOfGames = gamesForBackup;
                //p.GamesPlayed += gamesForBackup;
            }

            if (numberOfGames > 0)
            {
                for (int i = 0; i < numberOfGames; i++)
                {
                    shotsFaced = rnd.Next(25, 36);
                    p.ShotsFaced += shotsFaced;
                    DetermineShotsSaved(p, shotsFaced);
                }
            }
            //p.GamesPlayed += numberOfGames;
        }
        private void DetermineShotsSaved(HockeyPlayer p, int shotsFaced)
        {
            int saves = 0;
            int goalsAllowed = 0;

            for (int i = 0; i < shotsFaced; i++)
            {
                int saveRoll = DiceRoll();
                if (p.CurrentSkill >= 65)
                {
                    if (saveRoll > 3) saves++;
                }
                else if (p.CurrentSkill >= 45)
                {
                    if (saveRoll > 4) saves++;
                }
                else
                {
                    if (saveRoll > 5) saves++;
                }
            }
            p.Saves += saves;
            goalsAllowed = shotsFaced - saves;
            p.GoalsAllowed += goalsAllowed;

            if (saves == shotsFaced) p.ShutOuts++;
            CalculateSavePercentage(p);
            CalculateGAA(p);
        }
        private void CalculateSavePercentage(HockeyPlayer p)
        {
            if (p.ShotsFaced > 0)
            {
                p.SavePercentage = Convert.ToDouble(p.Saves) / Convert.ToDouble(p.ShotsFaced);
            }
            else p.SavePercentage = 0.00;
        }
        private void CalculateGAA(HockeyPlayer p)
        {
            if (p.ShotsFaced > 0)
            {
                p.GAA = Convert.ToDouble(p.GoalsAllowed) / Convert.ToDouble(p.GamesPlayed);
            }
            else p.GAA = 99.99;
        }
        #endregion
        #region Simulation
        private void CalculateTeamPoints(Team t)
        {
            t.Points = (t.Wins * 2) + t.OTLosses;
        }
        public string SimulateStanleyCup()
        {
            string results = "";

            EasternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Eastern Conference Champs"));
            WesternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Western Conference Champs"));

            results = SimulateSeries(EasternPlayoffs[0], WesternPlayoffs[0], 0, 1);
            if (losingIndex == 0)
            {
                results = "The " + WesternPlayoffs[0].City + " " + WesternPlayoffs[0].Mascot + " are the " + World.calendar.Year + " Stanley Cup champions!" + Environment.NewLine + results;
                WesternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Stanley Cup Champions"));
            }

            else
            {
                results = "The " + EasternPlayoffs[0].City + " " + EasternPlayoffs[0].Mascot + " are the " + World.calendar.Year + " Stanley Cup champions!" + Environment.NewLine + results;
                EasternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Stanley Cup Champions"));
            }

            return results;
        }
        public string SimulatePlayoffRound()
        {
            string results = "";
            EasternLoserIndex.Clear();
            WesternLoserIndex.Clear();

            for (int i = 0; i < EasternPlayoffs.Count / 2; i++)
            {
                results += SimulateSeries(EasternPlayoffs[i], EasternPlayoffs[EasternPlayoffs.Count - 1 - i], i, EasternPlayoffs.Count - 1 - i) + Environment.NewLine;
                EasternLoserIndex.Add(losingIndex);
                results += SimulateSeries(WesternPlayoffs[i], WesternPlayoffs[WesternPlayoffs.Count - 1 - i], i, WesternPlayoffs.Count - 1 - i) + Environment.NewLine;
                WesternLoserIndex.Add(losingIndex);
            }

            RemoveLosingTeamsFromPlayoffs();

            return results;
        }
        public void RemoveLosingTeamsFromPlayoffs()
        {
            EasternLoserIndex = EasternLoserIndex.OrderByDescending(i => i).ToList();
            WesternLoserIndex = WesternLoserIndex.OrderByDescending(i => i).ToList();

            foreach (int i in EasternLoserIndex) EasternPlayoffs.RemoveAt(i);
            foreach (int i in WesternLoserIndex) WesternPlayoffs.RemoveAt(i);
        }

        public string SimulateSeries(Team team1, Team team2, int teamIndex1, int teamIndex2)
        {
            string seriesResult = "";
            int winsTeam1 = 0;
            int winsTeam2 = 0;

            while (winsTeam1 < 4 && winsTeam2 < 4)
            {
                int result;
                result = SimulatePlayoffGame(team1, team2);
                if (result == 1) winsTeam1++;
                else winsTeam2++;
            }

            if (winsTeam1 == 4)
            {
                seriesResult = team1.Abbreviation + " defeats " + team2.Abbreviation + " in " + (winsTeam1 + winsTeam2) + " games.";
                losingIndex = teamIndex2;
            }
            else
            {
                seriesResult = team2.Abbreviation + " defeats " + team1.Abbreviation + " in " + (winsTeam1 + winsTeam2) + " games.";
                losingIndex = teamIndex1;
            }


            return seriesResult;
        }
        public int SimulatePlayoffGame(Team team1, Team team2)
        {
            int totalNumber = team1.TitleConteder + team2.TitleConteder + 1;
            int winningNumber = rnd.Next(1, totalNumber);
            if (winningNumber <= team1.TitleConteder)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        private void SimulateGames()
        {
            gamesThisWeek = HowManyGamesThisWeek();
            foreach (Team t in NHL.TeamList) t.WinsThisWeek = 0;
            for (int i = 0; i < gamesThisWeek; i++)
            {
                var indexList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

                for (int j = 0; j < NHL.TeamList.Count / 2; j++)
                {
                    int opponentIndex = rnd.Next(1, indexList.Count);
                    SimulateGame(NHL.TeamList[indexList[0]], NHL.TeamList[indexList[opponentIndex]]);
                    indexList.RemoveAt(opponentIndex);
                    indexList.RemoveAt(0);
                }
                index++;
                if (index == 30) index = 1;
                int rndWinNumber = rnd.Next(1, 101);
                if (rndWinNumber <= NHL.TeamList[indexList[0]].TitleConteder)
                {
                    NHL.TeamList[indexList[0]].Wins++;
                    NHL.TeamList[indexList[0]].WinsThisWeek++;
                }
                else NHL.TeamList[indexList[0]].Losses++;
            }
        }
        private int HowManyGamesThisWeek()
        {
            int games = 0;

            if (NHL.WeekNumber <= 20) games = 3;
            else games = 2;

            return games;
        }
        private void SimulateGame(Team team1, Team team2)
        {
            bool overtime = false;
            int otRandom = rnd.Next(1, 101);
            if (otRandom <= 10)
            {
                overtime = true;
            }
            int totalNumber = team1.TitleConteder + team2.TitleConteder + 1;
            int winningNumber = rnd.Next(1, totalNumber);
            if (winningNumber <= team1.TitleConteder)
            {
                team1.Wins++;
                team1.WinsThisWeek++;
                if (overtime)
                    team2.OTLosses++;
                else team2.Losses++;
            }
            else
            {
                if (overtime)
                    team1.OTLosses++;
                else team1.Losses++;
                team2.WinsThisWeek++;
                team2.Wins++;
            }
            team1.PlayedGameThisCycle = true;
            team2.PlayedGameThisCycle = true;
        }
        private string DeterminePlayoffField()
        {
            string playoffSeedings = "";
            EasternConference.Clear();
            WesternConference.Clear();
            EasternPlayoffs.Clear();
            WesternPlayoffs.Clear();

            foreach (Team t in World.NHL.TeamList)
            {
                if (t.Conference == "Eastern") EasternConference.Add(t);
                else WesternConference.Add(t);
            }

            EasternConference = EasternConference.OrderByDescending(o => o.Points).ThenByDescending(o => o.Wins).ToList();
            WesternConference = WesternConference.OrderByDescending(o => o.Points).ThenByDescending(o => o.Wins).ToList();

            int atlanticIndex = EasternConference.FindIndex(t => t.Division == "Atlantic");
            EasternPlayoffs.Add(EasternConference[atlanticIndex]);
            EasternConference[atlanticIndex].Awards.Add(new Award(World.calendar.Year, EasternConference[atlanticIndex].Division + " Division Champs"));
            EasternConference.RemoveAt(atlanticIndex);

            int metropolitanIndex = EasternConference.FindIndex(t => t.Division == "Metropolitan");
            EasternPlayoffs.Add(EasternConference[metropolitanIndex]);
            EasternConference[metropolitanIndex].Awards.Add(new Award(World.calendar.Year, EasternConference[metropolitanIndex].Division + " Division Champs"));
            EasternConference.RemoveAt(metropolitanIndex);

            EasternPlayoffs = EasternPlayoffs.OrderByDescending(o => o.Points).ToList();
            for (int i = 0; i < 6; i++)
                EasternPlayoffs.Add(EasternConference[i]);

            int centralIndex = WesternConference.FindIndex(t => t.Division == "Central");
            WesternPlayoffs.Add(WesternConference[centralIndex]);
            WesternConference[centralIndex].Awards.Add(new Award(World.calendar.Year, WesternConference[centralIndex].Division + " Division Champs"));
            WesternConference.RemoveAt(centralIndex);

            int pacificIndex = WesternConference.FindIndex(t => t.Division == "Pacific");
            WesternPlayoffs.Add(WesternConference[pacificIndex]);
            WesternConference[pacificIndex].Awards.Add(new Award(World.calendar.Year, WesternConference[pacificIndex].Division + " Division Champs"));
            WesternConference.RemoveAt(pacificIndex);

            WesternPlayoffs = WesternPlayoffs.OrderByDescending(o => o.Points).ToList();
            for (int i = 0; i < 6; i++)
                WesternPlayoffs.Add(WesternConference[i]);

            for (int i = 0; i < 4; i++)
            {
                playoffSeedings += i + 1 + ") " + EasternPlayoffs[i].Abbreviation + " vs. " + (EasternPlayoffs.Count - i) + ") " + EasternPlayoffs[EasternPlayoffs.Count - 1 - i].Abbreviation + Environment.NewLine;
                playoffSeedings += i + 1 + ") " + WesternPlayoffs[i].Abbreviation + " vs. " + (WesternPlayoffs.Count - i) + ") " + WesternPlayoffs[WesternPlayoffs.Count - 1 - i].Abbreviation + Environment.NewLine;
            }

            return playoffSeedings;
        }
        #endregion
        #region Awards
        private void CalculatePlayerOfTheYearScore(HockeyPlayer p)
        {
            double score = 0;
            score = p.CurrentSkill * 2 + p.Team.Wins * 3 + p.Popularity * 2 + p.Goals * 3 + p.Assists;
            p.PlayerOfYearScore = score;
        }
        private void CalculateGoalieOfTheYearScore(HockeyPlayer p)
        {
            double score = 0;
            score = (p.CurrentSkill * 2) + (p.Team.Wins * 7) + (p.Popularity) + (3 - (p.GAA * 100)) + (p.ShutOuts * 5);
            if (p.GamesPlayed >= 25)
                p.PlayerOfYearScore = score;
            else p.PlayerOfYearScore = score / 4;
        }
        private string DisplayForwardOfTheYearTop5()
        {
            string results = "";

            List<HockeyPlayer> forwardRanks = new List<HockeyPlayer>();
            foreach (Team t in World.NHL.TeamList)
                foreach (HockeyPlayer p in t.Roster)
                    if (p.Position == Position.W || p.Position == Position.C)
                        forwardRanks.Add(p);

            forwardRanks = forwardRanks.OrderByDescending(o => o.PlayerOfYearScore).ToList();

            results = forwardRanks[0].Team.City + "'s " + forwardRanks[0].FullName + " has been named NHL Forward of the Year! " + forwardRanks[0].PlayerOfYearScore + Environment.NewLine +
                "Here are the rest of the top-5:";
            for (int i = 2; i < 6; i++)
            {
                results += Environment.NewLine + i + ") [" + forwardRanks[i - 1].Team.Abbreviation + "] " + forwardRanks[i - 1].FullName + " " + forwardRanks[i - 1].PlayerOfYearScore;
            }

            //give the winner the award
            forwardRanks[0].Awards.Add(new Award(World.calendar.Year, "Forward of the Year"));

            return results;
        }
        private string DisplayDefensemanOfTheYearTop5()
        {
            string results = "";

            List<HockeyPlayer> defensemanRanks = new List<HockeyPlayer>();
            foreach (Team t in World.NHL.TeamList)
                foreach (HockeyPlayer p in t.Roster)
                    if (p.Position == Position.D)
                        defensemanRanks.Add(p);

            defensemanRanks = defensemanRanks.OrderByDescending(o => o.PlayerOfYearScore).ToList();

            results = defensemanRanks[0].Team.City + "'s " + defensemanRanks[0].FullName + " has been named NHL Defenseman of the Year!" + Environment.NewLine +
                "Here are the rest of the top-5:";
            for (int i = 2; i < 6; i++)
            {
                results += Environment.NewLine + i + ") [" + defensemanRanks[i - 1].Team.Abbreviation + "] " + defensemanRanks[i - 1].FullName;
            }

            //give the winner the award
            defensemanRanks[0].Awards.Add(new Award(World.calendar.Year, "Defenseman of the Year"));

            return results;
        }
        private string DisplayGoalieOfTheYearTop5()
        {
            string results = "";

            List<HockeyPlayer> goalieRanks = new List<HockeyPlayer>();
            foreach (Team t in World.NHL.TeamList)
                foreach (HockeyPlayer p in t.Roster)
                    if (p.Position == Position.G)
                        goalieRanks.Add(p);

            goalieRanks = goalieRanks.OrderByDescending(o => o.PlayerOfYearScore).ToList();

            results = goalieRanks[0].Team.City + "'s " + goalieRanks[0].FullName + " has been named NHL Goalie of the Year!" + Environment.NewLine +
                "Here are the rest of the top-5:";
            for (int i = 2; i < 6; i++)
            {
                results += Environment.NewLine + i + ") [" + goalieRanks[i - 1].Team.Abbreviation + "] " + goalieRanks[i - 1].FullName;
            }

            //give the winner the award
            goalieRanks[0].Awards.Add(new Award(World.calendar.Year, "Goalie of the Year"));

            return results;
        }
        #endregion
        public int DiceRoll()
        {
            int firstDie = rnd.Next(1, 7);
            int secondDie = rnd.Next(1, 7);
            return firstDie + secondDie;
        }
    }
}
