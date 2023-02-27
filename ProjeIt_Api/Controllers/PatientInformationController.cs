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
    public class PatientInformationController : ControllerBase
    {
        private readonly IPatientInformationService _patientInformationService;
        public PatientInformationController(IPatientInformationService patientInformationService)
        {
            _patientInformationService = patientInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_patientInformationService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_patientInformationService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_patientInformationService.GetById(ID));
        }
        [HttpGet("GetByFormId")]
        public IActionResult GetByFormId(int ID)
        {
            return Ok(_patientInformationService.GetByFormId(ID));
        }
        [HttpPost("add")]
        public IActionResult Add(PatientInformation patientInformation)
        {
            patientInformation.CreatedDate = DateTime.Now;
            patientInformation.Status = 1;
            return Ok(_patientInformationService.Add(patientInformation));
        }
        [HttpPost("update")]
        public IActionResult Update(PatientInformation patientInformation)
        {
            return Ok(_patientInformationService.Update(patientInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(PatientInformation patientInformation)
        {
            return Ok(_patientInformationService.Delete(patientInformation));
        }
    }
}
