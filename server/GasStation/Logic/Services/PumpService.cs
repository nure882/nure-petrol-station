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
    internal class PumpService : IPumpService
    {
        private readonly IPumpRepository _pumpRepository;
        public PumpService(IPumpRepository pumpRepository)
        {
            _pumpRepository = pumpRepository;
        }

        public async Task<Pump> Change(Pump model)
        {
            return await _pumpRepository.Change(model);
        }

        public async Task Create(Pump model)
        {
            await _pumpRepository.Create(model);
        }

        public async Task Delete(int pumpId)
        {
            await _pumpRepository.Delete(pumpId);
        }

        public async Task<Pump> Get(int pumpId)
        {
            return await _pumpRepository.Get(pumpId);
        }

        public List<Pump> Get(PumpSearchViewModel model)
        {
            return _pumpRepository.Get(c =>
        ((model.Number == 0) || c.Number == model.Number) &&
        c.GasCount >= model.GasCountFrom &&
        ((model.GasCountTo == 0) || c.GasCount <= model.GasCountTo));

        }
    }
}
