using AutiAssist_MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutiAssist_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class game_menu : ContentPage
    {
        public int userAgeCat;

        public game_menu()
        {
            InitializeComponent();

            // Get user age from main page
            userAgeCat = Preferences.Get("userAgeCat", 1);

            var activity = new Activity
            {
                ageCategory = userAgeCat
            };


        }

        // Select Answer game button
        private void SelectAnswer_Btn(object sender, EventArgs e)
        {

        }

        // Jigsaw Puzzle game button
        private async void JigsawPuzzle_Btn(object sender, EventArgs e)
        {
            if (userAgeCat == 1)
            {
                //Navigation.PushAsync(new puzzle_A01_L01());
                Console.WriteLine("Preferences.Get : " + userAgeCat);
                await Shell.Current.GoToAsync($"{nameof(puzzle_A01_L01)}");
            }

            else if (userAgeCat == 2)
            {
                //Navigation.PushAsync(new puzzle_A01_L02());
                Console.WriteLine("Preferences.Get : " + userAgeCat);
                await Shell.Current.GoToAsync($"{nameof(puzzle_A01_L02)}");
            }

            else if (userAgeCat == 3)
            {
                //Navigation.PushAsync(new puzzle_A01_L03());
                Console.WriteLine("Preferences.Get : " + userAgeCat);
                await Shell.Current.GoToAsync($"{nameof(puzzle_A01_L03)}");
            }

            else
            {

            }
        }
    }
}