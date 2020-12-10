using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamForms.Controls;
using FormsControls.Base;

namespace FinalProject
{
    public partial class MainPage : ContentPage, IAnimationPage
    {
        public IPageAnimation PageAnimation { get; } = new PushPageAnimation
        {
            Duration = AnimationDuration.Short,
            Subtype = AnimationSubtype.FromLeft
        };

        public void OnAnimationStarted(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        public void OnAnimationFinished(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

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
            MainTitle.Text = "Today's Date: " + DateTime.Now.ToString().Remove(10);
        }

        public async void NextMonthAnimation(object s, EventArgs args)
        {
            //await calendar.TitleLabel.TranslateTo(-1000, 0, 200);
            //await calendar.TitleLabel.TranslateTo(1000, 0, 1);
            //await calendar.TitleLabel.TranslateTo(0, 0, 200);
            await calendar.TranslateTo(-1000, 0, 200);
            await calendar.TranslateTo(1000, 0, 1);
            await calendar.TranslateTo(0, 0, 200);
        }

        public async void PreviousMonthAnimation(object s, EventArgs args)
        {
            //await calendar.TitleLabel.TranslateTo(1000, 0, 200);
            //await calendar.TitleLabel.TranslateTo(-1000, 0, 1);
            //await calendar.TitleLabel.TranslateTo(0, 0, 200);
            await calendar.TranslateTo(1000, 0, 200);
            await calendar.TranslateTo(-1000, 0, 1);
            await calendar.TranslateTo(0, 0, 200);
        } 
    }
}
