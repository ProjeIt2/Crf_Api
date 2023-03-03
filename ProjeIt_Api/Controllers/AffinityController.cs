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
    public class AffinityController : Controller
    {
        private readonly IAffinityService _affinityService;
        public AffinityController(IAffinityService affinityService)
        {
            _affinityService = affinityService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_affinityService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            return Ok(_affinityService.GetActives());
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_affinityService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_affinityService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Affinity affinity)
        {
            affinity.CreatedDate = DateTime.Now;
            affinity.Status = 1;
            return Ok(_affinityService.Add(affinity));
        }
        [HttpPost("update")]
        public IActionResult Update(Affinity affinity)
        {
            return Ok(_affinityService.Update(affinity));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Affinity affinity)
        {
            return Ok(_affinityService.Delete(affinity));
        }
    }
}
