using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage {
        public ListPage() {
            InitializeComponent();
        }

        public async void NewEvent(object sender, EventArgs args) {
            EventPage ePage = new EventPage();
            ePage.BindingContext = this.BindingContext;
            await Navigation.PushAsync(ePage);
        }

        public async void EditEvent(object sender, EventArgs args) {
            if (listView.SelectedItem != null)
                await Navigation.PushAsync(new EventPage((Event)listView.SelectedItem));
            else
                await DisplayAlert("ERROR", "You did not select an event to edit.", "OK");
        }

        public async void RemoveEvent(object sender, EventArgs args) {
            if (listView.SelectedItem != null) {
                await App.Database.RemoveEventAsync((Event)listView.SelectedItem);  //remove selected event
                //await Navigation.PushAsync(new MainPage());                         //reload page with updated list
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("ERROR", "You did not select an event to remove.", "OK");
        }

        // Populates listView from database
        protected override async void OnAppearing() {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetEventsAsync(((Date)BindingContext).SelectedDateTime);
        }
    }
}