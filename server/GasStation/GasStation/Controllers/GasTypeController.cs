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
    [Route("api/gasType")]
    [ApiController]
    public class GasTypeController : ControllerBase
    {
        private readonly IGasTypeService _gasTypeService;
        public GasTypeController(IGasTypeService gasTypeService)
        {
            _gasTypeService = gasTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new JsonResult(await _gasTypeService.Get(id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string name)
        {
            var model = new GasTypeSearchViewModel() { Name = name };
            return new JsonResult(_gasTypeService.Get(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create(GasTypeViewModel model)
        {
            await _gasTypeService.Create(model.ToModel());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Change(GasTypeChangeViewModel model)
        {
            return new JsonResult(await _gasTypeService.Change(model.ToModel()));
        }

        [HttpDelete("{typeId}")]
        public async Task<IActionResult> Delete(int typeId)
        {
            await _gasTypeService.Delete(typeId);
            return Ok();
        }
    }
}
