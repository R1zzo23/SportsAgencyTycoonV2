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
            }
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
    }
}
