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