﻿using Business.Services.Interfeces;
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
        public IActionResult GetActivesById(int id)
        {
            return Ok(_patientInformationService.GetActivesById(id));
        }
        [HttpGet("GetActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_patientInformationService.GetActives(CompanyID));
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
             var test = _patientInformationService.GetByFormId((int)patientInformation.FormID);
            patientInformation.ID = test.ID; ;
            patientInformation.ModifiedDate = DateTime.Now;
            patientInformation.Status =2;
            patientInformation.CompanyID = test.CompanyID;
            patientInformation.CreatedDate = test.CreatedDate;
            return Ok(_patientInformationService.Update(patientInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(PatientInformation patientInformation)
    {
        var test = _patientInformationService.GetByFormId((int)patientInformation.FormID);
            patientInformation.ID = test.ID; ;
            patientInformation.ModifiedDate = test.ModifiedDate;
        patientInformation.Status = 3;
        patientInformation.CompanyID = test.CompanyID;
        patientInformation.CreatedDate = test.CreatedDate;
        patientInformation.DeletedDate = DateTime.Now;
        return Ok(_patientInformationService.Delete(patientInformation));
        }
    }
}
