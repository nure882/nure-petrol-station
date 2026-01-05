using Logic.Interfaces;
using Logic.ViewModels;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    internal class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Station> Change(Station model)
        {
            return await _stationRepository.Change(model);
        }

        public async Task Create(Station model)
        {
            await _stationRepository.Create(model);
        }

        public async Task Delete(int stationId)
        {
            await _stationRepository.Delete(stationId);
        }

        public async Task<Station> Get(int stationId)
        {
            return await _stationRepository.Get(stationId);
        }

        public List<Station> Get(StationSearchViewModel model)
        {
            return _stationRepository.Get(st =>
        (string.IsNullOrEmpty(model.City) || st.City.Contains(model.City)) &&
        (string.IsNullOrEmpty(model.Address) || st.Address.Contains(model.Address)));
        }
    }
}
