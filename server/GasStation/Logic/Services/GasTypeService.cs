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
    internal class GasTypeService : IGasTypeService
    {
        private readonly IGasTypeRepository _gasTypeRepository;
        public GasTypeService(IGasTypeRepository gasTypeRepository)
        {
            _gasTypeRepository = gasTypeRepository;
        }

        public async Task<GasType> Change(GasType model)
        {
            return await _gasTypeRepository.Change(model);
        }

        public async Task Create(GasType model)
        {
            await _gasTypeRepository.Create(model);
        }

        public async Task Delete(int typeId)
        {
            await _gasTypeRepository.Delete(typeId);
        }

        public async Task<GasType> Get(int typeId)
        {
            return await _gasTypeRepository.Get(typeId);
        }

        public List<GasType> Get(GasTypeSearchViewModel model)
        {
            return _gasTypeRepository.Get(c => (string.IsNullOrEmpty(model.Name) || c.Name.Contains(model.Name)));
        }
    }
}
