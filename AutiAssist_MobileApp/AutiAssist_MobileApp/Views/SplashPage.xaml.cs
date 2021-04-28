using AutiAssist_MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutiAssist_MobileApp.Views
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        SplashViewModel splashViewModel;
        public SplashPage()
        {
            InitializeComponent();
            BindingContext = splashViewModel = new SplashViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await splashViewModel.Authenticate();
        }
    }
}