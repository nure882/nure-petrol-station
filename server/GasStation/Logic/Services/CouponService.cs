using Logic.Interfaces;
using Logic.ViewModels;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    internal class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<Coupon> Change(Coupon model)
        {
            return await _couponRepository.Change(model);
        }

        public async Task Create(Coupon model)
        {
            await _couponRepository.Create(model);
        }

        public async Task Delete(int couponId)
        {
            await _couponRepository.Delete(couponId);
        }

        public async Task<Coupon> Get(int couponId)
        {
            return await _couponRepository.Get(couponId);
        }

        public List<Coupon> Get(CouponSearchViewModel model)
        {
            return _couponRepository.Get(c =>
            ((string.IsNullOrEmpty(model.GasTypeName) || c.GasType.Name.Contains(model.GasTypeName)) &&
            ((string.IsNullOrEmpty(model.CustomerEmail) || c.Customer.Email.Contains(model.CustomerEmail)))));
        }

        public List<Coupon> GetUserCoupons(string userEmail)
        {
            return _couponRepository.GetUserCoupons(userEmail);
        }
    }
}
