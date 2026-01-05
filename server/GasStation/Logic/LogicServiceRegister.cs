using Logic.Interfaces;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IPumpService, PumpService>();
            services.AddScoped<IGasTypeService, GasTypeService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IAdminService, AdminService>();
        }
    }
}
