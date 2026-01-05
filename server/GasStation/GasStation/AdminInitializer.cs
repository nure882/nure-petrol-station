using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories;

namespace GasStation
{
    public static class AdminInitializer
    {
        public static void InitAdmins(AppContext appContext)
        {
            var admin = new Admin()
            {
                Name = "MainAdmin",
                Role = "Admin",
                Email = "admin@gmail.com",
                Password = "123456aA_",
            };

            if (appContext.Admins.Any(c => c.Email == admin.Email))
                return;

            appContext.Admins.Add(admin);
            appContext.SaveChanges();
        }
    }
}
