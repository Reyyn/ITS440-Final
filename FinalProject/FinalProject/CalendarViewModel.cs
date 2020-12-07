using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamForms.Controls;
using System.ComponentModel;

namespace FinalProject {
    public class CalendarViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime? _date;
        public DateTime? Date {
            get {
                return _date;
            }
            set {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<SpecialDate> events;
        public ObservableCollection<SpecialDate> Events {
            get { return events; }
            set { events = value; NotifyPropertyChanged(nameof(Events)); }
        }

        public ICommand DateChosen => new Command((obj) => {
            System.Diagnostics.Debug.WriteLine(obj as DateTime?);
        });

        public CalendarViewModel() {
            Initialize();
        }

        public void Initialize() {
            var dates = new List<SpecialDate>();

            foreach (Event e in App.Database.GetAllEventsAsync().Result) {
                dates.Add(new SpecialDate(e.StartTime) {
                    BackgroundColor = Color.Green,
                    Selectable = true
                });
            }

            dates.Add(new SpecialDate(DateTime.Now) {
                BorderColor = Color.Blue,
                Selectable = true
            });


            Events = new ObservableCollection<XamForms.Controls.SpecialDate>(dates);

            //Events = new ObservableCollection<SpecialDate>(dates) {
            //    new SpecialDate(DateTime.Now.AddDays(2))
            //    {
            //         BackgroundColor = Color.Green,
            //         TextColor = Color.Accent,
            //         BorderColor = Color.Lime,
            //         BorderWidth = 8,
            //         Selectable = true },
            //    new SpecialDate(DateTime.Now.AddDays(3))
            //    {
            //        BackgroundColor = Color.Green,
            //        TextColor = Color.Blue,
            //        Selectable = true,
            //        BackgroundPattern = new BackgroundPattern(1)
            //        {
            //            Pattern = new List<Pattern>
            //            {
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Red},
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Purple},
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Green},
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Yellow,Text = "Test", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle}
            //            }
            //        }
            //    },
            //    new SpecialDate(DateTime.Now.AddDays(4))
            //    {
            //        Selectable = true,
            //        BackgroundPattern = new BackgroundPattern(1)
            //        {
            //            Pattern = new List<Pattern>
            //            {
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.5f, Color = Color.Red},
            //                new Pattern{ WidthPercent = 1f, HightPercent = 0.5f, Color = Color.Purple},
            //            }
            //        },
            //        BackgroundImage = ImageSource.FromFile("ic_calendarCircle.png") as FileImageSource
            //    }
            //};
        }
    }
}
