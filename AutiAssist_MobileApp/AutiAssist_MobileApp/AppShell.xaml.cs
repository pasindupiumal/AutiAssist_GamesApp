using AutiAssist_MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutiAssist_MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(game_menu), typeof(game_menu));
            Routing.RegisterRoute(nameof(puzzle_A01_L01), typeof(puzzle_A01_L01));
            Routing.RegisterRoute(nameof(puzzle_A01_L02), typeof(puzzle_A01_L02));
            Routing.RegisterRoute(nameof(puzzle_A01_L03), typeof(puzzle_A01_L03));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            Preferences.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
