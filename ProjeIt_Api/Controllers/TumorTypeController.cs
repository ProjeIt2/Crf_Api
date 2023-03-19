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
    public class TumorTypeController : Controller
    {
        private readonly ITumorTypeService _tumorTypeService;
        public TumorTypeController(ITumorTypeService tumorTypeService)
        {
            _tumorTypeService = tumorTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_tumorTypeService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_tumorTypeService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_tumorTypeService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_tumorTypeService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(TumorType tumorType)
        {
            tumorType.CreatedDate = DateTime.Now;
            tumorType.Status = 1;
            return Ok(_tumorTypeService.Add(tumorType));
        }
        [HttpPost("update")]
        public IActionResult Update(TumorType tumorType)
        {
            var test = _tumorTypeService.GetActivesById(tumorType.ID);

            tumorType.ModifiedDate = DateTime.Now;
            tumorType.Status = 2;
            tumorType.CompanyID = test.CompanyID;
            tumorType.CreatedDate = test.CreatedDate;
            return Ok(_tumorTypeService.Update(tumorType));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TumorType tumorType)
        {
            var test = _tumorTypeService.GetActivesById(tumorType.ID);

            tumorType.ModifiedDate = test.ModifiedDate;
            tumorType.Status = 3;
            tumorType.CompanyID = test.CompanyID;
            tumorType.CreatedDate = test.CreatedDate;
            tumorType.DeletedDate = DateTime.Now;
            return Ok(_tumorTypeService.Delete(tumorType));
        }
    }
}
