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
    internal class PumpRepository : IPumpRepository
    {
        private readonly AppContext _context;
        public PumpRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Pump> Change(Pump pump)
        {
            _context.Update(pump);
            await _context.SaveChangesAsync();
            return await Get(pump.PumpId);
        }

        public async Task Create(Pump pump)
        {
            await _context.AddAsync(pump);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int pumpId)
        {
            var pump = await Get(pumpId);
            _context.Remove(pump);
            await _context.SaveChangesAsync();
        }

        public async Task<Pump> Get(int pumpId)
        {
            return await _context.Pumps.Include(c => c.GasType).FirstOrDefaultAsync(c => c.PumpId == pumpId);
        }

        public List<Pump> Get(Func<Pump, bool> func)
        {
            var pumps = _context.Pumps.Where(func);
            return pumps.ToList();
        }
    }
}
