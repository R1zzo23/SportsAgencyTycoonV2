using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Calendar
    {
        MainForm mainForm;
        int Year;
        int Month;
        int Week;

        public Calendar(MainForm mf, int y, int m, int w)
        {
            mainForm = mf;
            Year = y;
            Month = m;
            Week = w;

            UpdateCalendarUI();
        }
        public void UpdateCalendarUI()
        {
            mainForm.lblYear.Text = "Y: " + Year.ToString();
            mainForm.lblMonth.Text = "M: " + Month.ToString();
            mainForm.lblWeek.Text = "W: " + Week.ToString();

            UpdateDaysUI();
        }
        public void UpdateDaysUI()
        {
            mainForm.pnlDay1.Visible = true;
        }
    }
}
