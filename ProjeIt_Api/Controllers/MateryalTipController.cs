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
    public class MateryalTipController : ControllerBase
    {
        private readonly IMateryalTipService _materyalTipService;
        public MateryalTipController(IMateryalTipService materyalTipService)
        {
            _materyalTipService = materyalTipService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_materyalTipService.GetList());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int MateryalTipId)
        {
            return Ok(_materyalTipService.GetById(MateryalTipId));
        }

        [HttpPost("add")]
        public IActionResult Add(MateryalTip materyalTip)
        {
            return Ok(_materyalTipService.Add(materyalTip));
        }
        [HttpPost("update")]
        public IActionResult Update(MateryalTip materyalTip)
        {
            return Ok(_materyalTipService.Update(materyalTip));
        }
        [HttpPost("delete")]
        public IActionResult Delete(MateryalTip materyalTip)
        {
            return Ok(_materyalTipService.Delete(materyalTip));
        }
    }
}
