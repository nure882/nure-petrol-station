using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Customer : User
    {
        public Customer()
        {
            Role = "Customer";
        }

        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public List<Coupon> Coupons { get; set; }
    }
}
