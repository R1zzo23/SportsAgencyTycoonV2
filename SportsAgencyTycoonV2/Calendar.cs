using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public class Calendar
    {
        MainForm mainForm;
        World world;
        public int Year;
        public int Month;
        public int Week;
        public int Day;
        Timer calendarTimer;

        public Calendar(MainForm mf, World W, int y, int m, int w)
        {
            mainForm = mf;
            world = W;
            Year = y;
            Month = m;
            Week = w;
            Day = 0;
            calendarTimer = mf.calendarTimer;
            UpdateCalendarUI();

            calendarTimer.Interval = 1000;
            calendarTimer.Start();
            InitializeMyTimer();

        }
        // Call this method from the constructor of the form.
        private void InitializeMyTimer()
        {
            // Set length for a single day
            calendarTimer.Interval = 1000;
            // Connect the Tick event of the timer to its event handler.
            calendarTimer.Tick += new EventHandler(IncreaseDays);
            // Start the timer.
            calendarTimer.Start();
        }
        private void IncreaseDays(object sender, EventArgs e)
        {
            Day++;
            if (world.MyAgency.AttemptingJob)
            {
                world.MyAgency.DaysAttemptingJob++;
                world.MyAgency.AddDaysWorking();
            }

            if (Day <= 6)
            {
                mainForm.dayMarkers[Day].Visible = true;
            }
            else
            {
                for (int i = 1; i < Day; i++)
                    mainForm.dayMarkers[i].Visible = false;
                Day = 0;

                AdvanceWeek();
            }
            ReduceAgentWorkTimes();
        }
        public void ReduceAgentWorkTimes()
        {
            if (world.MyAgency.Manager.WorkTime > 0)
            {
                world.MyAgency.Manager.WorkTime--;
                if (world.MyAgency.Manager.WorkTime == 0)
                {
                    if (world.MyAgency.Manager.Status == AgentStatus.Scouting)
                        mainForm.clientPanelFunctions.AddScoutedPlayerToScoutedPlayersList(world.MyAgency.Manager.PlayerBeingScouted);
                    world.MyAgency.Manager.Status = AgentStatus.Available;
                    world.MyAgency.Manager.UpdateManagerUI(mainForm);
                }
            }
                
            foreach (Agent a in world.MyAgency.AgentList)
                if (a.WorkTime > 0)
                {
                    a.WorkTime--;
                    if (a.WorkTime == 0)
                    {
                        if (a.Status == AgentStatus.Scouting)
                            mainForm.clientPanelFunctions.AddScoutedPlayerToScoutedPlayersList(a.PlayerBeingScouted);

                        a.Status = AgentStatus.Available;
                        world.MyAgency.DisplayAllAgents();
                    }
                }
        }
        public void AdvanceWeek()
        {
            RunEventsThisWeek();

            //simulate games if league in initialized and in-season
            if (world.NBA.Initialized && world.NBA.InSeason)
            {
                world.Basketball.SimWeek();
            }

            if (world.NFL.Initialized && world.NFL.InSeason)
            {
                world.Football.SimWeek();
            }

            if (world.MLB.Initialized && world.MLB.InSeason)
            {
                world.Baseball.SimWeek();
            }

            if (world.NHL.Initialized && world.NHL.InSeason)
            {
                world.Hockey.SimWeek();
            }
            if (world.MLS.Initialized && world.MLS.InSeason)
            {
                world.Soccer.SimWeek();
            }

            HandleCalendar();
            UpdateCalendarUI();

            world.CheckForEventsThisWeek();
            //if (world.EventsThisWeek.Count > 0) DisplayEventsThisWeek();
        }
        private void RunEventsThisWeek()
        {
            if (Month == 7 && Week == 1 && world.NBA.Initialized)
                //newsLabel.Text += world.Basketball.basketballDraft.RunDraft() + Environment.NewLine + newsLabel.Text;
                world.Basketball.basketballDraft.RunDraft();
            if (Month == 4 && Week == 3 && world.NFL.Initialized)
                //newsLabel.Text += world.Football.footballDraft.RunDraft() + Environment.NewLine + newsLabel.Text;
                world.Football.footballDraft.RunDraft();
            if (Month == 1 && Week == 2 && world.MLB.Initialized)
                //newsLabel.Text += world.Baseball.baseballDraft.RunDraft() + Environment.NewLine + newsLabel.Text;
                world.Baseball.baseballDraft.RunDraft();
            if (Month == 6 && Week == 4 && world.NHL.Initialized)
                //newsLabel.Text += world.Hockey.hockeyDraft.RunDraft() + Environment.NewLine + newsLabel.Text;
                world.Hockey.hockeyDraft.RunDraft();
            if (Month == 1 && Week == 2 && world.MLS.Initialized)
                //newsLabel.Text += world.Soccer.soccerDraft.RunDraft() + Environment.NewLine + newsLabel.Text;
                world.Soccer.soccerDraft.RunDraft();

            foreach (CalendarEvent e in world.EventsThisWeek)
            {
                if (e.EventType == CalendarEventType.AssociationEvent)
                {
                    /*if (e.Sport == Sports.Tennis)
                    {
                        int eventIndex = world.ATP.EventList.FindIndex(x => x.Id.Equals(e.EventID));
                        Event thisEvent = world.ATP.EventList.Find(x => x.Id == e.EventID);
                        newsLabel.Text = Tennis.RunTournament(world.ATP.EventList[eventIndex], world) + newsLabel.Text;
                    }
                    else if (e.Sport == Sports.Golf)
                    {
                        Event thisEvent = world.PGA.EventList.Find(x => x.Id == e.EventID && x.Year == world.Year);
                        newsLabel.Text = Golf.RunTournament(thisEvent, world) + newsLabel.Text;
                    }
                    else if (e.Sport == Sports.MMA)
                    {
                        Event thisEvent = world.UFC.EventList.Find(x => x.Id == e.EventID);
                        newsLabel.Text = MMA.RunMMAEvent(thisEvent, world) + newsLabel.Text;
                    }
                    else if (e.Sport == Sports.Boxing)
                    {
                        Event thisEvent = world.WBA.EventList.Find(x => x.Id == e.EventID);
                        newsLabel.Text = Boxing.RunBoxingEvent(thisEvent, world) + newsLabel.Text;
                    }*/
                }
                else if (e.EventType == CalendarEventType.PlayerBirthday)
                {
                    if (e.Sport == Sports.Tennis)
                    {
                        //world.ATP.PlayerList.Find(x => x.Id == e.PlayerID).Age++;
                    }
                    else if (e.Sport == Sports.Golf)
                    {
                        //world.PGA.PlayerList.Find(x => x.Id == e.PlayerID).Age++;
                    }
                    else if (e.Sport == Sports.MMA)
                    {
                        //world.UFC.PlayerList.Find(x => x.Id == e.PlayerID).Age++;
                    }
                    else if (e.Sport == Sports.Boxing)
                    {
                        //world.WBA.PlayerList.Find(x => x.Id == e.PlayerID).Age++;
                    }
                    else if (e.Sport == Sports.Baseball)
                    {
                        for (int i = 0; i < world.MLB.TeamList.Count; i++)
                            for (int j = 0; j < world.MLB.TeamList[i].Roster.Count; j++)
                                if (world.MLB.TeamList[i].Roster[j].Id == e.PlayerID) world.MLB.TeamList[i].Roster[j].Age++;
                    }
                    else if (e.Sport == Sports.Basketball)
                    {
                        for (int i = 0; i < world.NBA.TeamList.Count; i++)
                            for (int j = 0; j < world.NBA.TeamList[i].Roster.Count; j++)
                                if (world.NBA.TeamList[i].Roster[j].Id == e.PlayerID) world.NBA.TeamList[i].Roster[j].Age++;
                    }
                    else if (e.Sport == Sports.Football)
                    {
                        for (int i = 0; i < world.NFL.TeamList.Count; i++)
                            for (int j = 0; j < world.NFL.TeamList[i].Roster.Count; j++)
                                if (world.NFL.TeamList[i].Roster[j].Id == e.PlayerID) world.NFL.TeamList[i].Roster[j].Age++;
                    }
                    else if (e.Sport == Sports.Hockey)
                    {
                        for (int i = 0; i < world.NHL.TeamList.Count; i++)
                            for (int j = 0; j < world.NHL.TeamList[i].Roster.Count; j++)
                                if (world.NHL.TeamList[i].Roster[j].Id == e.PlayerID) world.NHL.TeamList[i].Roster[j].Age++;
                    }
                    else if (e.Sport == Sports.Soccer)
                    {
                        for (int i = 0; i < world.MLS.TeamList.Count; i++)
                            for (int j = 0; j < world.MLS.TeamList[i].Roster.Count; j++)
                                if (world.MLS.TeamList[i].Roster[j].Id == e.PlayerID) world.MLS.TeamList[i].Roster[j].Age++;
                    }
                }
                else if (e.EventType == CalendarEventType.LoanRepayment)
                {
                    //repay loan
                }
                else if (e.EventType == CalendarEventType.ClientBirthday)
                {
                    int indx = world.MyAgency.Clients.FindIndex(x => (x.FullName == e.PlayerName) && (x.Sport == e.Sport) && (x.Id == e.PlayerID));
                    world.MyAgency.Clients[indx].Age++;
                }
                else if (e.EventType == CalendarEventType.LeagueYearBegins)
                {
                    League l = null;
                    if (e.Sport == Sports.Baseball)
                    {
                        world.MLB.InSeason = true;
                        world.MLB.Initialized = true;
                        world.MLB.WeekNumber = 0;
                        l = world.MLB;
                        world.ResetTeamRecords(world.MLB);
                        world.ResetPlayerStats(world.MLB);
                    }
                    else if (e.Sport == Sports.Basketball)
                    {
                        world.NBA.InSeason = true;
                        world.NBA.Initialized = true;
                        l = world.NBA;
                        world.ResetTeamRecords(world.NBA);
                        world.ResetPlayerStats(world.NBA);
                    }
                    else if (e.Sport == Sports.Football)
                    {
                        world.NFL.InSeason = true;
                        world.NFL.Initialized = true;
                        world.NFL.WeekNumber = 0;
                        l = world.NFL;
                        world.ResetTeamRecords(world.NFL);
                        world.ResetPlayerStats(world.NFL);
                    }
                    else if (e.Sport == Sports.Hockey)
                    {
                        world.NHL.InSeason = true;
                        world.NHL.Initialized = true;
                        world.NHL.WeekNumber = 0;
                        l = world.NHL;
                        world.ResetTeamRecords(world.NHL);
                        world.ResetPlayerStats(world.NHL);
                    }
                    else if (e.Sport == Sports.Soccer)
                    {
                        world.MLS.InSeason = true;
                        world.MLS.Initialized = true;
                        world.MLS.WeekNumber = 0;
                        l = world.MLS;
                        world.ResetTeamRecords(world.MLS);
                        world.ResetPlayerStats(world.MLS);
                    }
                    DetermineSeasons();
                    world.ReorderDepthCharts(l);
                    foreach (Team t in l.TeamList)
                    {
                        world.SetTeamTitleContender(l, t);
                        foreach (Player p in t.Roster)
                        {
                            if (p.Sport == Sports.Baseball) p.IsStarter = world.IsBaseballStarter(t, p);
                            else if (p.Sport == Sports.Basketball) p.IsStarter = world.IsBasketballStarter(t, p);
                            else if (p.Sport == Sports.Football) p.IsStarter = world.IsFootballStarter(t, p);
                            else if (p.Sport == Sports.Hockey) p.IsStarter = world.IsHockeyStarter(t, p);
                            else if (p.Sport == Sports.Soccer) p.IsStarter = world.IsSoccerStarter(t, p);
                        }
                    }
                }
                else if (e.EventType == CalendarEventType.LeagueYearEnds)
                {
                    if (e.Sport == Sports.Baseball) world.PayPlayersAnnualSalary(world.MLB);
                    else if (e.Sport == Sports.Basketball) world.PayPlayersAnnualSalary(world.NBA);
                    else if (e.Sport == Sports.Football) world.PayPlayersAnnualSalary(world.NFL);
                    else if (e.Sport == Sports.Hockey) world.PayPlayersAnnualSalary(world.NHL);
                    else if (e.Sport == Sports.Soccer) world.PayPlayersAnnualSalary(world.MLS);
                    DetermineSeasons();
                }
                else if (e.EventType == CalendarEventType.ProgressionRegression)
                {
                    League league = null;
                    //Association association = null;
                    //newsLabel.Text = "Running progression and regression for " + e.EventName + Environment.NewLine + newsLabel.Text;
                    if (e.Sport == Sports.Baseball) league = world.MLB;
                    else if (e.Sport == Sports.Basketball) league = world.NBA;
                    else if (e.Sport == Sports.Football) league = world.NFL;
                    else if (e.Sport == Sports.Hockey) league = world.NHL;
                    else if (e.Sport == Sports.Soccer) league = world.MLS;
                    //else if (e.Sport == Sports.Boxing) association = world.WBA;
                    //else if (e.Sport == Sports.Golf) association = world.PGA;
                    //else if (e.Sport == Sports.Tennis) association = world.ATP;
                    //else if (e.Sport == Sports.MMA) association = world.UFC;

                    if (league != null)
                    {
                        foreach (Team t in league.TeamList)
                            foreach (Player p in t.Roster) world.ProgressionRegression.PlayerProgression(p);

                        foreach (Player p in league.FreeAgents) world.ProgressionRegression.PlayerProgression(p);

                        world.RetireLeaguePlayers(league);
                    }
                    /*else if (association != null)
                    {
                        foreach (Player p in association.PlayerList) ProgressionRegression.PlayerProgression(p);

                        world.RetireAssociationPlayers(association);
                    }*/

                    //newsLabel.Text = agency.DisplayAgencyProgressionRegression(e.Sport) + Environment.NewLine + newsLabel.Text;
                    //newsLabel.Text = agency.DisplayAgencyRetirements(e.Sport);
                }
                else if (e.EventType == CalendarEventType.DraftDeclaration)
                {
                    if (e.Sport == Sports.Basketball)
                    {
                        world.NBA.DeclaredEntrants = true;
                        //newsLabel.Text = "NBA Declared Entrants = " + world.NBA.DeclaredEntrants + Environment.NewLine + newsLabel.Text;
                    }
                    else if (e.Sport == Sports.Baseball) world.MLB.DeclaredEntrants = true;
                    else if (e.Sport == Sports.Football)
                    {
                        world.NFL.DeclaredEntrants = true;
                        //newsLabel.Text = "NFL Declared Entrants = " + world.NFL.DeclaredEntrants + Environment.NewLine + newsLabel.Text;
                    }
                    else if (e.Sport == Sports.Hockey) world.NHL.DeclaredEntrants = true;
                    else world.MLS.DeclaredEntrants = true;
                }
            }
        }
        public void HandleCalendar(/*Agency agency*/)
        {
            //add 1 to week number
            Week++;

            //check if month ends
            if (((Week == 5) && ((Month) % 3 != 0)) || ((Week == 6) && ((Month) % 3 == 0)))
            {
                SetNewMonth();
                //PayPlayersMonthlySalary();
            }
        }
        private void SetNewMonth()
        {
            Month++;
            if (Month == 13)
            {
                SetNewYear();
            }
            //MonthName = (Months)MonthNumber;
            Week = 1;
            world.MyAgency.PayOfficeMonthlyRent();
        }
        private void SetNewYear()
        {
            Month = 1;
            Year++;
            //CreateAllEvents();
            //IncreasePrizePool();
        }
        public void UpdateCalendarUI()
        {
            mainForm.lblYear.Text = "Y: " + Year.ToString();
            mainForm.lblMonth.Text = "M: " + Month.ToString();
            mainForm.lblWeek.Text = "W: " + Week.ToString();
        }
        public void UpdateDaysUI()
        {
            mainForm.pnlDay1.Visible = true;
        }
        public void DetermineSeasons()
        {
            if (world.MLB.InSeason) mainForm.pictureBaseball.Visible = true;
            else mainForm.pictureBaseball.Visible = false;

            if (world.NBA.InSeason) mainForm.pictureBasketball.Visible = true;
            else mainForm.pictureBasketball.Visible = false;

            if (world.NFL.InSeason) mainForm.pictureFootball.Visible = true;
            else mainForm.pictureFootball.Visible = false;

            if (world.NHL.InSeason) mainForm.pictureHockey.Visible = true;
            else mainForm.pictureHockey.Visible = false;

            if (world.MLS.InSeason) mainForm.pictureSoccer.Visible = true;
            else mainForm.pictureSoccer.Visible = false;
        }
    }
}
