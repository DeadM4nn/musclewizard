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
	public partial class MuscleBack : ContentPage
	{
		public MuscleBack ()
		{
			InitializeComponent ();
		}
        private void NavigateTo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

		private void goBack(object sender, EventArgs e) {
            Navigation.PopAsync(); //Pop the latest async
        }
    }
}