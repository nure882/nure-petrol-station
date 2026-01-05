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
    internal class GasTypeRepository : IGasTypeRepository
    {
        private readonly AppContext _context;
        public GasTypeRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<GasType> Change(GasType type)
        {
            _context.Update(type);
            await _context.SaveChangesAsync();
            return await Get(type.GasTypeId);
        }

        public async Task Create(GasType type)
        {
            await _context.AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int typeId)
        {
            var type = await Get(typeId);
            _context.Remove(type);
            await _context.SaveChangesAsync();
        }

        public async Task<GasType> Get(int typeId)
        {
            return await _context.GasTypes.FirstOrDefaultAsync(c => c.GasTypeId == typeId);
        }

        public List<GasType> Get(Func<GasType, bool> func)
        {
            var types = _context.GasTypes.Where(func);
            return types.ToList();
        }
    }
}
