using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuslceWizard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseList : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ExerciseList()
        {
            InitializeComponent();

            InitExercise();
        }

        public ExerciseList(string keyword)
        {
            InitializeComponent();

            InitExercise(keyword);
        }


        async public void InitExercise()
        {
            MyListView.ItemsSource = await App.Database.GetExerciseList();
        }

        async public void InitExercise(string keyword)
        {
            MyListView.ItemsSource = await App.Database.GetExerciseList(keyword);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new ExerciseView());
        }
    }
}

