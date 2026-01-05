using Logic.Interfaces;
using Logic.Models;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService (IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public AuthResult Login(string login, string password)
        {
            if (!_userRepository.CanLogin(login, password))
            {
                var res = new AuthResult(false);
                res.SetErrorString("Your account has been banned / password or email entered incorectly");
                return res;
            }

            var token = _jwtService.CreateToken(_userRepository.GetUser(login));
            return new AuthResult(true, token);
        }

        public AuthResult AdminRegister(Admin admin)
        {
            if (!_userRepository.EmailIsUnique(admin.Email))
            {
                var res = new AuthResult(false);
                res.SetErrorString("this email is already taken");
                return res;
            }

            _userRepository.AddUser(admin);

            var token = _jwtService.CreateToken(_userRepository.GetUser(admin.Email));
            return new AuthResult(true, token);
        }

        public AuthResult CustomerRegister(Customer customer)
        {
            if (!_userRepository.EmailIsUnique(customer.Email))
            {
                var res = new AuthResult(false);
                res.SetErrorString("this email is already taken");
                return res;
            }

            _userRepository.AddUser(customer);

            var token = _jwtService.CreateToken(_userRepository.GetUser(customer.Email));
            return new AuthResult(true, token);
        }

        public AuthResult WorkerRegister(Worker worker)
        {
            if (!_userRepository.EmailIsUnique(worker.Email))
            {
                var res = new AuthResult(false);
                res.SetErrorString("this email is already taken");
                return res;
            }

            _userRepository.AddUser(worker);

            var token = _jwtService.CreateToken(_userRepository.GetUser(worker.Email));
            return new AuthResult(true, token);
        }

        public async Task<bool> SetBan(int userId)
        {
            return await _userRepository.SetBan(userId);
        }
    }
}
