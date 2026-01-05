using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAdminRepository
    {
        public Task<Admin> Get(int adminId);
        public List<Admin> Get(Func<Admin, bool> func);
        public Task Update(Admin admin);
    }
}
