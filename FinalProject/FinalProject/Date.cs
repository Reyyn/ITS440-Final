using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject {
    class Date {
        public DateTime? SelectedDateTime { get; set; }
        public string SelectedDate {
            get {
                return ((DateTime)SelectedDateTime).ToShortDateString();
            }
        }
    }
}
