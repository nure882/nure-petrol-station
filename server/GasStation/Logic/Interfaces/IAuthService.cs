using Logic.Models;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAuthService
    {
        public AuthResult Login(string login, string password);
        public AuthResult CustomerRegister(Customer customer);
        public AuthResult WorkerRegister(Worker worker);
        public AuthResult AdminRegister(Admin admin);
        Task<bool> SetBan(int userId);
    }
}
