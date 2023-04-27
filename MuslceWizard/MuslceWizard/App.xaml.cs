using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace MuslceWizard
{
    public partial class App : Application
    {
        private static Database database_connection;

        public static Database Database
        {
            get {
                if (database_connection == null) {
                    database_connection = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                } 
                return database_connection;

            }
        }


        public App()
        {
            Console.WriteLine("Over Here! 32:");
            Console.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MuscleBackPage = new NavigationPage(new MuscleBack());
            Database.InitExercise();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
