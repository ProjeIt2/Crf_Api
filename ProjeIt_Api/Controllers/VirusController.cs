using Business.Services.Interfeces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VirusController : Controller
    {
        private readonly IVirusService _virusService;
        public VirusController(IVirusService virusService)
        {
            _virusService = virusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_virusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_virusService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_virusService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_virusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Virus virus)
        {
            virus.CreatedDate = DateTime.Now;
            virus.Status = 1;
            return Ok(_virusService.Add(virus));
        }
        [HttpPost("update")]
        public IActionResult Update(Virus virus)
        {
            return Ok(_virusService.Update(virus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Virus virus)
        {
            return Ok(_virusService.Delete(virus));
        }
    }
}
