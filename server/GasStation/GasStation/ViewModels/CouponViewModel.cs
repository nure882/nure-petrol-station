using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class CouponViewModel
    {
        public int? CustomerId { get; set; }
        public int GasTypeId { get; set; }
        public double Liters { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Coupon ToModel()
        {
            return new Coupon()
            {
                CustomerId = CustomerId,
                GasTypeId = GasTypeId,
                Liters = Liters,
                ExpirationDate = ExpirationDate
            };
        }
    }
}
