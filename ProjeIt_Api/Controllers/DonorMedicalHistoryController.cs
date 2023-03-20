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
    public class DonorMedicalHistoryController : ControllerBase
    {
        private readonly IDonorMedicalHistoryService _donorMedicalHistoryService;
        public DonorMedicalHistoryController(IDonorMedicalHistoryService donorMedicalHistoryService)
        {
            _donorMedicalHistoryService = donorMedicalHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_donorMedicalHistoryService.GetList());
        }
        [HttpGet("GetListDonorMedicalHistorys")]
        public IActionResult GetListDonorMedicalHistorys(int FormID)
        {

            return Ok(_donorMedicalHistoryService.GetListDonorMedicalHistorys(FormID));

        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_donorMedicalHistoryService.GetActives(CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_donorMedicalHistoryService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_donorMedicalHistoryService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(DonorMedicalHistory donorMedicalHistory)
        {

            donorMedicalHistory.CreatedDate = DateTime.Now;
            donorMedicalHistory.Status = 1;
            donorMedicalHistory.CompanyID = 2;
            return Ok(_donorMedicalHistoryService.Add(donorMedicalHistory));
        }
        [HttpPost("update")]
        public IActionResult Update(DonorMedicalHistory donorMedicalHistory)
        {
            var test = _donorMedicalHistoryService.GetActivesById(donorMedicalHistory.ID);

            donorMedicalHistory.ModifiedDate = DateTime.Now;
            donorMedicalHistory.Status = 2;
            donorMedicalHistory.CreatedDate = test.CreatedDate;
            donorMedicalHistory.CompanyID = test.CompanyID;
            return Ok(_donorMedicalHistoryService.Update(donorMedicalHistory));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DonorMedicalHistory donorMedicalHistory)
        {
            var test = _donorMedicalHistoryService.GetActivesById(donorMedicalHistory.ID);

            donorMedicalHistory.ModifiedDate = test.ModifiedDate;
            donorMedicalHistory.Status = 3;
            donorMedicalHistory.CompanyID = test.CompanyID;
            donorMedicalHistory.CreatedDate = test.CreatedDate;
            donorMedicalHistory.DeletedDate = DateTime.Now;
            return Ok(_donorMedicalHistoryService.Delete(donorMedicalHistory));
        }
    }
}
