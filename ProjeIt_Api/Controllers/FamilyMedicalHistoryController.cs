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
    public class FamilyMedicalHistoryController : ControllerBase
    {
        private readonly IFamilyMedicalHistoryService _familyMedicalHistoryService;
        public FamilyMedicalHistoryController(IFamilyMedicalHistoryService familyMedicalHistoryService)
        {
            _familyMedicalHistoryService = familyMedicalHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_familyMedicalHistoryService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_familyMedicalHistoryService.GetActives((int)CompanyID));
        }
        [HttpGet("getListFamilyMedicalHistorys")]
        public IActionResult GetListFamilyMedicalHistorys(int FormID)
        {

            return Ok(_familyMedicalHistoryService.GetListFamilyMedicalHistorys(FormID));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_familyMedicalHistoryService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_familyMedicalHistoryService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(FamilyMedicalHistory familyMedicalHistory)
        {
            familyMedicalHistory.CompanyID = 2;
            familyMedicalHistory.CreatedDate = DateTime.Now;
            familyMedicalHistory.Status = 1;
            return Ok(_familyMedicalHistoryService.Add(familyMedicalHistory));
        }
        [HttpPost("update")]
        public IActionResult Update(FamilyMedicalHistory familyMedicalHistory)
        {
            var test = _familyMedicalHistoryService.GetActivesById(familyMedicalHistory.ID);

            familyMedicalHistory.ModifiedDate = DateTime.Now;
            familyMedicalHistory.Status =2;
            familyMedicalHistory.CompanyID = test.CompanyID;
            familyMedicalHistory.CreatedDate = test.CreatedDate;
          
            return Ok(_familyMedicalHistoryService.Update(familyMedicalHistory));
        }
        [HttpPost("delete")]
        public IActionResult Delete(FamilyMedicalHistory familyMedicalHistory)
        {
            var test = _familyMedicalHistoryService.GetActivesById(familyMedicalHistory.ID);

            familyMedicalHistory.ModifiedDate = test.ModifiedDate;
            familyMedicalHistory.Status = 3;
            familyMedicalHistory.CompanyID = test.CompanyID;
            familyMedicalHistory.CreatedDate = test.CreatedDate;
            familyMedicalHistory.DeletedDate = DateTime.Now;
            return Ok(_familyMedicalHistoryService.Delete(familyMedicalHistory));
        }
    }
}
