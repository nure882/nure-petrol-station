using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Admin : User
    {
        public Admin()
        {
            Role = "Admin";
        }

        public Station Station { get; set; }

        [ForeignKey("Station")]
        public int? StationId { get; set; }
    }
}
