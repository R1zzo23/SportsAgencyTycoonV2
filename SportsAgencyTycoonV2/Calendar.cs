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
        int Year;
        int Month;
        int Week;
        int Day;
        Timer calendarTimer;

        public Calendar(MainForm mf, int y, int m, int w)
        {
            mainForm = mf;
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
            calendarTimer.Interval = 500;
            // Connect the Tick event of the timer to its event handler.
            calendarTimer.Tick += new EventHandler(IncreaseDays);
            // Start the timer.
            calendarTimer.Start();
        }
        private void IncreaseDays(object sender, EventArgs e)
        {
            Day++;
            if (Day <= 6)
            {
                mainForm.dayMarkers[Day].Visible = true;
            }
            else
            {
                for (int i = 1; i < Day; i++)
                    mainForm.dayMarkers[i].Visible = false;
                Day = 0;
                HandleCalendar();
                UpdateCalendarUI();
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
    }
}
