using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using GasStationMobile.ViewModels;
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
    public partial class EditProfilePage : ContentPage
    {
        public Customer Customer { get; set; }
        bool isPasswordVisible = false;
        public EditProfilePage(Customer customer)
        {
            InitializeComponent();
            this.Customer = customer;
            NameEntry.Text = customer.Name;
            SurnameEntry.Text = customer.Surname;
            BirthdayEntry.Date = customer.Birthday;
            PasswordEntry.Text = customer.Password;

        }

        private void ShowPasswordButton_Clicked(object sender, System.EventArgs e)
        {
            // Изменить свойство IsPassword в зависимости от текущего состояния
            PasswordEntry.IsPassword = isPasswordVisible;

            // Изменить текст кнопки в зависимости от текущего состояния
            ShowPasswordButton.Text = isPasswordVisible ? "Show password" : "Hide password";

            isPasswordVisible = !isPasswordVisible;
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            Customer.Name = NameEntry.Text;
            Customer.Surname = SurnameEntry.Text;
            Customer.Birthday = BirthdayEntry.Date;
            Customer.Password = PasswordEntry.Text;
            var _userService = DependencyService.Get<IUserService>();
            await _userService.UpdateUser(this.Customer);
            await Navigation.PushAsync(new MyAccountPage());
        }
    }
}