using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinalProject {
    /// <summary>
    /// Represents a calendar event.
    /// </summary>
    public class Event {
        [PrimaryKey, AutoIncrement]
        /// <summary>
        /// Primary key of the database row.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Location of the event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Start date and time of the event.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End date and time of the event.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Minutes before event start time to send a reminder.
        /// </summary>
        public TimeSpan Reminder { get; set; }
    }
}
