using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string email, [FromQuery] string name, [FromQuery] string surname)
        {
            var model = new CustomerSearchViewModel() { Name = name, Surname = surname, Email = email};
            return new JsonResult(_customerService.Get(model));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(int customerId)
        {
            return new JsonResult(await _customerService.Get(customerId));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            return new JsonResult(await _customerService.Update(customer));
        }
    }
}
