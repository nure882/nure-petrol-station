using GasStationMobile.Interfaces;
using GasStationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasStationMobile.Views
{
    public partial class LoginToAccountPage : ContentPage
    {
        public LoginViewModel LoginViewModel { get; set; }

        public LoginToAccountPage()
        {
            InitializeComponent();
            LoginViewModel = new LoginViewModel();
            BindingContext = this;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var _authService = DependencyService.Get<IAuthService>();
            var authResult = await _authService.Login(LoginViewModel);
            if (authResult.Successed)
            {
                var token = authResult.JwtToken;
                await SecureStorage.SetAsync("jwt_token", token);
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}