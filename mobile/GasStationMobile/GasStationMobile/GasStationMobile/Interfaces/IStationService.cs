using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.Interfaces
{
    public interface IStationService
    {
        Task<List<Station>> GetStations(string city, string address);
        Task<Station> GetStation(int stationId);
    }
}
