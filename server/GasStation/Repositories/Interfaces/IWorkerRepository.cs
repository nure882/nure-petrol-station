using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        public Task<Worker> Get(int workerId);
        public List<Worker> Get(Func<Worker, bool> func);
        public Task Update(Worker worker);
    }
}
