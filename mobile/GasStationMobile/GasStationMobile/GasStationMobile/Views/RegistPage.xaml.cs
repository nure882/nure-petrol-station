using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using GasStationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasStationMobile.Views
{
    public partial class RegistPage : ContentPage
    {
        public RegistViewModel RegistViewModel { get; set; }

        public RegistPage()
        {
            InitializeComponent();
            RegistViewModel = new RegistViewModel();
            BindingContext = this;
        }

        private async void OnRegistrationClicked(object sender, EventArgs e)
        {
            var _authService = DependencyService.Get<IAuthService>();
            var authResult = await _authService.Registration(RegistViewModel);
        }
    }
}