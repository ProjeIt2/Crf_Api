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
    public class DiagnosisHistoryController : Controller
    {
        private readonly IDiagnosisHistoryService _diagnosisHistoryService;
        public DiagnosisHistoryController(IDiagnosisHistoryService diagnosisHistoryService)
        {
            _diagnosisHistoryService = diagnosisHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_diagnosisHistoryService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_diagnosisHistoryService.GetActives(CompanyID));
        }
        [HttpGet("GgtActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_diagnosisHistoryService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_diagnosisHistoryService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(DiagnosisHistory diagnosisHistory)
        {
            diagnosisHistory.CreatedDate = DateTime.Now;
            diagnosisHistory.Status = 1;
            return Ok(_diagnosisHistoryService.Add(diagnosisHistory));
        }
        [HttpPost("update")]
        public IActionResult Update(DiagnosisHistory diagnosisHistory)
        {
            var test = _diagnosisHistoryService.GetActivesById(diagnosisHistory.ID);

            diagnosisHistory.ModifiedDate = DateTime.Now;
            diagnosisHistory.Status = 2;
            diagnosisHistory.CompanyID = test.CompanyID;
            diagnosisHistory.CreatedDate = test.CreatedDate;
            return Ok(_diagnosisHistoryService.Update(diagnosisHistory));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DiagnosisHistory diagnosisHistory)
        {
            var test = _diagnosisHistoryService.GetActivesById(diagnosisHistory.ID);

            diagnosisHistory.ModifiedDate = test.ModifiedDate;
            diagnosisHistory.Status = 3;
            diagnosisHistory.CompanyID = test.CompanyID;
            diagnosisHistory.CreatedDate = test.CreatedDate;
            diagnosisHistory.DeletedDate = DateTime.Now;
            return Ok(_diagnosisHistoryService.Delete(diagnosisHistory));
        }
    }
}
