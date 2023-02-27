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
    public class SocialLifeController : ControllerBase
    {
        private readonly ISocialLifeService _socialLifeService;
        public SocialLifeController(ISocialLifeService socialLifeService)
        {
            _socialLifeService = socialLifeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_socialLifeService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_socialLifeService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_socialLifeService.GetById(ID));
        }
        [HttpGet("GetByFormId")]
        public IActionResult GetByFormId(int ID)
        {
            return Ok(_socialLifeService.GetByFormId(ID));
        }
        [HttpPost("add")]
        public IActionResult Add(SocialLife socialLife)
        {
            socialLife.CreatedDate = DateTime.Now;
            socialLife.Status = 1;
            return Ok(_socialLifeService.Add(socialLife));
        }
        [HttpPost("update")]
        public IActionResult Update(SocialLife socialLife)
        {
            return Ok(_socialLifeService.Update(socialLife));
        }
        [HttpPost("delete")]
        public IActionResult Delete(SocialLife socialLife)
        {
            return Ok(_socialLifeService.Delete(socialLife));
        }
    }
}
