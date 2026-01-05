using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    internal class CouponRepository : ICouponRepository
    {
        private readonly AppContext _context;
        public CouponRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Coupon> Change(Coupon coupon)
        {
            _context.Update(coupon);
            await _context.SaveChangesAsync();
            return await Get(coupon.CouponId);
        }

        public async Task Create(Coupon coupon)
        {
            await _context.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int couponId)
        {
            var coupon = await Get(couponId);
            _context.Remove(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task<Coupon> Get(int couponId)
        {
            return await _context.Coupons.Include(c => c.Customer).Include(c => c.GasType).FirstOrDefaultAsync(c => c.CouponId == couponId);
        }

        public List<Coupon> Get(Func<Coupon, bool> func)
        {
            var coupons = _context.Coupons.Include(c => c.GasType).Include(c => c.Customer).Where(func);
            return coupons.ToList();
        }

        public List<Coupon> GetUserCoupons(string userEmail)
        {
            var coupons = Get(c => c.Customer.Email == userEmail);
            return coupons;
        }
    }
}
