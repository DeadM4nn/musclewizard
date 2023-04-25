using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }
        private void NavigateTo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MuscleBack());
        }
    }
}
