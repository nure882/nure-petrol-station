using GasStationMobile.Interfaces;
using GasStationMobile.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GasStationMobile
{
    public static class DIContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStationService, StationService>();
            return services;
        }
    }
}
