using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MuslceWizard
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");

            if (File.Exists(dbPath))
            {
                Debug.Text = "Database Exist! : "+ App.Database.GetLatestBiodata();
            }
            else
            {
                Debug.Text = "File Missing";
            }

           
        }
        private void goBackside(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MuscleBack());
        }
        private void goUserProfile(object sender, EventArgs e) {
            Navigation.PushAsync(new UserProfile());
        }
    }
}
