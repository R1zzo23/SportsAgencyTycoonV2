using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class AgencyClientsPanelFunctions
    {
        MainForm mainForm;
        World world;
        int index = 0;
        public AgencyClientsPanelFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }
        public void DisplayClient(int i)
        {
            if (world.MyAgency.ClientCount - 1 >= i)
            {
                mainForm.lblClientName.Text = world.MyAgency.Clients[i].FullName;
                if (world.MyAgency.Clients[i].FreeAgent)
                {
                    mainForm.lblClientPosAndTeam.Text = "Free Agent " + world.MyAgency.Clients[i].Position.ToString();
                    mainForm.btnCallForClient.Text = "Call Teams";
                }
                else
                {
                    mainForm.lblClientPosAndTeam.Text = world.MyAgency.Clients[i].Position.ToString() + " for " + world.MyAgency.Clients[i].Team.Abbreviation;
                    mainForm.btnCallForClient.Text = "Call Team";
                }
                    
                DisplayClientSportImage(world.MyAgency.Clients[i].Sport);
                mainForm.lblClientAgencyHappiness.Text = world.MyAgency.Clients[i].AgencyHappinessString;
                mainForm.lblClientTeamHappiness.Text = world.MyAgency.Clients[i].TeamHappinessString;
                mainForm.lblClientPopularity.Text = world.MyAgency.Clients[i].PopularityString;


            }
        }
        public void DisplayClientSportImage(Sports s)
        {
            if (s == Sports.Baseball)
                mainForm.clientSportImage.Image = Properties.Resources.baseball;
            else if (s == Sports.Basketball)
                mainForm.clientSportImage.Image = Properties.Resources.basketball;
            else if (s == Sports.Football)
                mainForm.clientSportImage.Image = Properties.Resources.football;
            else if (s == Sports.Hockey)
                mainForm.clientSportImage.Image = Properties.Resources.hockey;
            else if (s == Sports.Soccer)
                mainForm.clientSportImage.Image = Properties.Resources.soccer;
        }
        public void ScrollLeft()
        {
            if (index == 0)
                index = world.MyAgency.ClientCount - 1;
            else index--;

            DisplayClient(index);
        }
        public void ScrollRight()
        {
            if (index == world.MyAgency.ClientCount - 1)
                index = 0;
            else index++;

            DisplayClient(index);
        }
        public void CallTeamOrTeams()
        {
            Player selectedPlayer = world.MyAgency.Clients[index];
            if (selectedPlayer.FreeAgent)
                CallTeamsToSignClient(selectedPlayer);
            else
                CallClientsTeam(selectedPlayer);
        }
        public void CallTeamsToSignClient(Player selectedPlayer)
        {
            Console.WriteLine("Calling teams to sign client...");
            League league = world.Leagues[world.Leagues.FindIndex(o => o.Sport == selectedPlayer.Sport)];
            GetClientSignedFunctions getClientSignedFunctions = new GetClientSignedFunctions(mainForm, world);
            getClientSignedFunctions.AttemptToGetPlayerSigned(selectedPlayer, league, world.MyAgency);
        }
        public void CallClientsTeam(Player selectedPlayer)
        {
            Console.WriteLine("Calling client's current team...");
        }
    }
}
