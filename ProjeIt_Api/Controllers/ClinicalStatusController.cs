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
    public class ClinicalStatusController : ControllerBase
    {
        private readonly IClinicalStatusService _clinicalStatusService;
        private readonly IFormService _formService;
        private readonly IDoctorRequestedReportService _doctorRequestedReportService;
        public ClinicalStatusController(IClinicalStatusService clinicalStatusService, IFormService formService, IDoctorRequestedReportService doctorRequestedReportService)
        {
            _clinicalStatusService = clinicalStatusService;
            _formService = formService;
            _doctorRequestedReportService = doctorRequestedReportService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_clinicalStatusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
           
            return Ok(_clinicalStatusService.GetActives((int)CompanyID));
        }
        [HttpGet("getListClinicalStatuss")]
        public IActionResult GetListClinicalStatuss(int FormID)
        {
         
            //var Test = _clinicalStatusService.GetList().Where(x => x.FormID == FormID).ToList();
            return Ok(_clinicalStatusService.GetListClinicalStatuss(FormID));

        }
        [HttpGet("getListClinicalStatu")]
        public IActionResult GetListClinicalStatu(int id)
        {
     
            //var Test = _clinicalStatusService.GetList().Where(x => x.FormID == id).ToList();
            return Ok(_clinicalStatusService.GetListClinicalStatu(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_clinicalStatusService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_clinicalStatusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ClinicalStatus clinicalStatus)
        {
            //project ID Yakalamak için FormID verileri çekildi
            //var form = _formService.GetById((int)clinicalStatus.FormID);
            //var docdorreq = _doctorRequestedReportService.GetList().Where(x => x.ProjectInformationID == form.ProjectInformationID && x.ReportID == clinicalStatus.DoctorRequestedReportID).FirstOrDefault();
            clinicalStatus.CreatedDate = DateTime.Now;
            clinicalStatus.Status = 1;
            //clinicalStatus.DoctorRequestedReportID = docdorreq.ID;
            //clinicalStatus.CompanyID = docdorreq.CompanyID;
            return Ok(_clinicalStatusService.Add(clinicalStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(ClinicalStatus clinicalStatus)
        {
            var test = _clinicalStatusService.GetActivesById(clinicalStatus.ID);

            clinicalStatus.ModifiedDate = DateTime.Now;
            clinicalStatus.Status = 2;
            clinicalStatus.CompanyID = test.CompanyID;
            clinicalStatus.CreatedDate = test.CreatedDate;
            return Ok(_clinicalStatusService.Update(clinicalStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ClinicalStatus clinicalStatus)
        {
            return Ok(_clinicalStatusService.Delete(clinicalStatus));
        }
    }
}
