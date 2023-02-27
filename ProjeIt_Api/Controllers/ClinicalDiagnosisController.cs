using Business.Services.Interfeces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicalDiagnosisController : ControllerBase
    {
        private readonly IClinicalDiagnosisService _clinicalDiagnosisService;
        public ClinicalDiagnosisController(IClinicalDiagnosisService clinicalDiagnosisService)
        {
            _clinicalDiagnosisService = clinicalDiagnosisService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_clinicalDiagnosisService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_clinicalDiagnosisService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_clinicalDiagnosisService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ClinicalDiagnosis clinicalDiagnosis)
        {
            clinicalDiagnosis.CreatedDate = DateTime.Now;
            clinicalDiagnosis.Status = 1;
            return Ok(_clinicalDiagnosisService.Add(clinicalDiagnosis));
        }
        [HttpPost("update")]
        public IActionResult Update(ClinicalDiagnosis clinicalDiagnosis)
        {
            return Ok(_clinicalDiagnosisService.Update(clinicalDiagnosis));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ClinicalDiagnosis clinicalDiagnosis)
        {
            return Ok(_clinicalDiagnosisService.Delete(clinicalDiagnosis));
        }
    }
}
