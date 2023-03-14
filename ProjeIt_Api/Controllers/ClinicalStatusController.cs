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
    public class ClinicalStatusController : ControllerBase
    {
        private readonly IClinicalStatusService _clinicalStatusService;
        public ClinicalStatusController(IClinicalStatusService clinicalStatusService)
        {
            _clinicalStatusService = clinicalStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_clinicalStatusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_clinicalStatusService.GetActives((int)CompanyID));
        }
        [HttpGet("getListClinicalStatuss")]
        public IActionResult GetListClinicalStatuss(int FormID)
        {
            var Test = _clinicalStatusService.GetList().Where(x=>x.FormID==FormID).ToList();
            return Ok(_clinicalStatusService.GetListClinicalStatuss(FormID));

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
            clinicalStatus.CreatedDate = DateTime.Now;
            clinicalStatus.Status = 1;
            return Ok(_clinicalStatusService.Add(clinicalStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(ClinicalStatus clinicalStatus)
        {
            return Ok(_clinicalStatusService.Update(clinicalStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ClinicalStatus clinicalStatus)
        {
            return Ok(_clinicalStatusService.Delete(clinicalStatus));
        }
    }
}
