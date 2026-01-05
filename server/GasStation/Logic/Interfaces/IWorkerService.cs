using GasStation.ViewModels;
using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IWorkerService
    {
        public Task<Worker> Get(int workerId);
        public List<Worker> Get(WorkerSearchViewModel model);
        public Task Update(WorkerChangeViewModel model);
    }
}
