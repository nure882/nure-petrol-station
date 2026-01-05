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
    internal class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin> Get(int admimId)
        {
            return await _adminRepository.Get(admimId);
        }

        public List<Admin> Get(AdminSearchViewModel model)
        {
            return _adminRepository.Get(c =>
            ((string.IsNullOrEmpty(model.Name) || c.Name.Contains(model.Name)) &&
            ((model.StationId == 0) || c.StationId == model.StationId) &&
            ((string.IsNullOrEmpty(model.Email) || c.Email.Contains(model.Email)))));
        }

        public async Task Update(AdminChangeViewModel model)
        {
            var worker = await Get(model.UserId);
            await _adminRepository.Update(model.ChangeValues(worker));
        }
    }
}
