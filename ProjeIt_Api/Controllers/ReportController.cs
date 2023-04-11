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
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_reportService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_reportService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_reportService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_reportService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Report report)
        {
            report.CreatedDate = DateTime.Now;
            report.Status = 1;
            return Ok(_reportService.Add(report));
        }
        [HttpPost("update")]
        public IActionResult Update(Report report)
        {
            var test = _reportService.GetActivesById(report.ID);

            report.ModifiedDate = DateTime.Now;
            report.Status = 2;
            report.CompanyID = test.CompanyID;
            report.CreatedDate = test.CreatedDate;
            return Ok(_reportService.Update(report));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Report report)
        {
            var test = _reportService.GetActivesById(report.ID);

            report.ModifiedDate = test.ModifiedDate;
            report.Status = 3;
            report.CompanyID = test.CompanyID;
            report.CreatedDate = test.CreatedDate;
            report.DeletedDate = DateTime.Now;
           
            return Ok(_reportService.Delete(report));
        }
    }
}
