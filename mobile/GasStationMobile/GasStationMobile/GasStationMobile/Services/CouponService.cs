using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasStationMobile.Services
{
    public class CouponService : ICouponService
    {
        private IApiService _apiService = DependencyService.Get<IApiService>();

        public async Task<List<Coupon>> GetUserCoupons(string userEmail)
        {
            var response = await _apiService.Get($"coupon/user/{userEmail}").ExecuteAsync<List<Coupon>>();
            return response;
        }
    }
}
