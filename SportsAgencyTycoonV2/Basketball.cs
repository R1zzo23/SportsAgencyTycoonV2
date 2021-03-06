﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Basketball
    {
        public MainForm mainForm;
        public BasketballDraft basketballDraft;
        public Random rnd;
        public League NBA;
        public World World;
        public int index;
        public int losingIndex;
        public List<string> Conferences;
        public List<string> Divisions;
        public List<Team> EasternConference = new List<Team>();
        public List<Team> WesternConference = new List<Team>();
        public List<Team> EasternPlayoffs = new List<Team>();
        public List<Team> WesternPlayoffs = new List<Team>();
        public List<int> EasternLoserIndex = new List<int>();
        public List<int> WesternLoserIndex = new List<int>();
        public List<BasketballPlayer> DPOYCandidates = new List<BasketballPlayer>();

        public Basketball(MainForm mf, Random r, World w, League l)
        {
            mainForm = mf;
            rnd = r;
            World = w;
            NBA = l;
            index = 1;
            basketballDraft = new BasketballDraft(rnd, World, NBA);
            Conferences = new List<string>();
            Divisions = new List<string>();
            FillLists();
        }

        public void FillLists()
        {
            Conferences.Add("Eastern");
            Conferences.Add("Western");
            Divisions.Add("Atlantic");
            Divisions.Add("Central");
            Divisions.Add("Southeast");
            Divisions.Add("Northwest");
            Divisions.Add("Southwest");
            Divisions.Add("Pacific");
        }

        public void SimWeek()
        {
            if (World.calendar.Month == 10 && World.calendar.Week == 4)
                World.Basketball.InitializeStats();

            if (World.calendar.Month == 1 && World.calendar.Week == 3)
            {
                //mainForm.newsLabel.Text += Environment.NewLine + "NBA draft entrants finalized!" + Environment.NewLine + mainForm.newsLabel.Text;
                World.Basketball.basketballDraft.CreateDraftEntrants();
            }


            if (!World.NBA.Playoffs)
            {
                World.Basketball.SimulateGames();
                World.Basketball.UpdateStats();

                //if it is the 1st week of May, games above will simulate and the playoffs will now be starting
                if (World.calendar.Month == 5 && World.calendar.Week == 1)
                {
                    World.NBA.Playoffs = true;
                    World.Basketball.DPOYCandidates.Clear();
                    foreach (Team t in World.NBA.TeamList)
                        foreach (BasketballPlayer p in t.Roster)
                        {
                            World.Basketball.MVPScores(p);
                            if (p.Strength == Skill.Blocking || p.Strength == Skill.Stealing
                                || p.Strength == Skill.Rebounding)
                            {
                                World.Basketball.BasketballDPOYScores(p);
                                World.Basketball.DPOYCandidates.Add(p);
                            }

                        }

                    //mainForm.newsLabel.Text = World.Basketball.DisplayDPOYTop5() + Environment.NewLine + mainForm.newsLabel.Text;
                    //mainForm.newsLabel.Text = World.Basketball.DisplayMVPTop5() + Environment.NewLine + mainForm.newsLabel.Text;

                    DisplayDPOYTop5();
                    DisplayMVPTop5();

                    //mainForm.newsLabel.Text = World.Basketball.DeterminePlayoffField() + Environment.NewLine + mainForm.newsLabel.Text;
                    DeterminePlayoffField();
                }

            }
            else if (World.NBA.Playoffs && (World.calendar.Month == 6 && World.calendar.Week == 1))
                //mainForm.newsLabel.Text = World.Basketball.SimulateChampionship() + Environment.NewLine + mainForm.newsLabel.Text;
                World.Basketball.SimulateChampionship();
            else
                //mainForm.newsLabel.Text = World.Basketball.SimulatePlayoffRound() + Environment.NewLine + mainForm.newsLabel.Text;
                World.Basketball.SimulatePlayoffRound();
        }

        public void SimulateGames()
        {
            int gamesThisWeek = HowManyGamesThisWeek();
            for (int i = 0; i < gamesThisWeek; i++)
            {
                //int[] indexArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };
                var indexList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };

                for (int j = 0; j < NBA.TeamList.Count / 2; j++)
                {
                    int opponentIndex = rnd.Next(1, indexList.Count);
                    SimulateGame(NBA.TeamList[indexList[0]], NBA.TeamList[indexList[opponentIndex]]);
                    indexList.RemoveAt(opponentIndex);
                    indexList.RemoveAt(0);
                }
                index++;
                if (index == 30) index = 1;
            }
        }

        public string SimulateChampionship()
        {
            string results = "";

            EasternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Eastern Conference Champs"));
            WesternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "Western Conference Champs"));

            results = SimulateSeries(EasternPlayoffs[0], WesternPlayoffs[0], 0, 1);
            if (losingIndex == 0)
            {
                results = "The " + WesternPlayoffs[0].City + " " + WesternPlayoffs[0].Mascot + " are the " + World.calendar.Year + " NBA champions!" + Environment.NewLine + results;
                WesternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "NBA Champions"));
            }

            else
            {
                results = "The " + EasternPlayoffs[0].City + " " + EasternPlayoffs[0].Mascot + " are the " + World.calendar.Year + " NBA champions!" + Environment.NewLine + results;
                EasternPlayoffs[0].Awards.Add(new Award(World.calendar.Year, "NBA Champions"));
            }

            return results;
        }

        public string DeterminePlayoffField()
        {
            string playoffSeedings = "";
            EasternConference.Clear();
            WesternConference.Clear();
            EasternPlayoffs.Clear();
            WesternPlayoffs.Clear();

            foreach (Team t in World.NBA.TeamList)
            {
                if (t.Conference == "Eastern") EasternConference.Add(t);
                else WesternConference.Add(t);
            }

            EasternConference = EasternConference.OrderByDescending(o => o.Wins).ThenByDescending(o => o.TitleConteder).ToList();
            WesternConference = WesternConference.OrderByDescending(o => o.Wins).ThenByDescending(o => o.TitleConteder).ToList();

            int atlanticIndex = EasternConference.FindIndex(t => t.Division == "Atlantic");
            EasternPlayoffs.Add(EasternConference[atlanticIndex]);
            EasternConference[atlanticIndex].Awards.Add(new Award(World.calendar.Year, EasternConference[atlanticIndex].Division + " Division Champs"));
            EasternConference.RemoveAt(atlanticIndex);

            int centralIndex = EasternConference.FindIndex(t => t.Division == "Central");
            EasternPlayoffs.Add(EasternConference[centralIndex]);
            EasternConference[centralIndex].Awards.Add(new Award(World.calendar.Year, EasternConference[centralIndex].Division + " Division Champs"));
            EasternConference.RemoveAt(centralIndex);

            int southeastIndex = EasternConference.FindIndex(t => t.Division == "Southeast");
            EasternPlayoffs.Add(EasternConference[southeastIndex]);
            EasternConference[southeastIndex].Awards.Add(new Award(World.calendar.Year, EasternConference[southeastIndex].Division + " Division Champs"));
            EasternConference.RemoveAt(southeastIndex);

            EasternPlayoffs.Add(EasternConference[0]);
            EasternConference.RemoveAt(0);

            EasternPlayoffs = EasternPlayoffs.OrderByDescending(o => o.Wins).ToList();
            for (int i = 0; i < 4; i++)
                EasternPlayoffs.Add(EasternConference[i]);

            int northwestIndex = WesternConference.FindIndex(t => t.Division == "Northwest");
            WesternPlayoffs.Add(WesternConference[northwestIndex]);
            WesternConference[northwestIndex].Awards.Add(new Award(World.calendar.Year, WesternConference[northwestIndex].Division + " Division Champs"));
            WesternConference.RemoveAt(northwestIndex);

            int southwestIndex = WesternConference.FindIndex(t => t.Division == "Southwest");
            WesternPlayoffs.Add(WesternConference[southwestIndex]);
            WesternConference[southwestIndex].Awards.Add(new Award(World.calendar.Year, WesternConference[southwestIndex].Division + " Division Champs"));
            WesternConference.RemoveAt(southwestIndex);

            int pacificIndex = WesternConference.FindIndex(t => t.Division == "Pacific");
            WesternPlayoffs.Add(WesternConference[pacificIndex]);
            WesternConference[pacificIndex].Awards.Add(new Award(World.calendar.Year, WesternConference[pacificIndex].Division + " Division Champs"));
            WesternConference.RemoveAt(pacificIndex);

            WesternPlayoffs.Add(WesternConference[0]);
            WesternConference.RemoveAt(0);

            WesternPlayoffs = WesternPlayoffs.OrderByDescending(o => o.Wins).ToList();
            for (int i = 0; i < 4; i++)
                WesternPlayoffs.Add(WesternConference[i]);

            for (int i = 0; i < 4; i++)
            {
                playoffSeedings += i + 1 + ") " + EasternPlayoffs[i].Abbreviation + " vs. " + (EasternPlayoffs.Count - i) + ") " + EasternPlayoffs[EasternPlayoffs.Count - 1 - i].Abbreviation + Environment.NewLine;
                playoffSeedings += i + 1 + ") " + WesternPlayoffs[i].Abbreviation + " vs. " + (WesternPlayoffs.Count - i) + ") " + WesternPlayoffs[WesternPlayoffs.Count - 1 - i].Abbreviation + Environment.NewLine;
            }

            return playoffSeedings;
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

        public int HowManyGamesThisWeek()
        {
            int gamesThisWeek = 3;

            //only two games per week for first two weeks
            if ((World.calendar.Month == 10 && World.calendar.Week == 4) ||
                (World.calendar.Month == 11 && World.calendar.Week == 1))
            {
                gamesThisWeek = 2;
            }

            return gamesThisWeek;
        }

        private void SimulateGame(Team team1, Team team2)
        {
            int totalNumber = team1.TitleConteder + team2.TitleConteder + 1;
            int winningNumber = rnd.Next(1, totalNumber);
            if (winningNumber <= team1.TitleConteder)
            {
                team1.Wins++;
                team2.Losses++;
            }
            else
            {
                team1.Losses++;
                team2.Wins++;
            }
            team1.PlayedGameThisCycle = true;
            team2.PlayedGameThisCycle = true;
        }
        #region Stat Creation and Updating
        public void InitializeStats()
        {
            foreach (Team t in NBA.TeamList)
                foreach (BasketballPlayer p in t.Roster)
                {
                    InitializePoints(p);
                    InitializeRebounds(p);
                    InitializeAssists(p);
                    InitializeSteals(p);
                    InitializeBlocks(p);
                }
        }
        private void InitializePoints(BasketballPlayer p)
        {
            bool strength = false;
            if (p.Strength == Skill.Scoring) strength = true;
            if (p.CurrentSkill >= 70) p.Points = Convert.ToDouble(rnd.Next(1800, 3150)) / 100;
            else if (p.CurrentSkill >= 50) p.Points = Convert.ToDouble(rnd.Next(1000, 1800)) / 100;
            else if (p.CurrentSkill >= 40) p.Points = Convert.ToDouble(rnd.Next(500, 1000)) / 100;
            else if (p.CurrentSkill >= 30) p.Points = Convert.ToDouble(rnd.Next(250, 500)) / 100;
            else if (p.CurrentSkill >= 20) p.Points = Convert.ToDouble(rnd.Next(50, 250)) / 100;
            else p.Points = Convert.ToDouble(rnd.Next(0, 199)) / 10;
            if (strength) p.Points *= (1 + ((35 - p.Points) / 100));
        }
        private void InitializeRebounds(BasketballPlayer p)
        {
            bool strength = false;
            if (p.Strength == Skill.Rebounding) strength = true;
            if (p.Position == Position.PG) p.Rebounds = Convert.ToDouble(rnd.Next(50, 400)) / 100;
            else if (p.Position == Position.SG) p.Rebounds = Convert.ToDouble(rnd.Next(150, 500)) / 100;
            else if (p.Position == Position.SF) p.Rebounds = Convert.ToDouble(rnd.Next(250, 650)) / 100;
            else if (p.Position == Position.PF) p.Rebounds = Convert.ToDouble(rnd.Next(450, 1100)) / 100;
            else if (p.Position == Position.CE) p.Rebounds = Convert.ToDouble(rnd.Next(625, 1500)) / 100;

            if (p.CurrentSkill <= 20) p.Rebounds *= Convert.ToDouble(rnd.Next(25, 50)) / 100;
            else if (p.CurrentSkill <= 30) p.Rebounds *= Convert.ToDouble(rnd.Next(40, 60)) / 100;
            else if (p.CurrentSkill <= 40) p.Rebounds *= Convert.ToDouble(rnd.Next(50, 75)) / 100;
            else if (p.CurrentSkill <= 50) p.Rebounds *= Convert.ToDouble(rnd.Next(75, 95)) / 100;

            if (strength) p.Rebounds *= (1 + ((30 - p.Rebounds) / 100));
        }
        private void InitializeAssists(BasketballPlayer p)
        {
            bool strength = false;
            if (p.Strength == Skill.Passing) strength = true;
            if (p.Position == Position.PG) p.Assists = Convert.ToDouble(rnd.Next(500, 1200)) / 100;
            else if (p.Position == Position.SG) p.Assists = Convert.ToDouble(rnd.Next(150, 650)) / 100;
            else if (p.Position == Position.SF) p.Assists = Convert.ToDouble(rnd.Next(100, 650)) / 100;
            else if (p.Position == Position.PF) p.Assists = Convert.ToDouble(rnd.Next(50, 375)) / 100;
            else if (p.Position == Position.CE) p.Assists = Convert.ToDouble(rnd.Next(25, 300)) / 100;

            if (p.CurrentSkill <= 20) p.Assists *= Convert.ToDouble(rnd.Next(25, 50)) / 100;
            else if (p.CurrentSkill <= 30) p.Assists *= Convert.ToDouble(rnd.Next(40, 60)) / 100;
            else if (p.CurrentSkill <= 40) p.Assists *= Convert.ToDouble(rnd.Next(50, 75)) / 100;
            else if (p.CurrentSkill <= 50) p.Assists *= Convert.ToDouble(rnd.Next(75, 95)) / 100;

            if (strength) p.Assists *= (1 + ((30 - p.Assists) / 100));
        }
        private void InitializeSteals(BasketballPlayer p)
        {
            bool strength = false;
            if (p.Strength == Skill.Stealing) strength = true;
            if (p.Position == Position.PG) p.Steals = Convert.ToDouble(rnd.Next(50, 350)) / 100;
            else if (p.Position == Position.SG) p.Steals = Convert.ToDouble(rnd.Next(50, 350)) / 100;
            else if (p.Position == Position.SF) p.Steals = Convert.ToDouble(rnd.Next(50, 350)) / 100;
            else if (p.Position == Position.PF) p.Steals = Convert.ToDouble(rnd.Next(25, 200)) / 100;
            else if (p.Position == Position.CE) p.Steals = Convert.ToDouble(rnd.Next(10, 200)) / 100;

            if (p.CurrentSkill <= 20) p.Steals *= Convert.ToDouble(rnd.Next(25, 50)) / 100;
            else if (p.CurrentSkill <= 30) p.Steals *= Convert.ToDouble(rnd.Next(40, 60)) / 100;
            else if (p.CurrentSkill <= 40) p.Steals *= Convert.ToDouble(rnd.Next(50, 75)) / 100;
            else if (p.CurrentSkill <= 50) p.Steals *= Convert.ToDouble(rnd.Next(75, 95)) / 100;

            if (strength) p.Steals *= (1 + ((30 - p.Steals) / 100));
        }
        private void InitializeBlocks(BasketballPlayer p)
        {
            bool strength = false;
            if (p.Strength == Skill.Blocking) strength = true;
            if (p.Position == Position.PG) p.Blocks = Convert.ToDouble(rnd.Next(10, 100)) / 100;
            else if (p.Position == Position.SG) p.Blocks = Convert.ToDouble(rnd.Next(10, 120)) / 100;
            else if (p.Position == Position.SF) p.Blocks = Convert.ToDouble(rnd.Next(10, 130)) / 100;
            else if (p.Position == Position.PF) p.Blocks = Convert.ToDouble(rnd.Next(50, 250)) / 100;
            else if (p.Position == Position.CE) p.Blocks = Convert.ToDouble(rnd.Next(75, 300)) / 100;

            if (p.CurrentSkill <= 20) p.Blocks *= Convert.ToDouble(rnd.Next(25, 50)) / 100;
            else if (p.CurrentSkill <= 30) p.Blocks *= Convert.ToDouble(rnd.Next(40, 60)) / 100;
            else if (p.CurrentSkill <= 40) p.Blocks *= Convert.ToDouble(rnd.Next(50, 75)) / 100;
            else if (p.CurrentSkill <= 50) p.Blocks *= Convert.ToDouble(rnd.Next(75, 95)) / 100;

            if (strength) p.Blocks *= (1 + ((30 - p.Blocks) / 100));
        }
        public void UpdateStats()
        {
            foreach (Team t in NBA.TeamList)
                foreach (BasketballPlayer p in t.Roster)
                {
                    UpdatePoints(p);
                    UpdateRebounds(p);
                    UpdateAssists(p);
                    UpdateSteals(p);
                    UpdateBlocks(p);
                }
        }
        public void UpdatePoints(BasketballPlayer p)
        {
            double change = Convert.ToDouble(rnd.Next(-5, 6)) / 100;
            if (change <= -.03)
                p.Points *= 1 + (change + .02);
            else if (change >= .03)
                p.Points *= 1 + (change - .02);
        }
        public void UpdateRebounds(BasketballPlayer p)
        {
            double change = Convert.ToDouble(rnd.Next(-5, 6)) / 100;
            if (change <= -.03)
                p.Rebounds *= 1 + (change + .02);
            else if (change >= .03)
                p.Rebounds *= 1 + (change - .02);
        }
        public void UpdateAssists(BasketballPlayer p)
        {
            double change = Convert.ToDouble(rnd.Next(-5, 6)) / 100;
            if (change <= -.03)
                p.Assists *= 1 + (change + .02);
            else if (change >= .03)
                p.Assists *= 1 + (change - .02);
        }
        public void UpdateSteals(BasketballPlayer p)
        {
            double change = Convert.ToDouble(rnd.Next(-5, 6)) / 100;
            if (change <= -.03)
                p.Steals *= 1 + (change + .02);
            else if (change >= .03)
                p.Steals *= 1 + (change - .02);
        }
        public void UpdateBlocks(BasketballPlayer p)
        {
            double change = Convert.ToDouble(rnd.Next(-5, 6)) / 100;
            if (change <= -.03)
                p.Blocks *= 1 + (change + .02);
            else if (change >= .03)
                p.Blocks *= 1 + (change - .02);
        }
        #endregion
        public void MVPScores(BasketballPlayer p)
        {
            double score = 0;
            score = p.CurrentSkill * 2 + p.Team.Wins * 5 + p.Popularity * 2 + p.Points * 2 + p.Rebounds + p.Assists + p.Steals + p.Blocks;
            p.MVPScore = score;
        }
        public void BasketballDPOYScores(BasketballPlayer p)
        {
            double score = 0;
            score = p.CurrentSkill / 2 + p.Team.Wins / 2 + p.Rebounds + p.Steals * 2 + p.Blocks * 2.5;
            p.DPOYScore = score;
        }
        public string DisplayMVPTop5()
        {
            string results = "";

            List<BasketballPlayer> mvpRanks = new List<BasketballPlayer>();
            foreach (Team t in World.NBA.TeamList)
                foreach (BasketballPlayer p in t.Roster)
                    mvpRanks.Add(p);

            mvpRanks = mvpRanks.OrderByDescending(o => o.MVPScore).ToList();

            results = mvpRanks[0].Team.City + "'s " + mvpRanks[0].FullName + " has been named NBA MVP!" + Environment.NewLine +
                "Here are the rest of the top-5:";
            for (int i = 2; i < 6; i++)
            {
                results += Environment.NewLine + i + ") [" + mvpRanks[i - 1].Team.Abbreviation + "] " + mvpRanks[i - 1].FullName;
            }

            //give the winner the award
            mvpRanks[0].Awards.Add(new Award(World.calendar.Year, "NBA MVP"));

            return results;
        }
        public string DisplayDPOYTop5()
        {
            string results = "";

            DPOYCandidates = DPOYCandidates.OrderByDescending(o => o.DPOYScore).ToList();

            results = DPOYCandidates[0].Team.City + "'s " + DPOYCandidates[0].FullName + " has been named NBA Defensive Player of the Year!" + Environment.NewLine +
                "Here are the rest of the top-5:";
            for (int i = 2; i < 6; i++)
            {
                results += Environment.NewLine + i + ") [" + DPOYCandidates[i - 1].Team.Abbreviation + "] " + DPOYCandidates[i - 1].FullName;
            }

            //give the winner the award
            DPOYCandidates[0].Awards.Add(new Award(World.calendar.Year, "NBA Defensive Player of the Year"));

            return results;
        }
    }
}
