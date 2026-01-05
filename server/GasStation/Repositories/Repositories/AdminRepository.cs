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
    internal class AdminRepository : IAdminRepository
    {
        private readonly AppContext _context;

        public AdminRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Admin> Get(int adminId)
        {
            return await _context.Admins.FirstOrDefaultAsync(c => c.UserId == adminId);
        }

        public List<Admin> Get(Func<Admin, bool> func)
        {
            var admins = _context.Admins.Where(func);
            return admins.ToList();
        }

        public async Task Update(Admin admin)
        {
            _context.Update(admin);
            await _context.SaveChangesAsync();
        }
    }
}
