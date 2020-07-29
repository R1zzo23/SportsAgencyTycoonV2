using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class ManagerPanelFunctions
    {
        MainForm mainForm;
        World world;
        string focus = "";
        int searchInvestment = 0;
        public ManagerPanelFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }
        public void DisplayInfo()
        {
            mainForm.lblManagerActionsAndName.Text = world.MyAgency.Manager.FullName + "'s Office";
            mainForm.rbBalancedAgent.Checked = false;
            mainForm.rbNegotiatingAgent.Checked = false;
            mainForm.rbGreedAgent.Checked = false;
            mainForm.rbScoutingAgent.Checked = false;
            mainForm.rbPowerAgent.Checked = false;
            mainForm.rb25kAgent.Checked = false;
            mainForm.rb50kAgent.Checked = false;
            mainForm.rb100kAgent.Checked = false;
            mainForm.rb250kAgent.Checked = false;
            mainForm.rb500kAgent.Checked = false;
            focus = "";
            searchInvestment = 0;
        }
        public void ChangeFocus(string s)
        {
            focus = s;
            Console.WriteLine(focus);
        }
        public void ChangeInvestmentAmount(int i)
        {
            searchInvestment = i;
            Console.WriteLine(searchInvestment.ToString("C0"));
        }
        public void SearchForAgent()
        {
            Console.WriteLine("focus: " + focus);
            Console.WriteLine("$$$: " + searchInvestment.ToString("C0"));
        }
    }
}
