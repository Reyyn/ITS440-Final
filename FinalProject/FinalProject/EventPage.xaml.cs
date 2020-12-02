using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        //declare class variable
        Event classCurEvent = new Event();

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
            //make correct button visisble
            EditEventButton.IsVisible = true;
            //save info on curEvent to class variable for use elsewhere
            classCurEvent = curEvent;
        }

        async void SaveNewEvent(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(descriptionEntry.Text)
                && !string.IsNullOrEmpty(locationEntry.Text)) {
                
                await App.Database.SaveEventAsync(new Event {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Location = locationEntry.Text
                });

                await Navigation.PopToRootAsync(); //return to main page
            }
        }

        async void EditEvent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(descriptionEntry.Text)
                && !string.IsNullOrEmpty(locationEntry.Text))
            {
                //delete old event
                await App.Database.RemoveEventAsync(classCurEvent);
                //save new event
                await App.Database.SaveEventAsync(new Event
                {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Location = locationEntry.Text
                });

                await Navigation.PopToRootAsync(); //returns to main page
            }
        }
    }

    class EventViewModel
    {
        //declare commands
        public ICommand UpdateEventCommand => new Command(UpdateEvent);
        
        //declare properties
        public string EntryEventName { get; set; }
        public string EntryEventLocation { get; set; }
        public string EntryEventDescription { get; set; }

        public void UpdateEvent()
        {
            //TBD  
        }

    }
}