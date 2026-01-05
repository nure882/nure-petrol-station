using GasStationMobile.Interfaces;
using GasStationMobile.Views;
using Jose;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasStationMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeAppAsync();

            Startup.Init();

            MainPage = new NavigationPage(new MainPage());
        }

        private async void InitializeAppAsync()
        {
            IAuthService authService = DependencyService.Get<IAuthService>();

            bool isAuth = await authService.IsSignIn();

            if (isAuth)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
