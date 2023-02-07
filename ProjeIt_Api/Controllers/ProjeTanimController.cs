using Business.Services.Interfeces;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjeTanimController : ControllerBase
    {
        private readonly IProjeTanimService _projeTanimService;

        public IEnumerable<ProjeTanimDto> ProjeTanimDto { get; private set; }

        public ProjeTanimController(IProjeTanimService rolService)
        {
            _projeTanimService = rolService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_projeTanimService.GetList());
        }
        [HttpGet("GetListProje")]
        public IActionResult GetListProje()
        {

            return Ok(_projeTanimService.GetListProje());

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ProjeTanimId)
        {
            return Ok(_projeTanimService.GetById(ProjeTanimId));
        }

        [HttpPost("add")]
        public IActionResult Add(ProjeTanim projeTanim)
        {
            return Ok(_projeTanimService.Add(projeTanim));
        }
        [HttpPost("update")]
        public IActionResult Update(ProjeTanim projeTanim)
        {
            return Ok(_projeTanimService.Update(projeTanim));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProjeTanim projeTanim)
        {
            return Ok(_projeTanimService.Delete(projeTanim));
        }
        [HttpGet("GetExcelDisaAktar")]
        public IActionResult GetExcelDisaAktar()
        {
            return Ok(_projeTanimService.GetListProje());

        }
    }
}
