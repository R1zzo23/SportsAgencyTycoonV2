using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class GetClientSignedFunctions
    {
        MainForm mainForm;
        World world;
        Agency agency;
        Player client;
        League league;
        List<Team> interestedTeams = new List<Team>();

        public GetClientSignedFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }

        public void AttemptToGetPlayerSigned(Player c, League l, Agency a)
        {
            agency = a;
            client = c;
            league = l;
            mainForm.clientTeamNegotiationPanel.Visible = true;
            GatherInterestedTeams(client, league);
        }
        private void GatherInterestedTeams(Player client, League l)
        {
            foreach (Team t in l.TeamList)
            {
                bool interested = false;

                List<Player> playersAtPosition = new List<Player>();
                foreach (Player p in t.Roster)
                    if (p.Position == client.Position)
                        playersAtPosition.Add(p);

                playersAtPosition = playersAtPosition.OrderByDescending(o => o.CurrentSkill).ToList();

                // check if player is better than anyone on the roster at same position
                if (client.CurrentSkill > playersAtPosition[0].CurrentSkill)
                    interested = true;

                // check if player has more potential than last guy on roster at same position
                if (client.PotentialSkill > playersAtPosition[playersAtPosition.Count - 1].PotentialSkill)
                    interested = true;

                if (interested) interestedTeams.Add(t);
            }

            Console.WriteLine("Teams Interested:");
            foreach (Team t in interestedTeams)
                Console.WriteLine("- " + t.City + " " + t.Mascot);

            mainForm.lblNumberOfTeamsInterested.Text = "# of Teams Interested: " + interestedTeams.Count.ToString();
            if (interestedTeams.Count > 0)
                mainForm.gbNegotiationFocus.Visible = true;
            else mainForm.gbNegotiationFocus.Visible = false;
        }
        public void BeginNegotiations()
        {

        }
    }
}
