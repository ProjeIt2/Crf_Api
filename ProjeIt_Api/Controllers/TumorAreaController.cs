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
    public class TumorAreaController : Controller
    {
        private readonly ITumorAreaService _tumorAreaService;
        public TumorAreaController(ITumorAreaService tumorAreaService)
        {
            _tumorAreaService = tumorAreaService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_tumorAreaService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
         
            return Ok(_tumorAreaService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_tumorAreaService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_tumorAreaService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(TumorArea tumorArea)
        {
            tumorArea.CreatedDate = DateTime.Now;
            tumorArea.Status = 1;
            return Ok(_tumorAreaService.Add(tumorArea));
        }
        [HttpPost("update")]
        public IActionResult Update(TumorArea tumorArea) 
        { 
  
            var test = _tumorAreaService.GetActivesById(tumorArea.ID);

            tumorArea.ModifiedDate = DateTime.Now;
            tumorArea.Status = 2;
            tumorArea.CompanyID = test.CompanyID;
            tumorArea.CreatedDate = test.CreatedDate;
            return Ok(_tumorAreaService.Update(tumorArea));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TumorArea tumorArea)
        {
            var test = _tumorAreaService.GetActivesById(tumorArea.ID);

            tumorArea.ModifiedDate = test.ModifiedDate;
            tumorArea.Status = 3;
            tumorArea.CompanyID = test.CompanyID;
            tumorArea.CreatedDate = test.CreatedDate;
            tumorArea.DeletedDate = DateTime.Now;
            return Ok(_tumorAreaService.Delete(tumorArea));
        }
    }
}
