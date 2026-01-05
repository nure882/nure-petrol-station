using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using GasStationMobile.Services;
using GasStationMobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasStationMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegistrationClicked(object sender, EventArgs e)
        {
            // Перейти на страницу регистрации
            await Navigation.PushAsync(new RegistPage());
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginToAccountPage());
        }
    }
}
