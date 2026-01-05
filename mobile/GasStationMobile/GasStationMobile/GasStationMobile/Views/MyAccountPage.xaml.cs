using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasStationMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        public Customer Customer { get; set; }
        public MyAccountPage()
        {
            InitializeComponent();
            LoadUserAsync();
        }

        private async void EditProfileButton_Clicked(object sender, EventArgs e)
        {
            // Перейдите на страницу редактирования профиля, например:
            await Navigation.PushAsync(new EditProfilePage(this.Customer));
        }

        private async void LoadUserAsync()
        {
            var _authService = DependencyService.Get<IAuthService>();
            var _userService = DependencyService.Get<IUserService>();

            var token = await SecureStorage.GetAsync("jwt_token");
            Customer user = await _userService.GetUser(_authService.JwtDecode(token).UserId);
            Customer = user;
            BindingContext = Customer;
        }
    }
}