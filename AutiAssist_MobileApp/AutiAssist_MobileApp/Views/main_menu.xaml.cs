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
    public partial class main_menu : ContentPage
    {
        public int userAgeCat;

        public main_menu()
        {
            InitializeComponent();
        }

        private async void age_submit_button(object sender, EventArgs e)
        {
            int userAge = 0;

            // Store user input (AGE) as a number
            // Identify Decimal points ()
            if (ageEntry.Text.Contains("."))
            {
                await DisplayAlert("ERROR!", "Please Enter Valid Age", "Enter");
                ageEntry.Text = "";
            }
            else
            {
                userAge = int.Parse(ageEntry.Text);
                Console.WriteLine(userAge);

                // Check user inputed age and do relavent operations
                if (userAge <= 0 || userAge >= 100)
                {
                    await DisplayAlert("Warning!", "Please Enter Your Age", "Enter", "Cancel");
                }

                else if (userAge >= 1 && userAge <= 5)
                {
                    // Save user age to access other pages
                    userAgeCat = 1;
                    Preferences.Set("userAgeCat", userAgeCat);

                    // Go to main menu page
                    await Shell.Current.GoToAsync($"{nameof(game_menu)}");
                }

                else if (userAge >= 6 && userAge <= 10)
                {
                    // Save user age to access other pages
                    userAgeCat = 2;
                    Preferences.Set("userAgeCat", userAgeCat);

                    // Go to mainmanu page
                    await Shell.Current.GoToAsync($"{nameof(game_menu)}");
                }

                else if (userAge >= 11)
                {
                    // Save user age to access other pages
                    userAgeCat = 3;
                    Preferences.Set("userAgeCat", userAgeCat);

                    // Go to mainmanu page
                    await Shell.Current.GoToAsync($"{nameof(game_menu)}");
                }
            }
        }
    }
}