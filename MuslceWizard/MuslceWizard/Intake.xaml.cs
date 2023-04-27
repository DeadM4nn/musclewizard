using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuslceWizard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Intake : ContentPage
	{

		public Intake ()
		{
			InitializeComponent ();
            Init_Latest();

        }

		async public void Init_Latest() {
            Biodata latest_data = await App.Database.GetLatestBiodata();
			if (latest_data != null) {
				Protein.Text = latest_data.Protein.ToString() + " grams/day";
                Calorie.Text = latest_data.Calorie.ToString() + " kcal daily";
            }
        }

        private void goUserProfile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserProfile());
        }
    }
}