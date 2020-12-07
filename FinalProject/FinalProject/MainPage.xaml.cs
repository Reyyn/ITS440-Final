using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamForms.Controls;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CalendarViewModel();
        }

        public async void EventList(object sender, EventArgs args) {
            if (calendar.SelectedDate != null) {
                ListPage lPage = new ListPage();
                Date sDate = new Date { SelectedDateTime = calendar.SelectedDate };
                lPage.BindingContext = sDate;
                await Navigation.PushAsync(lPage);
            }
        }

        protected override void OnAppearing() {
            ((CalendarViewModel)BindingContext).Initialize();
        }
    }
}
