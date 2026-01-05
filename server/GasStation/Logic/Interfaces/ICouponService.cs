using Logic.ViewModels;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICouponService
    {
        public Task<Coupon> Get(int couponId);
        public Task Create(Coupon model);
        public Task<Coupon> Change(Coupon model);
        public Task Delete(int couponId);
        public List<Coupon> Get(CouponSearchViewModel model);
        public List<Coupon> GetUserCoupons(string userEmail);
    }
}
