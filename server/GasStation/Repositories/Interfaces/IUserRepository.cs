using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool CanLogin(string email, string password);
        User GetUser(string login);
        bool EmailIsUnique(string email);
        void AddUser(User user);
        Task<bool> SetBan(int userId);
    }
}
