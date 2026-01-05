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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string email, [FromQuery] string name, [FromQuery] int stationId)
        {
            var model = new AdminSearchViewModel() { Name = name, Email = email, StationId = stationId };
            return new JsonResult(_adminService.Get(model));
        }

        [HttpGet("{adminId}")]
        public async Task<IActionResult> Get(int adminId)
        {
            return new JsonResult(await _adminService.Get(adminId));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdminChangeViewModel model)
        {
            await _adminService.Update(model);
            return Ok();
        }
    }
}
