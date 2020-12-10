using FormsControls.Base;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject {
    public partial class App : Application {
        static Database database;

        // Holds a reference to the event database for the calendar
        public static Database Database {
            get {
                if (database == null) {
                    database = new Database(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "event.db3"));
                }
                return database;
            }
        }
        public App() {
            InitializeComponent();

            MainPage = new AnimationNavigationPage(new MainPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
