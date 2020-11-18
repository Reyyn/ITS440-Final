using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject 
{
    public class Event
    {
        //declare class variables
        public string EventName { get; set; }
        public string EventDecription { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }

        //declare constructor
        public Event(string e, string d, DateTime start, DateTime end)
        {
            this.EventName = e;
            this.EventDecription = d;
            this.EventStartDate = start;
            this.EventEndDate = end;
        }
    }
}
