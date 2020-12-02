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
        private DateTime? _date;
        public DateTime? Date {
            get {
                return _date;
            }
            set {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        public async void EventList(object sender, EventArgs args) {
            ListPage lPage = new ListPage();
            Date sDate = new Date { SelectedDateTime = calendar.SelectedDate };
            lPage.BindingContext = sDate;
            await Navigation.PushAsync(lPage);
        }
    }
}
