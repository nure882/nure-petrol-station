using GasStation.ViewModels;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GasStation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel viewModel)
        {
            return new JsonResult(_authService.Login(viewModel.Login, viewModel.Password));
        }

        [HttpPost("reg/customer")]
        public IActionResult CustomerRegister(CustomerRegisterViewModel customer)
        {
            return new JsonResult(_authService.CustomerRegister(customer.ToModel()));
        }

        [HttpPost("reg/worker")]
        public IActionResult WorkerRegister(WorkerRegisterViewModel worker)
        {
            return new JsonResult(_authService.WorkerRegister(worker.ToModel()));
        }

        [HttpPost("reg/admin")]
        public IActionResult AdminRegister(AdminRegisterViewModel admin)
        {
            return new JsonResult(_authService.AdminRegister(admin.ToModel()));
        }

        [HttpPost("setBan/{id}")]
        public async Task<IActionResult> SetBan(int id)
        {
            return new JsonResult(await _authService.SetBan(id));
        }

        [Authorize]
        [HttpPost("checkSignIn")]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
