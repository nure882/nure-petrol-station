using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public GasType GasType { get; set; }
        public int GasTypeId { get; set; }
        public double Liters { get; set; }
        public DateTime UseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
