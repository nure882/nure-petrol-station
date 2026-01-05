using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    internal class StationRepository : IStationRepository
    {
        private readonly AppContext _context;
        public StationRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Station> Change(Station station)
        {
            _context.Update(station);
            await _context.SaveChangesAsync();
            return await Get(station.StationId);
        }

        public async Task Create(Station station)
        {
            await _context.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int stationId)
        {
            var station = await Get(stationId);
            _context.Remove(station);
            await _context.SaveChangesAsync();
        }

        public async Task<Station> Get(int stationId)
        {
            return await _context.Stations
                .Include(c => c.Admins)
                .Include(c => c.Workers)
                .Include(c => c.Pumps)
                .ThenInclude(c => c.GasType)
                .FirstOrDefaultAsync(s => s.StationId == stationId);
        }

        public List<Station> Get(Func<Station, bool> func)
        {
            var stations = _context.Stations.Where(func);
            return stations.ToList();
        }
    }
}
