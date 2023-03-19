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
            int CompanyID=2;
            return Ok(_affinityService.GetActives((int)CompanyID));
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
            var test = _affinityService.GetActivesById(affinity.ID);

            affinity.ModifiedDate = DateTime.Now;
            affinity.Status = 2;
            affinity.CompanyID = test.CompanyID;
            affinity.CreatedDate = test.CreatedDate;
            return Ok(_affinityService.Update(affinity));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Affinity affinity)
        {
            var test = _affinityService.GetActivesById(affinity.ID);

            affinity.ModifiedDate = test.ModifiedDate;
            affinity.Status = 3;
            affinity.CompanyID = test.CompanyID;
            affinity.CreatedDate = test.CreatedDate;
            affinity.DeletedDate = DateTime.Now;
            return Ok(_affinityService.Delete(affinity));
        }
    }
}
