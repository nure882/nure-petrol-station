using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IGasTypeRepository
    {
        public Task<GasType> Get(int typeId);
        public List<GasType> Get(Func<GasType, bool> func);
        public Task Create(GasType type);
        public Task<GasType> Change(GasType type);
        public Task Delete(int typeId);
    }
}
