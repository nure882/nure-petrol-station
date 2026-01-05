using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Worker : User
    {
        public Worker()
        {
            Role = "Worker";
        }

        public string Surname { get; set; }
        public Station Station { get; set; }
        public int? StationId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
