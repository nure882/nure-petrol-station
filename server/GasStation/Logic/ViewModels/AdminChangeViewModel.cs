using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModels
{
    public class AdminChangeViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int StationId { get; set; }

        public Admin ChangeValues(Admin admin)
        {
            admin.Name = Name;
            admin.Password = Password;
            admin.StationId = StationId;
            return admin;
        }
    }
}
