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
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_treatmentService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_treatmentService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_treatmentService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_treatmentService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Treatment treatment)
        {
            treatment.CreatedDate = DateTime.Now;
            treatment.Status = 1;
            return Ok(_treatmentService.Add(treatment));
        }
        [HttpPost("update")]
        public IActionResult Update(Treatment treatment) 
        {
            var test = _treatmentService.GetActivesById(treatment.ID);

            treatment.ModifiedDate = DateTime.Now;
            treatment.Status = 2;
            treatment.CompanyID = test.CompanyID;
            treatment.CreatedDate = test.CreatedDate;
            return Ok(_treatmentService.Update(treatment));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Treatment treatment)
        {
            var test = _treatmentService.GetActivesById(treatment.ID);

            treatment.ModifiedDate = test.ModifiedDate;
            treatment.Status = 3;
            treatment.CompanyID = test.CompanyID;
            treatment.CreatedDate = test.CreatedDate;
            treatment.DeletedDate = DateTime.Now;
            return Ok(_treatmentService.Delete(treatment));
        }
    }
}
