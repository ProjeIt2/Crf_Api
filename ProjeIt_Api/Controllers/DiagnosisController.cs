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
    public class DiagnosisController : Controller
    {
        private readonly IDiagnosisService _diagnosisService;
        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_diagnosisService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            return Ok(_diagnosisService.GetActives());
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_diagnosisService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_diagnosisService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Diagnosis diagnosis)
        {
            diagnosis.CreatedDate = DateTime.Now;
            diagnosis.Status = 1;
            return Ok(_diagnosisService.Add(diagnosis));
        }
        [HttpPost("update")]
        public IActionResult Update(Diagnosis diagnosis)
        {
            var test = _diagnosisService.GetActivesById(diagnosis.ID);

            diagnosis.ModifiedDate = DateTime.Now;
            diagnosis.Status = 2;
            diagnosis.CompanyID = test.CompanyID;
            diagnosis.CreatedDate = test.CreatedDate;
            return Ok(_diagnosisService.Update(diagnosis));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Diagnosis diagnosis)
        {
            var test = _diagnosisService.GetActivesById(diagnosis.ID);

            diagnosis.ModifiedDate = test.ModifiedDate;
            diagnosis.Status = 3;
            diagnosis.CompanyID = test.CompanyID;
            diagnosis.CreatedDate = test.CreatedDate;
            diagnosis.DeletedDate = DateTime.Now;
            return Ok(_diagnosisService.Delete(diagnosis));
        }
    }
}
