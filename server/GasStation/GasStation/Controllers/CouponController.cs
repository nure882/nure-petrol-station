using GasStation.ViewModels;
using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new JsonResult(await _couponService.Get(id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string email, [FromQuery] string name)
        {
            var model = new CouponSearchViewModel() { CustomerEmail = email, GasTypeName = name };
            return new JsonResult(_couponService.Get(model));
        }

        [HttpGet("user/{userEmail}")]
        public IActionResult GetUserCoupons(string userEmail)
        {
            var coupons = _couponService.GetUserCoupons(userEmail);
            return new JsonResult(coupons);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponViewModel model)
        {
            await _couponService.Create(model.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Change(CouponChangeViewModel model)
        {
            return new JsonResult(await _couponService.Change(model.ToModel()));
        }

        [HttpDelete("{couponId}")]
        public async Task<IActionResult> Delete(int couponId)
        {
            await _couponService.Delete(couponId);
            return Ok();
        }
    }
}
