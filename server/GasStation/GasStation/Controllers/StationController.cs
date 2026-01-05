using GasStation.ViewModels;
using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GasStation.Controllers
{
    [Route("api/station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new JsonResult(await _stationService.Get(id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string city, [FromQuery] string address)
        {
            var model = new StationSearchViewModel() { City = city, Address = address };
            return new JsonResult(_stationService.Get(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StationViewModel model)
        {
            await _stationService.Create(model.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Change(StationChangeViewModel model)
        {
            return new JsonResult(await _stationService.Change(model.ToModel()));
        }

        [HttpDelete("{stationId}")]
        public async Task<IActionResult> Delete(int stationId)
        {
            await _stationService.Delete(stationId);
            return Ok();
        }
    }
}
