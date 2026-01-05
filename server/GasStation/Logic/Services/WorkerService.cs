using GasStation.ViewModels;
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
    internal class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<Worker> Get(int workerId)
        {
            return await _workerRepository.Get(workerId);
        }

        public List<Worker> Get(WorkerSearchViewModel model)
        {
            return _workerRepository.Get(c =>
            ((string.IsNullOrEmpty(model.Name) || c.Name.Contains(model.Name)) &&
            ((string.IsNullOrEmpty(model.Surname) || c.Surname.Contains(model.Surname)) &&
            ((model.StationId == 0) || c.StationId == model.StationId) &&
            ((string.IsNullOrEmpty(model.Email) || c.Email.Contains(model.Email))))));
        }

        public async Task Update(WorkerChangeViewModel model)
        {
            var worker = await Get(model.UserId);
            await _workerRepository.Update(model.ChangeValues(worker));
        }
    }
}
