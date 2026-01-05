using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class CouponChangeViewModel : CouponViewModel
    {
        public int CouponId { get; set; }
        public DateTime UseDate { get; set; }
        public new Coupon ToModel()
        {
            return new Coupon()
            {
                CustomerId = CustomerId,
                GasTypeId = GasTypeId,
                Liters = Liters,
                ExpirationDate = ExpirationDate,
                UseDate = UseDate,
                CouponId = CouponId
            };
        }
    }
}
