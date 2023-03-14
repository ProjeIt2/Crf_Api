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
    public class MetastasisController : Controller
    {
        private readonly IMetastasisService _metastasisService;
        public MetastasisController(IMetastasisService metastasisService)
        {
            _metastasisService = metastasisService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_metastasisService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_metastasisService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_metastasisService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_metastasisService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Metastasis metastasis)
        {
            metastasis.CreatedDate = DateTime.Now;
            metastasis.Status = 1;
            return Ok(_metastasisService.Add(metastasis));
        }
        [HttpPost("update")]
        public IActionResult Update(Metastasis metastasis)
        {
            return Ok(_metastasisService.Update(metastasis));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Metastasis metastasis)
        {
            return Ok(_metastasisService.Delete(metastasis));
        }
    }
}
