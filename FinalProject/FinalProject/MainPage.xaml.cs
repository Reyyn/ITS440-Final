using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        List<XamForms.Controls.SpecialDate> Events;

        public MainPage()
        {
            InitializeComponent();
            List<XamForms.Controls.SpecialDate> Events = new List<XamForms.Controls.SpecialDate>();

            foreach (Event e in App.Database.GetAllEventsAsync().Result) {
                Events.Add(new XamForms.Controls.SpecialDate(e.StartTime) {
                    BackgroundColor = Color.Red
                });
            }
        }

        public async void EventList(object sender, EventArgs args) {
            ListPage lPage = new ListPage();
            Date sDate = new Date { SelectedDateTime = calendar.SelectedDate };
            lPage.BindingContext = sDate;
            await Navigation.PushAsync(lPage);
        }
    }
}
