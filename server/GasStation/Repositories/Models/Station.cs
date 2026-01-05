using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public string Description { get; set; }
        public string EquipmentList { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Pump> Pumps { get; set; }
    }
}
