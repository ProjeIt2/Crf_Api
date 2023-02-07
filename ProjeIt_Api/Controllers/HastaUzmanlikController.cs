using Business.Services.Interfeces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HastaUzmanlikController : ControllerBase
    {
        private readonly IHastaUzmanlikService _hastaUzmanlikService;
        public HastaUzmanlikController(IHastaUzmanlikService hastaUzmanlikService)
        {
            _hastaUzmanlikService = hastaUzmanlikService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_hastaUzmanlikService.GetList());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int HastaUzmanlikId)
        {
            return Ok(_hastaUzmanlikService.GetById(HastaUzmanlikId));
        }

        [HttpPost("add")]
        public IActionResult Add(HastaUzmanlik hastaUzmanlik)
        {
            return Ok(_hastaUzmanlikService.Add(hastaUzmanlik));
        }
        [HttpPost("update")]
        public IActionResult Update(HastaUzmanlik hastaUzmanlik)
        {
            return Ok(_hastaUzmanlikService.Update(hastaUzmanlik));
        }
        [HttpPost("delete")]
        public IActionResult Delete(HastaUzmanlik hastaUzmanlik)
        {
            return Ok(_hastaUzmanlikService.Delete(hastaUzmanlik));
        }
    }
}
