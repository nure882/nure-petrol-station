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
    public partial class CouponsPage : TabbedPage
    {
        public CouponsPage()
        {
            InitializeComponent();
            LoadCouponsAsync();
        }

        private async void LoadCouponsAsync()
        {
            var _couponService = DependencyService.Get<ICouponService>();
            var _authService = DependencyService.Get<IAuthService>();

            var token = await SecureStorage.GetAsync("jwt_token");

            List<Coupon> coupons = await _couponService.GetUserCoupons(_authService.JwtDecode(token).Email);
            unusedCouponsListView.ItemsSource = coupons.Where(c => c.UseDate.Year == 1);
            usedCouponsListView.ItemsSource = coupons.Where(c => c.UseDate.Year != 1);
        }
    }
}