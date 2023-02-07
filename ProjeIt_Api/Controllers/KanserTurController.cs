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
    public class KanserTurController : ControllerBase
    {
        private readonly IKanserTurService _kanserTurService;
        public KanserTurController(IKanserTurService kanserTurService)
        {
            _kanserTurService = kanserTurService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_kanserTurService.GetList());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int KanserTurId)
        {
            return Ok(_kanserTurService.GetById(KanserTurId));
        }

        [HttpPost("add")]
        public IActionResult Add(KanserTur kanserTur)
        {
            return Ok(_kanserTurService.Add(kanserTur));
        }
        [HttpPost("update")]
        public IActionResult Update(KanserTur kanserTur)
        {
            return Ok(_kanserTurService.Update(kanserTur));
        }
        [HttpPost("delete")]
        public IActionResult Delete(KanserTur kanserTur)
        {
            return Ok(_kanserTurService.Delete(kanserTur));
        }
    }
}
