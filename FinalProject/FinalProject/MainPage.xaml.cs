using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new EventViewModel();
        }

        public async void NewEvent(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EventPage());
        }
    }
}
