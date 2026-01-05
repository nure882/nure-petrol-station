using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAdminService
    {
        public Task<Admin> Get(int admimId);
        public List<Admin> Get(AdminSearchViewModel model);
        public Task Update(AdminChangeViewModel model);
    }
}
