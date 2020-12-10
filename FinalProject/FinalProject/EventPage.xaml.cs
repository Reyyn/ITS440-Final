using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormsControls.Base;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage, IAnimationPage
    {
        //declare class variable
        Event classCurEvent = new Event();


        public IPageAnimation PageAnimation { get; } = new PushPageAnimation
        { 
            Duration = AnimationDuration.Short, 
            Subtype = AnimationSubtype.FromRight 
        };

        public void OnAnimationStarted(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        public void OnAnimationFinished(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        //new page constructor
        public EventPage()
        {
            InitializeComponent();

            eventNameLabel.Text = "New Event";
            NewEventSaveButton.IsVisible = true;        //make correct button visible
        }

        //edit event page constructor
        public EventPage(Event curEvent)
        {
            InitializeComponent();
            //populate page with correct information on chosen event
            eventNameLabel.Text = curEvent.Name;
            nameEntry.Text = curEvent.Name;
            locationEntry.Text = curEvent.Location;
            descriptionEntry.Text = curEvent.Description;
            startTime.Time = curEvent.StartTime.TimeOfDay;
            endTime.Time = curEvent.EndTime.TimeOfDay;
            //make correct button visisble
            EditEventButton.IsVisible = true;
            //save info on curEvent to class variable for use elsewhere
            classCurEvent = curEvent;
        }

        async void SaveNewEvent(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(descriptionEntry.Text)
                && !string.IsNullOrEmpty(locationEntry.Text)) {

                // takes the selected date from the calendar and adds the start time timespan
                // to get a combined DateTime for the start time.
                DateTime start = (DateTime)((Date)BindingContext).SelectedDateTime;
                start.Add(startTime.Time);

                // do the same for end time
                DateTime end = (DateTime)((Date)BindingContext).SelectedDateTime;
                end.Add(endTime.Time);

                classCurEvent = new Event {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Location = locationEntry.Text,
                    StartTime = start,
                    EndTime = end
                };

                await App.Database.SaveEventAsync(classCurEvent);

                await Navigation.PopAsync(); //return to list page
            }
        }

        async void EditEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(descriptionEntry.Text)
                && !string.IsNullOrEmpty(locationEntry.Text)) {

                // takes the selected date from current event and adds the timpicker timespan
                // to get a combined DateTime for the start time.
                DateTime start = classCurEvent.StartTime.Date;
                start.Add(startTime.Time);

                // do the same for end time
                DateTime end = classCurEvent.EndTime.Date;
                end.Add(endTime.Time);

                //delete old event
                await App.Database.RemoveEventAsync(classCurEvent);
                //save new event
                await App.Database.SaveEventAsync(new Event {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Location = locationEntry.Text,
                    StartTime = start,
                    EndTime = end
                }) ;

                await Navigation.PopAsync(); //returns to list page
            }
        }
    }
}