using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject {
    public class Event {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Reminder { get; set; }
      
        public Event(string e, string d, DateTime start, DateTime end)
        {
            this.Name = e;
            this.Decription = d;
            this.StartTime = start;
            this.EndTime = end;
        }

    }
}
