using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPumpRepository
    {
        public Task<Pump> Get(int pumpId);
        public List<Pump> Get(Func<Pump, bool> func);
        public Task Create(Pump pump);
        public Task<Pump> Change(Pump pump);
        public Task Delete(int pumpId);
    }
}
