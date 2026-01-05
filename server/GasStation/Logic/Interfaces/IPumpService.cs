using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IPumpService
    {
        public Task<Pump> Get(int pumpId);
        public Task Create(Pump model);
        public Task<Pump> Change(Pump model);
        public Task Delete(int pumpId);
        public List<Pump> Get(PumpSearchViewModel model);
    }
}
