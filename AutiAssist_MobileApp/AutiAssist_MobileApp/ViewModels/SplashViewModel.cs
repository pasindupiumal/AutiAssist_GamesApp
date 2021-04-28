using AutiAssist_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutiAssist_MobileApp.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public async Task Authenticate()
        {
            string number = "1";

            if (int.Parse(number) == 1)
            {
                IsBusy = true;
                await Task.Delay(500);
                IsBusy = false;

                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }

        }
    }
}
