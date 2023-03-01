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
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_diagnosisHistoryService.GetById(CompanyID));
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
            return Ok(_diagnosisHistoryService.Update(diagnosisHistory));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DiagnosisHistory diagnosisHistory)
        {
            return Ok(_diagnosisHistoryService.Delete(diagnosisHistory));
        }
    }
}
