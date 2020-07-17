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
        public GetClientSignedFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }

        public void AttemptToGetPlayerSigned(Player client, League l, Agency a)
        {
            List<Team> interestedTeams = new List<Team>();
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


            }
        }
    }
}
