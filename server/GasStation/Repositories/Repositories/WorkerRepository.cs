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
    internal class WorkerRepository : IWorkerRepository
    {
        private readonly AppContext _context;

        public WorkerRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Worker> Get(int workerId)
        {
            return await _context.Workers.FirstOrDefaultAsync(c => c.UserId == workerId);
        }

        public List<Worker> Get(Func<Worker, bool> func)
        {
            var workers = _context.Workers.Where(func);
            return workers.ToList();
        }

        public async Task Update(Worker worker)
        {
            _context.Update(worker);
            await _context.SaveChangesAsync();
        }
    }
}
