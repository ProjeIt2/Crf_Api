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
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID = 2;
            return Ok(_medicalStatusService.GetActives(CompanyID));
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_medicalStatusService.GetActivesById(id));
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
            var test = _medicalStatusService.GetActivesById(medicalStatus.ID);

            medicalStatus.ModifiedDate = DateTime.Now;
            medicalStatus.Status = 2;
            medicalStatus.CompanyID = test.CompanyID;
            medicalStatus.CreatedDate = test.CreatedDate;
            return Ok(_medicalStatusService.Update(medicalStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(MedicalStatus medicalStatus)
        {
            var test = _medicalStatusService.GetActivesById(medicalStatus.ID);

            medicalStatus.ModifiedDate = test.ModifiedDate;
            medicalStatus.Status = 3;
            medicalStatus.CompanyID = test.CompanyID;
            medicalStatus.CreatedDate = test.CreatedDate;
            medicalStatus.DeletedDate = DateTime.Now;
            return Ok(_medicalStatusService.Delete(medicalStatus));
        }
    }
}
