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
    public class MedicalStatusController : Controller
    {
        private readonly IMedicalStatusService _medicalStatusService;
        public MedicalStatusController(IMedicalStatusService medicalStatusService)
        {
            _medicalStatusService = medicalStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_medicalStatusService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_medicalStatusService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_medicalStatusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(MedicalStatus medicalStatus)
        {
            medicalStatus.CreatedDate = DateTime.Now;
            medicalStatus.Status = 1;
            return Ok(_medicalStatusService.Add(medicalStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(MedicalStatus medicalStatus)
        {
            return Ok(_medicalStatusService.Update(medicalStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(MedicalStatus medicalStatus)
        {
            return Ok(_medicalStatusService.Delete(medicalStatus));
        }
    }
}
