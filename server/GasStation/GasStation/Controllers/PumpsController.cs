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
    [Route("api/pump")]
    [ApiController]
    public class PumpsController : ControllerBase
    {
        private readonly IPumpService _pumpService;
        public PumpsController(IPumpService pumpService)
        {
            _pumpService = pumpService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new JsonResult(await _pumpService.Get(id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] double gasCountFrom, [FromQuery] double gasCountTo, [FromQuery] int number)
        {
            var model = new PumpSearchViewModel() { Number = number, GasCountFrom = gasCountFrom, GasCountTo = gasCountTo};
            return new JsonResult(_pumpService.Get(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PumpViewModel model)
        {
            await _pumpService.Create(model.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Change(PumpChangeViewModel model)
        {
            return new JsonResult(await _pumpService.Change(model.ToModel()));
        }

        [HttpDelete("{pumpId}")]
        public async Task<IActionResult> Delete(int pumpId)
        {
            await _pumpService.Delete(pumpId);
            return Ok();
        }
    }
}
