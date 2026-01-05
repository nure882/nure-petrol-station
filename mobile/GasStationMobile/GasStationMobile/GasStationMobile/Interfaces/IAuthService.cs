using GasStationMobile.Models;
using GasStationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Registration(RegistViewModel model);
        Task<AuthResult> Login(LoginViewModel model);
        Task<bool> IsSignIn();
        void Logout();
        User JwtDecode(string token);
    }
}
