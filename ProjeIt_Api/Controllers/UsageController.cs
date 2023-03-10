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
    public class UsageController : Controller
    {
        private readonly IUsageService _usageService;
        public UsageController(IUsageService usageService)
        {
            _usageService = usageService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_usageService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_usageService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_usageService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_usageService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Usage usage)
        {
            usage.CreatedDate = DateTime.Now;
            usage.Status = 1;
            return Ok(_usageService.Add(usage));
        }
        [HttpPost("update")]
        public IActionResult Update(Usage usage)
        {
            return Ok(_usageService.Update(usage));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Usage usage)
        {
            return Ok(_usageService.Delete(usage));
        }
    }
}
