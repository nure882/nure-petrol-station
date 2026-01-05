using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using GasStationMobile.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GasStationMobile.Services
{
    public class AuthService : IAuthService
    {
        private IApiService _apiService = DependencyService.Get<IApiService>();

        public async Task<bool> IsSignIn()
        {
            return await _apiService.Post("auth/checkSignIn").IsSuccessed();
        }

        public User JwtDecode(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKeyPassword")),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            SecurityToken securityToken = tokenHandler.ReadToken(token);
            if (securityToken is JwtSecurityToken jwtSecurityToken)
            {
                var claims = jwtSecurityToken.Claims;

                Customer user = new Customer
                {
                    Role = claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value,
                    Name = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                    Email = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
                    UserId = Convert.ToInt32(claims.FirstOrDefault(c => c.Type == "UserId")?.Value)
                };

                return user;
            } else
            {
                throw new Exception();
            }
        }

        public async Task<AuthResult> Login(LoginViewModel model)
        {
            var response = await _apiService.Post("auth/login", model).ExecuteAsync<AuthResult>();
            return response;
        }

        public void Logout()
        {
            SecureStorage.Remove("jwt_token");
        }

        public async Task<AuthResult> Registration(RegistViewModel model)
        {
            var response = await _apiService.Post("auth/reg/customer", model.ToModel()).ExecuteAsync<AuthResult>();
            return response;
        }
    }
}
