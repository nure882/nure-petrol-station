using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasStationMobile.Services
{
    internal class StationService : IStationService
    {
        private IApiService _apiService = DependencyService.Get<IApiService>();

        public async Task<Station> GetStation(int stationId)
        {
            var response = await _apiService.Get($"station/{stationId}").ExecuteAsync<Station>();
            return response;
        }

        public async Task<List<Station>> GetStations(string city, string address)
        {
            var response = await _apiService.Get($"station?city={city}&address={address}").ExecuteAsync<List<Station>>();
            return response;
        }
    }
}
