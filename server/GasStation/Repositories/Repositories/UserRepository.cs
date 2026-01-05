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
    internal class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        public bool CanLogin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(c => c.Email == email);

            return user is not null && user.Password == password && !user.IsBanned;
        }

        public User GetUser(string login)
        {
            return _context.Users.FirstOrDefault(c => c.Email == login);
        }

        public bool EmailIsUnique(string email)
        {
            return !_context.Users.Any(c => c.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<bool> SetBan(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == userId);
            user.IsBanned = !user.IsBanned;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user.IsBanned;
        }
    }
}
