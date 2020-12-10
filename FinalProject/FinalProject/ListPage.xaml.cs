using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsControls.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage, IAnimationPage {

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

        public  ListPage() {
            InitializeComponent();
            //listAnmation();
        }

        public async void listAnmation()
        {
            await stacklayout.TranslateTo(0, 1000, 1);
            await stacklayout.TranslateTo(0, 0, 350);
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

                listView.ItemsSource = await App.Database.GetEventsAsync(((Date)BindingContext).SelectedDateTime);//reaload list after deletion.
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