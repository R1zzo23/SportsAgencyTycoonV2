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

        public void FillTeamRosterComboBox(Team t)
        {
            mainForm.cbTeamRoster.Items.Clear();
            foreach (Player p in t.Roster)
                mainForm.cbTeamRoster.Items.Add(p.Position.ToString() + " " + p.FullName);
            mainForm.lblTeamName.Text = t.City + " " + t.Mascot;
        }
    }
}
