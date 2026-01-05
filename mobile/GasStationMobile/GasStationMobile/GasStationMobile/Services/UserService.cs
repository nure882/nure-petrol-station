using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasStationMobile.Services
{
    public class UserService : IUserService
    {
        private IApiService _apiService = DependencyService.Get<IApiService>();

        public async Task<Customer> GetUser(int userId)
        {
            var response = await _apiService.Get($"customer/{userId}").ExecuteAsync<Customer>();
            return response;
        }

        public async Task<Customer> UpdateUser(Customer customer)
        {
            var response = await _apiService.Put($"customer", customer).ExecuteAsync<Customer>();
            return response;
        }
    }
}
