using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class EventCalendar
    {
        public MainForm MainForm;
        public List<CalendarEvent> Events = new List<CalendarEvent>();

        /*public EventCalendar(MainForm form)
        {
            MainForm = form;
        }*/
        public void AddCalendarEvent(CalendarEvent e)
        {
            Events.Add(e);
        }
    }
}
