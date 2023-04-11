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
    public class DistantMetastasisController : Controller
    {
        private readonly IDistantMetastasisService _distantMetastasisService;
        public DistantMetastasisController(IDistantMetastasisService distantMetastasisService)
        {
            _distantMetastasisService = distantMetastasisService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_distantMetastasisService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_distantMetastasisService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_distantMetastasisService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_distantMetastasisService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(DistantMetastasis distantMetastasis)
        {
            distantMetastasis.CreatedDate = DateTime.Now;
            distantMetastasis.Status = 1;
            return Ok(_distantMetastasisService.Add(distantMetastasis));
        }
        [HttpPost("update")]
        public IActionResult Update(DistantMetastasis distantMetastasis)
        {
            var test = _distantMetastasisService.GetActivesById(distantMetastasis.ID);

            distantMetastasis.ModifiedDate = DateTime.Now;
            distantMetastasis.Status = 2;
            distantMetastasis.CompanyID = test.CompanyID;
            distantMetastasis.CreatedDate = test.CreatedDate;
            return Ok(_distantMetastasisService.Update(distantMetastasis));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DistantMetastasis distantMetastasis)
        {
            var test = _distantMetastasisService.GetActivesById(distantMetastasis.ID);

            distantMetastasis.ModifiedDate = test.ModifiedDate;
            distantMetastasis.Status = 3;
            distantMetastasis.CompanyID = test.CompanyID;
            distantMetastasis.CreatedDate = test.CreatedDate;
            distantMetastasis.DeletedDate = DateTime.Now;
            return Ok(_distantMetastasisService.Delete(distantMetastasis));
        }
    }
}
