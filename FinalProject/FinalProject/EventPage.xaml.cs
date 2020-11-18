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
        public EventPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text)
                && !string.IsNullOrWhiteSpace(descriptionEntry.Text)
                && !string.IsNullOrEmpty(locationEntry.Text)) {
                
                await App.Database.SaveEventAsync(new Event {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Location = locationEntry.Text
                });
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