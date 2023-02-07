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
    public class TüpCinsController : ControllerBase
    {
        private readonly ITüpCinsService _tüpCinsService;
        public TüpCinsController(ITüpCinsService rolService)
        {
            _tüpCinsService = rolService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_tüpCinsService.GetList());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int TüpCinsId)
        {
            return Ok(_tüpCinsService.GetById(TüpCinsId));
        }

        [HttpPost("add")]
        public IActionResult Add(TüpCins tüpCins)
        {
            return Ok(_tüpCinsService.Add(tüpCins));
        }
        [HttpPost("update")]
        public IActionResult Update(TüpCins tüpCins)
        {
            return Ok(_tüpCinsService.Update(tüpCins));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TüpCins tüpCins)
        {
            return Ok(_tüpCinsService.Delete(tüpCins));
        }
    }
}
