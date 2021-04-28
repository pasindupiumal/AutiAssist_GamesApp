using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AutiAssist_MobileApp.Models;
using AutiAssist_MobileApp.Services;
using AutiAssist_MobileApp.Views;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AutiAssist_MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username = String.Empty;
        private string password = String.Empty;
        public AsyncCommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(OnLoginClicked);
        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async Task OnLoginClicked()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var AppShellInstance = Shell.Current as AppShell;

                Response response = await UserService.Login(Username, Password);

                if(response == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", "Credential validation error", "OK");
                }
                else
                {
                    if (response.Message.Equals("Login Successful"))
                    {
                        if (response.Data.Equals("Doctor"))
                        {
                            Preferences.Set("user_type", "Doctor");
                        }
                        else
                        {
                            Preferences.Set("user_type", "Patient");
                        }

                        Preferences.Set("username", Username);
                        Password = String.Empty;
                        Username = String.Empty;
                        await Shell.Current.GoToAsync($"//{nameof(main_menu)}");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error!", response.Message, "OK");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Authentication error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                
            }
        }
    }
}
