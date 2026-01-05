using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IStationService
    {
        public Task<Station> Get(int stationId);
        public Task Create(Station model);
        public Task<Station> Change(Station model);
        public Task Delete(int stationId);
        public List<Station> Get(StationSearchViewModel model);
    }
}
