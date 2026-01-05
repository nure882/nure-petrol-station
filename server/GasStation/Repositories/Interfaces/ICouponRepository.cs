using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICouponRepository
    {
        public Task<Coupon> Get(int couponId);
        public List<Coupon> Get(Func<Coupon, bool> func);
        public List<Coupon> GetUserCoupons(string userEmail);
        public Task Create(Coupon coupon);
        public Task<Coupon> Change(Coupon coupon);
        public Task Delete(int couponId);
    }
}
