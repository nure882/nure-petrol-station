using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class RepositoriesServiceRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IPumpRepository, PumpRepository>();
            services.AddScoped<IGasTypeRepository, GasTypeRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }
    }
}
