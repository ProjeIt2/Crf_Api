﻿using Business.Services.Interfeces;
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
    public class DoctorRequestedReportController : Controller
    {
        private readonly IDoctorRequestedReportService _doctorRequestedReportService;
        private readonly IFormService _formService;
        public DoctorRequestedReportController(IDoctorRequestedReportService doctorRequestedReportService, IFormService formService)
        {
            _doctorRequestedReportService = doctorRequestedReportService;
            _formService= formService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_doctorRequestedReportService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_doctorRequestedReportService.GetActives((int)CompanyID));
        }
        [HttpGet("getProjectID")]
        public IActionResult GetProjectID(int FormID)
        {
            var form = _formService.GetActivesById(FormID);
            return Ok(_doctorRequestedReportService.GetProjectID((int)form.ProjectInformationID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_doctorRequestedReportService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_doctorRequestedReportService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(DoctorRequestedReport doctorRequestedReport)
        {
            doctorRequestedReport.CreatedDate = DateTime.Now;
            doctorRequestedReport.Status = 1;
            return Ok(_doctorRequestedReportService.Add(doctorRequestedReport));
        }
        [HttpPost("update")]
        public IActionResult Update(DoctorRequestedReport doctorRequestedReport)
        {
            return Ok(_doctorRequestedReportService.Update(doctorRequestedReport));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DoctorRequestedReport doctorRequestedReport)
        {
            return Ok(_doctorRequestedReportService.Delete(doctorRequestedReport));
        }
    }
}
