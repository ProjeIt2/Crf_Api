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
    public class CancerTreatmentController : ControllerBase
    {
        private readonly ICancerTreatmentService _cancerTreatmentService;
        public CancerTreatmentController(ICancerTreatmentService cancerTreatmentService)
        {
            _cancerTreatmentService = cancerTreatmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_cancerTreatmentService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_cancerTreatmentService.GetActives((int)CompanyID));
        }
        [HttpGet("getListCancerTreatments")]
        public IActionResult GetListCancerTreatments(int FormID)
        {

            return Ok(_cancerTreatmentService.GetListCancerTreatments(FormID));

        }
        [HttpGet("getListCancerTreatmentsID")]
        public IActionResult GetListCancerTreatmentsID(int id)
        {

            return Ok(_cancerTreatmentService.GetListCancerTreatmentsID(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_cancerTreatmentService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_cancerTreatmentService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(CancerTreatment cancerTreatment)
        {
            cancerTreatment.CreatedDate = DateTime.Now;
            cancerTreatment.Status = 1;
            return Ok(_cancerTreatmentService.Add(cancerTreatment));
        }
        [HttpPost("update")]
        public IActionResult Update(CancerTreatment cancerTreatment)
        {
            var test = _cancerTreatmentService.GetActivesById(cancerTreatment.ID);

            cancerTreatment.ModifiedDate = DateTime.Now;
            cancerTreatment.Status = 2;
            cancerTreatment.CompanyID = test.CompanyID;
            cancerTreatment.CreatedDate = test.CreatedDate;
            return Ok(_cancerTreatmentService.Update(cancerTreatment));
        }
        [HttpPost("delete")]
        public IActionResult Delete(CancerTreatment cancerTreatment)
        {
         
            return Ok(_cancerTreatmentService.Delete(cancerTreatment));
        }
    }
}
