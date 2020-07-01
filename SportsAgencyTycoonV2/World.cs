using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class World
    {
        private Agency _MyAgency;
        private Agent _Manager;

        public MainForm mainForm;
        public Random rnd;

        public List<Player> AvailableClients;
        public List<Agent> AvailableAgents;

        public List<League> Leagues;
        public League NBA;
        public League MLB;
        public League NFL;
        public League NHL;
        public League MLS;
        public Basketball Basketball;
        public Baseball Baseball;
        public Football Football;
        public Hockey Hockey;
        public Soccer Soccer;

        public Calendar calendar;
        public EventCalendar eventCalendar;

        public bool RandomLicenseOrder;
        public int NextLicenseCost = 10;
        public List<Sports> LicenseOrder = new List<Sports>();

        public List<CalendarEvent> EventsThisWeek = new List<CalendarEvent>();

        public PlayerGenomeProject PGP = new PlayerGenomeProject();
        public ProgressionRegression ProgressionRegression;

        public World(Random r)
        {
            rnd = r;
            LicenseOrder.Add(Sports.Soccer);
            LicenseOrder.Add(Sports.Hockey);
            LicenseOrder.Add(Sports.Baseball);
            LicenseOrder.Add(Sports.Basketball);
            LicenseOrder.Add(Sports.Football);

            AvailableClients = new List<Player>();
            AvailableAgents = new List<Agent>();
            Leagues = new List<League>();
            eventCalendar = new EventCalendar();

            ProgressionRegression = new ProgressionRegression(rnd, this);
        }

        public Agency MyAgency { get { return _MyAgency; } }
        public Agent Manager { get { return _Manager; } }
        public void SetMyAgency(Agency a)
        {
            _MyAgency = a;
            _MyAgency.AddMoney(35000);
        }
        public void SetManager(Agent a)
        {
            _Manager = a;
            _MyAgency.SetManager(a);
        }
        #region License Order, Obtaining Next License, Set Next License Cost
        public void SetLicenseOrder()
        {
            List<Sports> temp = new List<Sports>();
            foreach (Sports s in LicenseOrder) temp.Add(s);

            LicenseOrder.Clear();

            for (int i = temp.Count; i > 0; i--)
            {
                int index = rnd.Next(0, i);
                LicenseOrder.Add(temp[index]);
                temp.RemoveAt(index);
            }
        }
        public void ObtainNextLicense()
        {
            if (_MyAgency.Licenses.Count == 0)
                _MyAgency.AddLicense(LicenseOrder[0]);
            else if (_MyAgency.Licenses.Count == 1)
                _MyAgency.AddLicense(LicenseOrder[1]);
            else if (_MyAgency.Licenses.Count == 2)
                _MyAgency.AddLicense(LicenseOrder[2]);
            else if (_MyAgency.Licenses.Count == 3)
                _MyAgency.AddLicense(LicenseOrder[3]);
            else if (_MyAgency.Licenses.Count == 4)
                _MyAgency.AddLicense(LicenseOrder[4]);

            _MyAgency.AddInfluencePoints(-NextLicenseCost);
            SetNextLicenseCost();
        }
        public void SetNextLicenseCost()
        {
            if (NextLicenseCost == 10)
                NextLicenseCost = 25;
            else if (NextLicenseCost == 25)
                NextLicenseCost = 50;
            else if (NextLicenseCost == 50)
                NextLicenseCost = 100;
            else if (NextLicenseCost == 100)
                NextLicenseCost = 250;
        }
        #endregion

        public void InitializeWorld()
        {
            CreateLeaguesAssociationEventsPlayersAndTeams();
            //NerfFreeAgentsToStart();
            Basketball = new Basketball(mainForm, rnd, this, NBA);
            Baseball = new Baseball(mainForm, rnd, this, MLB);
            Football = new Football(mainForm, rnd, this, NFL);
            Hockey = new Hockey(mainForm, rnd, this, NHL);
            Soccer = new Soccer(mainForm, rnd, this, MLS);
            //CreateGlobalAchievements();
            //CreateTeamRelationships(MyAgency.Manager);
        }

        #region Create Leagues & Associations
        public void CreateLeaguesAssociationEventsPlayersAndTeams()
        {
            CreateLeagues(rnd);
            //CreateAssociations(rnd);
            //CreateAllEvents();
            //CreateAthletesForAssociations(rnd);
            CreateTeamsForLeagues(rnd);
            AddLeaguesAndAssociationsToWorld();
            //CreateCalendarEventsForAssociationEvents();
            CreatePlayersForTeams(rnd);
            CreateCalendarEventsForLeagueStartAndEnd();
            CreateDraftDeclarationEvents();
            CreateProgressionRegressionEventsForPlayers();
            CreatePlayerBirthdayCalendarEvents();
            //CalculateWorldRankings();
            AssignTeamToPlayersInLeagues();
            DetermineTitleContenderForTeams();
            DetermineHappinessForPlayers();
            CreatePlayerGenomes();
            SetInitialPlayerCareerDates();
            SetAllPlayersToActive();
        }
        public void CreateLeagues(Random rnd)
        {
            NBA = new League(Sports.Basketball, "National Basketball Association", "NBA", rnd.Next(45, 100), new Date(10, 4), new Date(6, 2), 82, 8, 40000000, 582180);
            MLB = new League(Sports.Baseball, "Major League Baseball", "MLB", rnd.Next(30, 70), new Date(4, 1), new Date(10, 4), 162, 6, 35000000, 555000);
            NFL = new League(Sports.Football, "National Football League", "NFL", rnd.Next(50, 100), new Date(9, 3), new Date(2, 1), 16, 6, 30000000, 495000);
            NHL = new League(Sports.Hockey, "National Hockey League", "NHL", rnd.Next(30, 55), new Date(10, 1), new Date(6, 2), 82, 8, 9500000, 650000);
            MLS = new League(Sports.Soccer, "Major League Soccer", "MLS", rnd.Next(15, 50), new Date(3, 2), new Date(12, 1), 34, 9, 7000000, 56250);
        }
        
        public void CreateProgressionRegressionEventsForPlayers()
        {
            foreach (League l in Leagues)
            {
                eventCalendar.AddCalendarEvent(new CalendarEvent("progression/regression", l));
            }
            /*foreach (Association a in Associations)
            {
                eventCalendar.AddCalendarEvent(new CalendarEvent(a));
            }*/
        }
        public void CreateDraftDeclarationEvents()
        {
            foreach (League l in Leagues)
                eventCalendar.AddCalendarEvent(new CalendarEvent(l, l.DraftDeclarationDate));
        }
        /*public void CreateAssociations(Random rnd)
        {
            PGA = new Association(Sports.Golf, "Professional Golf Association", "PGA", rnd.Next(40, 80));
            ATP = new Association(Sports.Tennis, "Association of Tennis Professionals", "ATP", rnd.Next(20, 50));
            WBA = new Association(Sports.Boxing, "World Boxing Association", "WBA", rnd.Next(10, 40));
            UFC = new Association(Sports.MMA, "Ultimate Fighting Championship", "UFC", rnd.Next(30, 60));
        }*/
        #endregion
        #region Create Teams for Leagues
        public void CreateTeamsForLeagues(Random rnd)
        {
            CreateNBATeams(rnd);
            CreateMLBTeams(rnd);
            CreateNHLTeams(rnd);
            CreateNFLTeams(rnd);
            CreateMLSTeams(rnd);
        }
        public void CreateNBATeams(Random rnd)
        {
            NBA.TeamList.Add(new Team("Atlanta", "Hawks", "Eastern", "Southeast", "ATL", 40, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Boston", "Celtics", "Eastern", "Atlantic", "BOS", 60, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Brooklyn", "Nets", "Eastern", "Atlantic", "BKN", 62, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Charlotte", "Hornets", "Eastern", "Southeast", "CHA", 33, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Chicago", "Bulls", "Eastern", "Central", "CHI", 62, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Cleveland", "Cavaliers", "Eastern", "Central", "CLE", 30, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Dallas", "Mavericks", "Western", "Southwest", "DAL", 49, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Denver", "Nuggets", "Western", "Northwest", "DEN", 38, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Detroit", "Pistons", "Eastern", "Central", "DET", 33, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Golden State", "Warriors", "Western", "Pacific", "GSW", 66, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Houston", "Rockets", "Western", "Southwest", "HOU", 49, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Indiana", "Pacers", "Eastern", "Central", "IND", 43, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Los Angeles", "Clippers", "Western", "Pacific", "LAC", 72, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Los Angeles", "Lakers", "Western", "Pacific", "LAL", 75, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Memphis", "Grizzlies", "Western", "Southwest", "MEM", 40, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Miami", "Heat", "Eastern", "Southeast", "MIA", 69, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Milwaukee", "Bucks", "Eastern", "Central", "MIL", 46, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Minnesota", "Timberwolves", "Western", "Northwest", "MIN", 46, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("New Orleans", "Pelicans", "Western", "Southwest", "NOP", 51, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("New York", "Knicks", "Eastern", "Atlantic", "NYK", 82, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Oklahoma City", "Thunder", "Western", "Northwest", "OKC", 48, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Orlando", "Magic", "Eastern", "Southeast", "ORL", 52, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Philadelphia", "76ers", "Eastern", "Atlantic", "PHI", 58, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Phoenix", "Suns", "Western", "Pacific", "PHO", 42, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Portland", "Trail Blazers", "Western", "Northwest", "POR", 54, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Sacramento", "Kings", "Western", "Pacific", "SAC", 54, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("San Antonio", "Spurs", "Western", "Southwest", "SAS", 51, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Toronto", "Raptors", "Eastern", "Atlantic", "TOR", 47, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Utah", "Jazz", "Western", "Northwest", "UTA", 38, rnd.Next(25, 76)));
            NBA.TeamList.Add(new Team("Washington", "Wizards", "Eastern", "Southeast", "WAS", 47, rnd.Next(25, 76)));
        }
        public void CreateMLBTeams(Random rnd)
        {
            MLB.TeamList.Add(new Team("Arizona", "Diamondbacks", "NL", "West", "ARI", 29, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Atlanta", "Braves", "NL", "East", "ATL", 40, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Baltimore", "Orioles", "AL", "East", "BAL", 45, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Boston", "Red Sox", "AL", "East", "BOS", 72, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Chicago", "Cubs", "NL", "Central", "CHC", 71, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Chicago", "White Sox", "AL", "Central", "CHW", 61, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Cincinnati", "Reds", "NL", "Central", "CIN", 30, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Cleveland", "Indians", "AL", "Central", "CLE", 31, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Colorado", "Rockies", "NL", "West", "COL", 29, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Detroit", "Tigers", "AL", "Central", "DET", 38, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Houston", "Astros", "AL", "West", "HOU", 50, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Kansas City", "Royals", "AL", "Central", "KC", 48, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Los Angeles", "Angels", "AL", "West", "LAA", 66, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Los Angeles", "Dodgers", "NL", "West", "LAD", 69, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Miami", "Marlins", "NL", "East", "MIA", 65, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Milwaukee", "Brewers", "NL", "Central", "MIL", 25, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Minnesota", "Twins", "AL", "Central", "MIN", 27, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("New York", "Mets", "NL", "East", "NYM", 80, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("New York", "Yankees", "AL", "East", "NYY", 85, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Oakland", "Athletics", "AL", "West", "OAK", 33, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Philadelphia", "Phillies", "NL", "East", "PHI", 58, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Pittsburgh", "Pirates", "NL", "Central", "PIT", 49, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("San Diego", "Padres", "NL", "West", "SD", 31, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("San Francisco", "Giants", "NL", "West", "SF", 58, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Seattle", "Mariners", "AL", "West", "SEA", 47, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("St. Louis", "Cardinals", "NL", "Central", "STL", 57, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Tampa Bay", "Rays", "AL", "East", "TB", 43, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Texas", "Rangers", "AL", "West", "TEX", 55, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Toronto", "Blue Jays", "AL", "East", "TOR", 52, rnd.Next(25, 76)));
            MLB.TeamList.Add(new Team("Washington", "Nationals", "NL", "East", "WAS", 47, rnd.Next(25, 76)));
        }
        public void CreateNHLTeams(Random rnd)
        {
            NHL.TeamList.Add(new Team("Anaheim", "Ducks", "Western", "Pacific", "ANA", 60, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Arizona", "Coyotes", "Western", "Pacific", "ARI", 23, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Boston", "Bruins", "Eastern", "Atlantic", "BOS", 85, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Buffalo", "Sabres", "Eastern", "Atlantic", "BUF", 43, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Calgary", "Flames", "Western", "Pacific", "CAL", 44, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Carolina", "Hurricanes", "Eastern", "Metropolitan", "CAR", 38, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Chicago", "Blackhawks", "Western", "Central", "CHI", 66, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Colorado", "Avalanche", "Western", "Central", "COL", 44, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Columbus", "Blue Jackets", "Eastern", "Metropolitan", "CLM", 45, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Dallas", "Stars", "Western", "Central", "DAL", 33, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Detroit", "Red Wings", "Eastern", "Atlantic", "DET", 80, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Edmonton", "Oilers", "Western", "Pacific", "EDM", 66, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Florida", "Panthers", "Eastern", "Atlantic", "FLA", 29, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Los Angeles", "Kings", "Western", "Pacific", "LAK", 71, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Minnesota", "Wild", "Western", "Central", "MIN", 61, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Montreal", "Canadiens", "Eastern", "Atlantic", "MON", 85, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Nashville", "Predators", "Western", "Central", "NSH", 60, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("New Jersey", "Devils", "Eastern", "Metropolitan", "NJD", 73, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("New York", "Islanders", "Eastern", "Metropolitan", "NYI", 75, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("New York", "Rangers", "Eastern", "Metropolitan", "NYR", 79, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Ottawa", "Senators", "Eastern", "Atlantic", "OTT", 67, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Philadelphia", "Flyers", "Eastern", "Metropolitan", "PHI", 58, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Pittsburgh", "Penguins", "Eastern", "Metropolitan", "PIT", 59, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("San Jose", "Sharks", "Western", "Pacific", "SJS", 61, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("St. Louis", "Blues", "Western", "Central", "STL", 57, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Tampa Bay", "Lightning", "Eastern", "Atlantic", "TB", 59, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Toronto", "Maples Leafs", "Eastern", "Atlantic", "TOR", 67, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Vancouver", "Canucks", "Western", "Pacific", "VAN", 65, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Vegas", "Golden Knights", "Western", "Pacific", "VEG", 60, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Washington", "Capitals", "Eastern", "Metropolitan", "WAS", 64, rnd.Next(25, 76)));
            NHL.TeamList.Add(new Team("Winnipeg", "Jets", "Western", "Central", "WIN", 46, rnd.Next(25, 76)));
        }
        public void CreateNFLTeams(Random rnd)
        {
            NFL.TeamList.Add(new Team("Arizona", "Cardinals", "NFC", "West", "ARI", 33, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Atlanta", "Falcons", "NFC", "South", "ATL", 44, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Baltimore", "Ravens", "AFC", "North", "BAL", 39, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Buffalo", "Bills", "AFC", "East", "BUF", 33, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Carolina", "Panthers", "NFC", "South", "CAR", 40, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Chicago", "Bears", "NFC", "North", "CHI", 57, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Cincinnati", "Bengals", "AFC", "North", "CIN", 30, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Cleveland", "Browns", "AFC", "North", "CLE", 31, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Dallas", "Cowboys", "NFC", "East", "DAL", 80, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Denver", "Broncos", "AFC", "West", "DEN", 41, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Detroit", "Lions", "NFC", "North", "DET", 38, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Green Bay", "Packers", "NFC", "North", "GB", 58, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Houston", "Texans", "AFC", "South", "HOU", 50, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Indianapolis", "Colts", "AFC", "South", "IND", 40, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Jacksonville", "Jaguars", "AFC", "South", "JAX", 31, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Kansas City", "Chiefs", "AFC", "West", "KC", 48, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Los Angeles", "Chargers", "AFC", "West", "LAC", 77, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Los Angeles", "Rams", "NFC", "West", "LAR", 77, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Miami", "Dolphins", "AFC", "East", "MIA", 85, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Minnesota", "Vikings", "NFC", "North", "MIN", 28, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("New England", "Patriots", "AFC", "East", "NE", 59, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("New Orleans", "Saints", "NFC", "South", "NO", 51, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("New York", "Giants", "NFC", "East", "NYG", 82, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("New York", "Jets", "AFC", "East", "NYJ", 82, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Oakland", "Raiders", "AFC", "West", "OAK", 73, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Philadelphia", "Eagles", "NFC", "East", "PHI", 58, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Pittsburgh", "Steelers", "AFC", "North", "PIT", 54, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("San Francisco", "49ers", "NFC", "West", "SF", 66, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Seattle", "Seahawks", "NFC", "West", "SEA", 47, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Tampa Bay", "Buccaneers", "NFC", "South", "TB", 36, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Tennessee", "Titans", "AFC", "South", "TEN", 48, rnd.Next(25, 76)));
            NFL.TeamList.Add(new Team("Washington", "Redskins", "NFC", "East", "WAS", 47, rnd.Next(25, 76)));
        }
        public void CreateMLSTeams(Random rnd)
        {
            MLS.TeamList.Add(new Team("Atlanta", "United FC", "Eastern", "", "ATL", 55, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Chicago", "Fire", "Eastern", "", "CHI", 45, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Cincinnati", "FC", "Eastern", "", "CIN", 33, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Colorado", "Rapids", "Western", "", "COL", 37, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Columbus", "Crew SC", "Eastern", "", "CLM", 39, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("D.C.", "United", "Eastern", "", "DCU", 41, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Dallas", "FC", "Western", "", "DAL", 43, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Houston", "Dynamo", "Western", "", "HOU", 41, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("LA", "Galaxy", "Western", "", "LAG", 66, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Los Angeles", "FC", "Western", "", "LAFC", 60, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Minnesota", "United FC", "Western", "", "MIN", 37, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Montreal", "Impact", "Eastern", "", "MON", 31, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("New England", "Revolution", "Eastern", "", "NE", 33, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("New York City", "FC", "Eastern", "", "NYCFC", 57, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("New York", "Red Bulls", "Eastern", "", "NYRB", 55, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Orlando City", "FC", "Eastern", "", "ORL", 44, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Philadelphia", "Union", "Eastern", "", "PHI", 31, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Portland", "Timbers", "Western", "", "POR", 62, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Salt Lake", "Real", "Western", "", "RSL", 32, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("San Jose", "Earthquakes", "Western", "", "SJ", 36, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Seattle", "Sounders FC", "Western", "", "SEA", 77, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Kansas City", "Sporting", "Western", "", "KC", 35, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Toronto", "FC", "Eastern", "", "TOR", 41, rnd.Next(25, 76)));
            MLS.TeamList.Add(new Team("Vancouver", "Whitecaps FC", "Western", "", "VAN", 29, rnd.Next(25, 76)));
        }
        #endregion
        public void AddLeaguesAndAssociationsToWorld()
        {
            //add NBA, NFL, MLB, NHL and MLS to World.Leagues
            Leagues.Add(NBA);
            Leagues.Add(NFL);
            Leagues.Add(MLB);
            Leagues.Add(NHL);
            Leagues.Add(MLS);
            //add PGA, ATP, WBA and UFC to World.Associations
            /*Associations.Add(PGA);
            Associations.Add(ATP);
            Associations.Add(WBA);
            Associations.Add(UFC);*/
        }
        #region Create Athletes for Associations and Leagues
        public void CreatePlayersForTeams(Random rnd)
        {
            CreateBasketballPlayers(rnd);
            CreateFootballPlayers(rnd);
            CreateHockeyPlayers(rnd);
            CreateBaseballPlayers(rnd);
            CreateSoccerPlayers(rnd);
        }
        /*public void CreateAthletesForAssociations(Random rnd)
        {
            CreateGolfers(rnd);
            CreateTennisPlayers(rnd);
            CreateBoxers(rnd);
            CreateMMAFighters(rnd);
        }*/
        public void CreateBasketballPlayers(Random rnd)
        {
            for (int i = 0; i < NBA.TeamList.Count; i++)
            {
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PG));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PG));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PG));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SG));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SG));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SF));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SF));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PF));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PF));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.CE));
                NBA.AddPlayer(NBA.TeamList[i].Roster, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.CE));
            }
            // Create Free Agents
            for (int j = 0; j < 7; j++)
            {
                NBA.AddPlayer(NBA.FreeAgents, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PG));
                NBA.AddPlayer(NBA.FreeAgents, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SG));
                NBA.AddPlayer(NBA.FreeAgents, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.SF));
                NBA.AddPlayer(NBA.FreeAgents, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.PF));
                NBA.AddPlayer(NBA.FreeAgents, new BasketballPlayer(rnd, NBA.IdCount, Sports.Basketball, rnd.Next(18, 38), Position.CE));
            }
        }
        public void CreateFootballPlayers(Random rnd)
        {
            for (int i = 0; i < NFL.TeamList.Count; i++)
            {
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.QB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.QB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.RB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.RB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.FB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.FB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.WR));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.WR));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.WR));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.WR));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.TE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.TE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.C));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.C));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.OG));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.OG));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.OT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.OT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DE));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.DT));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.LB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.CB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.CB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.CB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.CB));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.SS));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.SS));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.FS));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.FS));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.K));
                NFL.AddPlayer(NFL.TeamList[i].Roster, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(21, 33), Position.P));
            }
            // Create Free Agents
            for (int j = 0; j < 7; j++)
            {
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.QB));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.RB));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.FB));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.WR));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.TE));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.C));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.OG));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.OT));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.DE));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.DT));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.LB));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.CB));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.SS));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.FS));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.K));
                NFL.AddPlayer(NFL.FreeAgents, new FootballPlayer(rnd, NFL.IdCount, Sports.Football, rnd.Next(18, 38), Position.P));
            }
        }
        public void CreateHockeyPlayers(Random rnd)
        {
            for (int i = 0; i < NHL.TeamList.Count; i++)
            {
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.G));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.G));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.C));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.C));
                NHL.AddPlayer(NHL.TeamList[i].Roster, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.C));
            }
            // Create Free Agents
            for (int j = 0; j < 7; j++)
            {
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.G));
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.D));
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.W));
                NHL.AddPlayer(NHL.FreeAgents, new HockeyPlayer(rnd, NHL.IdCount, Sports.Hockey, rnd.Next(18, 38), Position.C));
            }
        }
        public void CreateBaseballPlayers(Random rnd)
        {
            for (int i = 0; i < MLB.TeamList.Count; i++)
            {
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.C));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.C));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.INF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.OF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.OF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.OF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.OF));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.SP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.SP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.SP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.SP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.RP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.RP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.RP));
                MLB.AddPlayer(MLB.TeamList[i].Roster, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 37), Position.RP));
            }
            // Create Free Agents
            for (int j = 0; j < 7; j++)
            {
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.C));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.INF));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.INF));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.OF));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.OF));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.SP));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.SP));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.RP));
                MLB.AddPlayer(MLB.FreeAgents, new BaseballPlayer(rnd, MLB.IdCount, Sports.Baseball, rnd.Next(18, 38), Position.RP));
            }
        }
        public void CreateSoccerPlayers(Random rnd)
        {
            for (int i = 0; i < MLS.TeamList.Count; i++)
            {
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.GK));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.GK));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.D));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.D));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.D));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.D));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.D));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.MID));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.MID));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.MID));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.MID));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.MID));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.F));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.F));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.F));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.F));
                MLS.AddPlayer(MLS.TeamList[i].Roster, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 36), Position.F));
            }
            // Create Free Agents
            for (int j = 0; j < 7; j++)
            {
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.GK));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.D));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.D));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.MID));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.MID));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.F));
                MLS.AddPlayer(MLS.FreeAgents, new SoccerPlayer(rnd, MLS.IdCount, Sports.Soccer, rnd.Next(16, 33), Position.F));
            }
        }
        /*public void CreateGolfers(Random rnd)
        {
            for (var i = 0; i < 144; i++)
            {
                PGA.PlayerList.Add(new Golfer(rnd, i, Sports.Golf, rnd.Next(18, 65)));
            }
        }
        public void CreateTennisPlayers(Random rnd)
        {
            for (var i = 0; i < 128; i++)
            {
                ATP.PlayerList.Add(new TennisPlayer(rnd, i, Sports.Tennis, rnd.Next(18, 35)));
            }
        }
        public void CreateBoxers(Random rnd)
        {
            for (var i = 0; i < 40; i++)
            {
                WBA.PlayerList.Add(new Boxer(rnd, i, Sports.Boxing, rnd.Next(16, 34)));
            }
        }
        public void CreateMMAFighters(Random rnd)
        {
            for (var i = 0; i < 50; i++)
            {
                UFC.PlayerList.Add(new MMAFighter(rnd, i, Sports.MMA, rnd.Next(17, 31)));
            }
        }*/
        public void CreatePlayerGenomes()
        {
            foreach (League l in Leagues)
            {
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                        PGP.CreatePGP(rnd, p);
                foreach (Player p in l.FreeAgents)
                    PGP.CreatePGP(rnd, p);
            }
            /*foreach (Association a in Associations)
                foreach (Player p in a.PlayerList)
                    PGP.CreatePGP(rnd, p);*/
        }
        public void CreatePlayerBirthdayCalendarEvents()
        {
            /*foreach (Association a in Associations)
                foreach (Player p in a.PlayerList)
                    Calendar.AddCalendarEvent(new CalendarEvent(p));*/

            foreach (League l in Leagues)
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                        eventCalendar.AddCalendarEvent(new CalendarEvent(p));
        }
        #endregion
        public void CreateCalendarEventsForLeagueStartAndEnd()
        {
            foreach (League l in Leagues)
            {
                eventCalendar.AddCalendarEvent(new CalendarEvent(l));
                eventCalendar.AddCalendarEvent(new CalendarEvent(l, "end"));
            }
        }
        public void AssignTeamToPlayersInLeagues()
        {
            foreach (League l in Leagues)
            {
                foreach (Player p in l.FreeAgents)
                {
                    p.League = l;
                    p.Team = null;
                    p.FreeAgent = true;
                }

                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                    {
                        p.Team = t;
                        p.League = l;
                        p.Contract = p.CreatePlayerContract(rnd);
                        p.FreeAgent = false;
                    }
            }
        }
        public void DetermineTitleContenderForTeams()
        {
            foreach (League l in Leagues)
                foreach (Team t in l.TeamList)
                {
                    SetTeamTitleContender(l, t);
                }
        }
        public void SetTeamTitleContender(League l, Team t)
        {
            int titleContender = 0;
            int topHalfTotal = 0;
            int numberOfStarters = 0;
            int numberOfBackups = 0;
            int bottomHalfAverage = 0;
            int rosterCount = t.Roster.Count();

            if (rosterCount % 2 == 0) numberOfStarters = rosterCount / 2;
            else numberOfStarters = (int)((rosterCount / 2) - 0.5);

            numberOfBackups = rosterCount - numberOfStarters;

            List<Player> roster = new List<Player>();

            foreach (Player p in t.Roster) roster.Add(p);

            roster = roster.OrderByDescending(o => o.CurrentSkill).ToList();

            // add every player's CurrentSkill from top half of roster
            for (int i = 0; i < numberOfStarters; i++)
            {
                topHalfTotal += roster[i].CurrentSkill;
            }

            // add average of bottom half of the roster's CurrentSkill
            for (int i = numberOfStarters; i < t.Roster.Count; i++)
            {
                bottomHalfAverage += roster[i].CurrentSkill;
            }

            bottomHalfAverage = bottomHalfAverage / numberOfBackups;

            titleContender = (int)(topHalfTotal + bottomHalfAverage) / (numberOfStarters + 1);
            t.TitleConteder = titleContender;
        }
        public void DetermineHappinessForPlayers()
        {
            foreach (League l in Leagues)
            {
                ReorderDepthCharts(l);
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                    {
                        bool isStarter;

                        // determine player TeamHappiness
                        if (p.Sport == Sports.Basketball) isStarter = IsBasketballStarter(t, p);
                        else if (p.Sport == Sports.Baseball) isStarter = IsBaseballStarter(t, p);
                        else if (p.Sport == Sports.Football) isStarter = IsFootballStarter(t, p);
                        else if (p.Sport == Sports.Hockey) isStarter = IsHockeyStarter(t, p);
                        else if (p.Sport == Sports.Soccer) isStarter = IsSoccerStarter(t, p);
                        else isStarter = false;

                        p.DetermineTeamHappiness(rnd, isStarter);

                        // determine player AgencyHappiness
                        p.DetermineAgencyHappiness(rnd, p.Contract);
                    }
            }
            /*foreach (Association a in Associations)
                foreach (Player p in a.PlayerList)
                    p.DetermineAgencyHappiness(rnd, p.Contract);*/
        }
        #region Is Player A Starter
        public void ReorderDepthCharts(League l)
        {
            List<Player> playersAtPosition = new List<Player>();
            foreach (Team t in l.TeamList)
            {
                foreach (Player p in t.Roster)
                {
                    playersAtPosition.Clear();
                    foreach (Player x in t.Roster)
                    {
                        if (x.Position == p.Position) playersAtPosition.Add(x);
                    }
                    playersAtPosition = playersAtPosition.OrderByDescending(o => o.CurrentSkill).ToList();
                    for (int i = 0; i < playersAtPosition.Count; i++)
                    {
                        playersAtPosition[i].DepthChart = i + 1;
                    }
                }
            }
        }
        public bool IsBasketballStarter(Team t, Player p)
        {
            bool starter = false;
            BasketballPlayer player = (BasketballPlayer)p;
            Position position = player.Position;
            List<BasketballPlayer> playersAtPosition = new List<BasketballPlayer>();

            foreach (BasketballPlayer b in t.Roster)
                if (b.Position == position) playersAtPosition.Add(b);

            playersAtPosition = playersAtPosition.OrderByDescending(o => o.CurrentSkill).ToList();

            for (int i = 0; i < playersAtPosition.Count; i++)
            {
                playersAtPosition[i].DepthChart = i + 1;
            }

            if (player == playersAtPosition[0]) starter = true;
            else starter = false;

            player.IsStarter = starter;

            return starter;
        }
        public bool IsBaseballStarter(Team t, Player p)
        {
            Position position = p.Position;
            int starterCount = 0;

            if (position == Position.INF) starterCount = 4;
            else if (position == Position.OF) starterCount = 3;
            else if (position == Position.SP) starterCount = 3;
            else if (position == Position.C) starterCount = 1;
            else if (position == Position.RP) starterCount = 2;

            if (p.DepthChart <= starterCount)
            {
                if (p.MemberOfAgency)
                    Console.WriteLine("test");
                p.IsStarter = true;
                return true;
            }
            else
            {
                p.IsStarter = false;
                return false;
            }
        }
        public bool IsFootballStarter(Team t, Player p)
        {
            Position position = p.Position;
            int starterCount = 0;

            if (position == Position.WR || position == Position.DE || position == Position.DT || position == Position.OT || position == Position.OG)
                starterCount = 2;
            else if (position == Position.LB) starterCount = 4;
            else starterCount = 1;

            if (p.DepthChart <= starterCount)
            {
                if (p.MemberOfAgency)
                    Console.WriteLine("test");
                p.IsStarter = true;
                return true;
            }
            else
            {
                p.IsStarter = false;
                return false;
            }
        }
        public bool IsHockeyStarter(Team t, Player p)
        {
            Position position = p.Position;
            int starterCount = 0;

            if (position == Position.G) starterCount = 1;
            else if (position == Position.W || position == Position.D) starterCount = 4;
            else starterCount = 2;

            if (p.DepthChart <= starterCount)
            {
                if (p.MemberOfAgency)
                    Console.WriteLine("test");
                p.IsStarter = true;
                return true;
            }
            else
            {
                p.IsStarter = false;
                return false;
            }
        }
        public bool IsSoccerStarter(Team t, Player p)
        {
            Position position = p.Position;
            int starterCount = 0;

            if (position == Position.GK) starterCount = 1;
            else if (position == Position.F || position == Position.D) starterCount = 4;
            else starterCount = 3;

            if (p.DepthChart <= starterCount)
            {
                if (p.MemberOfAgency)
                    Console.WriteLine("test");
                p.IsStarter = true;
                return true;
            }
            else
            {
                p.IsStarter = false;
                return false;
            }
        }
        #endregion
        public void SetInitialPlayerCareerDates()
        {
            foreach (League l in Leagues)
            {
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                        p.DetermineCareerStartYear(calendar.Year);
                foreach (Player p in l.FreeAgents)
                    p.DetermineCareerStartYear(calendar.Year);
            }
            /*foreach (Association a in Associations)
                foreach (Player p in a.PlayerList)
                    p.DetermineCareerStartYear(Year);*/
        }
        public void SetAllPlayersToActive()
        {
            foreach (League l in Leagues)
            {
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                        p.PlayerStatus = PlayerType.Active;
                foreach (Player p in l.FreeAgents)
                    p.PlayerStatus = PlayerType.Active;
            }
            /*foreach (Association a in Associations)
                foreach (Player p in a.PlayerList)
                    p.PlayerStatus = PlayerType.Active;*/
        }
        public void RetireLeaguePlayers(League league)
        {
            int count = 0;
            foreach (Team t in league.TeamList)
            {
                for (int i = t.Roster.Count - 1; i > 0; i--)
                {
                    if (t.Roster[i].Retiring)
                    {
                        ProgressionRegression.RetirePlayer(t.Roster[i]);
                        count++;
                    }
                }
            }
            for (int j = league.FreeAgents.Count - 1; j > 0; j--)
            {
                if (league.FreeAgents[j].Retiring)
                {
                    ProgressionRegression.RetirePlayer(league.FreeAgents[j]);
                    count++;
                }
            }
            Console.WriteLine(league.Name + " retirements this year: " + count);
        }
        public void CheckForEventsThisWeek()
        {
            EventsThisWeek.Clear();
            foreach (CalendarEvent e in eventCalendar.Events)
            {
                if (e.EventDate.Week == calendar.Week && e.EventDate.MonthNumber == calendar.Month) EventsThisWeek.Add(e);
            }
        }
        public void PayPlayersAnnualSalary(League l)
        {
            if (l.Initialized)
            {
                foreach (Team t in l.TeamList)
                    foreach (Player p in t.Roster)
                    {
                        //add one year to player's experience
                        p.Experience++;

                        // all players getting paid annually get their money
                        if (p.Contract.AgentPaySchedule == PaySchedule.Annually)
                        {
                            p.CareerEarnings += p.Contract.YearlySalary;
                            // if player is member of agency, agency gets paid too
                            if (p.MemberOfAgency)
                            {
                                MyAgency.AddMoney(Convert.ToInt32((double)p.Contract.YearlySalary * (double)(p.Contract.AgentPercentage / 100)));
                                //find which Agent represents this client and give money to Agent
                                //MyAgency.FindAgent(p).CareerEarnings += Convert.ToInt32((double)p.Contract.YearlySalary * (double)(p.Contract.AgentPercentage / 100));
                            }
                        }
                        p.Contract.Years--;
                    }
                l.InSeason = false;
                MakePlayerAFreeAgent(l);
            }
        }
        private void MakePlayerAFreeAgent(League l)
        {
            for (int i = 0; i < l.TeamList.Count; i++)
                for (int j = l.TeamList[i].Roster.Count - 1; j >= 0; j--)
                {
                    if (l.TeamList[i].Roster[j].Contract.Years == 0)
                    {
                        l.TeamList[i].Roster[j].Contract.MonthlySalary = 0;
                        l.TeamList[i].Roster[j].Contract.YearlySalary = 0;
                        l.TeamList[i].Roster[j].Contract.SigningBonus = 0;
                        l.TeamList[i].Roster[j].FormerTeam = l.TeamList[i].Roster[j].Team;
                        l.TeamList[i].Roster[j].Team = null;
                        l.FreeAgents.Add(l.TeamList[i].Roster[j]);
                        l.TeamList[i].Roster[j].FreeAgent = true;
                        l.TeamList[i].Roster.RemoveAt(j);
                    }
                }
        }
        public void ResetPlayerStats(League l)
        {
            foreach (Team t in l.TeamList)
            {
                if (l.Sport == Sports.Football)
                {
                    foreach (FootballPlayer p in t.Roster)
                    {
                        p.PassingTDs = 0;
                        p.PassingYards = 0;
                        p.Interceptions = 0;
                        p.Receptions = 0;
                        p.ReceivingYards = 0;
                        p.ReceivingYardsThisWeek = 0;
                        p.ReceivingTDs = 0;
                        p.Carries = 0;
                        p.RushingYards = 0;
                        p.YardsPerCarry = 0.0;
                        p.RushingTDs = 0;
                        p.Fumbles = 0;
                        p.Tackles = 0;
                        p.DefensiveInterceptions = 0;
                        p.TacklesForLoss = 0;
                        p.Sacks = 0;
                        p.FGAttempts = 0;
                        p.FGMakes = 0;
                        p.XPAttempts = 0;
                        p.XPMakes = 0;
                        p.Punts = 0;
                        p.NetPuntYards = 0;
                        p.NetPuntAverage = 0;
                        p.SacksAllowed = 0;
                        p.PassesDefended = 0;
                        p.PancakeBlocks = 0;
                        p.MVPScore = 0;
                        p.OPOYScore = 0;
                        p.DPOYScore = 0;
                    }
                }
                else if (l.Sport == Sports.Basketball)
                {
                    foreach (BasketballPlayer p in t.Roster)
                    {
                        p.Points = 0.0;
                        p.Rebounds = 0.0;
                        p.Assists = 0.0;
                        p.Steals = 0.0;
                        p.Blocks = 0.0;
                        p.MVPScore = 0.0;
                        p.DPOYScore = 0.0;
                    }
                }
                else if (l.Sport == Sports.Baseball)
                {
                    foreach (BaseballPlayer p in t.Roster)
                    {
                        p.Average = 0.0;
                        p.HomeRuns = 0;
                        p.RBI = 0;
                        p.ERA = 0.00;
                        p.Wins = 0;
                        p.Losses = 0;
                        p.Saves = 0;
                    }
                }
                else if (l.Sport == Sports.Hockey)
                {
                    foreach (HockeyPlayer p in t.Roster)
                    {
                        p.Goals = 0;
                        p.Assists = 0;
                        p.Points = 0;
                        p.GAA = 0.0;
                        p.GoalsAllowed = 0;
                        p.SavePercentage = 0.0;
                        p.Saves = 0;
                        p.ShutOuts = 0;
                        p.GamesPlayed = 0;
                        p.Wins = 0;
                        p.Losses = 0;
                    }
                }
                else if (l.Sport == Sports.Soccer)
                {
                    foreach (SoccerPlayer p in t.Roster)
                    {
                        p.Goals = 0;
                        p.Assists = 0;
                        p.MatchRating = 0.00;
                        p.Saves = 0;
                        p.CleanSheets = 0;
                    }
                }
            }


        }
        public void ResetTeamRecords(League l)
        {
            foreach (Team t in l.TeamList)
            {
                t.Wins = 0;
                t.ConferenceWins = 0;
                t.DivisionWins = 0;
                t.Losses = 0;
                t.Ties = 0;
                t.OTLosses = 0;
                t.ConferenceLosses = 0;
                t.DivisionLosses = 0;
            }
            //set league.Playoffs to false
            l.Playoffs = false;
        }
        /*public void RetireAssociationPlayers(Association association)
        {
            for (int i = association.PlayerList.Count - 1; i > 0; i--)
            {
                if (association.PlayerList[i].Retiring) ProgressionRegression.RetirePlayer(association.PlayerList[i]);
            }
        }*/
    }
}
