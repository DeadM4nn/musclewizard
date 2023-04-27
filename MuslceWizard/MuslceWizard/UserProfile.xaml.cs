using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuslceWizard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfile : ContentPage
	{
        // Reference for formula https://www.verywellfit.com/basal-metabolic-rate-1229751#:~:text=Revised%20Harris%2DBenedict%20Formula&text=These%20are%20the%20revised%20Harris,)%20%E2%80%93%20(4.33%20x%20age)

        public UserProfile()
		{
			InitializeComponent();
			Gender.SelectedIndex = 0;
			Exercise.SelectedIndex = 0;
            Init_Latest();
        }

        async public void Init_Latest()
        {
            Biodata latest_data = await App.Database.GetLatestBiodata();
            if (latest_data != null)
            {
                Gender.SelectedItem = latest_data.Gender;
                Exercise.SelectedItem = latest_data.Exercise;
                Height.Text = latest_data.Height.ToString();
                Weight.Text= latest_data.Weight.ToString();
                Age.Text = latest_data.Age.ToString();
            }
        }

        public void buttonProcess(object sender, EventArgs e)
		{

            if (string.IsNullOrEmpty(Height.Text) || string.IsNullOrEmpty(Weight.Text) || string.IsNullOrEmpty(Age.Text)) {
                AlertBox.Text = "Age/Height/Weight cannot be left empty!";
			} else {
                AlertBox.Text = "";
                processData();
			}
        }

		public async void processData() {

            string gender = Gender.SelectedItem.ToString();
            string exercise = Exercise.SelectedItem.ToString();
            int height = int.Parse(Height.Text);
            int weight = int.Parse(Weight.Text);
            int age = int.Parse(Age.Text);
            double bmr = 0.00;


            if (gender == "MALE")
            {
                bmr = 88.4 + (13.4 * weight) + (4.8 * height) - (5.7 * age);
            }
            else
            {
                bmr = 447.6 + (9.25 * weight) + (3.1 * height) - (4.3 * age);
            }

            double kcal_factor = 0.00;

            switch (Exercise.SelectedIndex)
            {
                case 0:
                    kcal_factor = 1.2;
                    break;
                case 1:
                    kcal_factor = 1.375;
                    break;
                case 2:
                    kcal_factor = 1.55;
                    break;
                case 3:
                    kcal_factor = 1.725;
                    break;
                case 4:
                    kcal_factor = 1.9;
                    break;
            }

            double protein_intake = 0.00;

            if (age < 3)
            {
                protein_intake = 13.00;
            }
            else if (age >= 4 && age <= 8)
            {
                protein_intake = 19.00;
            }
            else if (age >= 9 && age <= 13)
            {
                protein_intake = 34.00;
            }
            else if (age >= 14 && age <= 18)
            {
                if (gender == "MALE")
                {
                    protein_intake = 52.00;
                }
                else
                {
                    protein_intake = 46.00;
                }
            }
            else if (age >= 19)
            {
                if (gender == "MALE")
                {
                    protein_intake = 56.00;
                }
                else
                {
                    protein_intake = 46.00;
                }
            }
            double kcal_intake = bmr * kcal_factor;
            Console.WriteLine(kcal_intake);


            Biodata new_bio = new Biodata();
            new_bio.Age = age;
            new_bio.Gender = gender;
            new_bio.Height = height;
            new_bio.Exercise = exercise;
            new_bio.Date = DateTime.Now.Date.ToString("dd-MM-yyyy");
            new_bio.Bmr = bmr;
            new_bio.Protein = protein_intake;
            new_bio.Calorie = kcal_intake;

            await App.Database.SaveBiodata(new_bio);

            await Navigation.PushAsync(new Intake());
        }
	}
}