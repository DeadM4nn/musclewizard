﻿using System;
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
		}

		public void buttonProcess(object sender, EventArgs e)
		{
			string gender = Gender.SelectedItem.ToString();
			string exercise = Exercise.SelectedItem.ToString();
			int height = int.Parse(Height.Text);
			int weight = int.Parse(Weight.Text);
			int age = int.Parse(Age.Text);
			double bmr = 0.00;


			if (gender == "MALE")
			{
				bmr = 88.4 + (13.4 * weight) +(4.8 * height) -(5.7 * age);
			}
			else 
			{
                bmr = 447.6 + (9.25 * weight) +(3.1 * height) -(4.3 * age);
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

			if (age < 3) {
				protein_intake = 13.00;
			} else if (age >= 4 && age <= 8) {
				protein_intake = 19.00;
			} else if (age >= 9 && age <= 13) {
				protein_intake = 34.00;
			} else if (age >= 14 && age <= 18) {
				if (gender == "MALE")
				{
					protein_intake = 52.00;
				}
				else
				{
					protein_intake = 46.00;
				}
			} else if (age >= 19) {
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
            SaveButton.Text = kcal_intake.ToString() + " Kcal & " + protein_intake.ToString() + " grams/day";

        }
	}
}