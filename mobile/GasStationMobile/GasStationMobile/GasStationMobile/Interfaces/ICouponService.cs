using GasStationMobile.Models;
using GasStationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.Interfaces
{
    public interface ICouponService
    {
        Task<List<Coupon>> GetUserCoupons(string userEmail);
    }
}
