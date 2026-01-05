using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStationRepository
    {
        public Task<Station> Get(int stationId);
        public List<Station> Get(Func<Station, bool> func);
        public Task Create(Station station);
        public Task<Station> Change(Station station);
        public Task Delete(int stationId);
    }
}
