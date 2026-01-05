using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IGasTypeService
    {
        public Task<GasType> Get(int typeId);
        public Task Create(GasType model);
        public Task<GasType> Change(GasType model);
        public Task Delete(int typeId);
        public List<GasType> Get(GasTypeSearchViewModel model);
    }
}
