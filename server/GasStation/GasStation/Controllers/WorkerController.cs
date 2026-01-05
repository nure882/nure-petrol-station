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
    [Route("api/worker")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string email, [FromQuery] string name, [FromQuery] string surname, [FromQuery] int stationId)
        {
            var model = new WorkerSearchViewModel() { Name = name, Surname = surname, Email = email, StationId = stationId};
            return new JsonResult(_workerService.Get(model));
        }

        [HttpGet("{workerId}")]
        public async Task<IActionResult> Get(int workerId)
        {
            return new JsonResult(await _workerService.Get(workerId));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WorkerChangeViewModel model)
        {
            await _workerService.Update(model);
            return Ok();
        }
    }
}
