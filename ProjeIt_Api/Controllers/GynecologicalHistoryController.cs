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
    public class GynecologicalHistoryController : Controller
    {
        private readonly IGynecologicalHistoryService _gynecologicalHistoryService;
        public GynecologicalHistoryController(IGynecologicalHistoryService gynecologicalHistoryService)
        {
            _gynecologicalHistoryService = gynecologicalHistoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_gynecologicalHistoryService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
             
            return Ok(_gynecologicalHistoryService.GetActives(CompanyID));
        }
        [HttpGet("getActivesFormID")]
        public IActionResult GetActivesFormID(int FormID)
        {
          
            return Ok(_gynecologicalHistoryService.GetActivesFormID(FormID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_gynecologicalHistoryService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_gynecologicalHistoryService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(GynecologicalHistory gynecologicalHistory)
        {
            gynecologicalHistory.CreatedDate = DateTime.Now;
            gynecologicalHistory.Status = 1;
            return Ok(_gynecologicalHistoryService.Add(gynecologicalHistory));
        }
        [HttpPost("update")]
        public IActionResult Update(GynecologicalHistory gynecologicalHistory)
        {
            var test = _gynecologicalHistoryService.GetActivesById(gynecologicalHistory.ID);

            gynecologicalHistory.ModifiedDate = DateTime.Now;
            gynecologicalHistory.Status = 2;
            gynecologicalHistory.CompanyID = test.CompanyID;
            gynecologicalHistory.CreatedDate = test.CreatedDate;
            return Ok(_gynecologicalHistoryService.Update(gynecologicalHistory));
        }
        [HttpPost("delete")]
        public IActionResult Delete(GynecologicalHistory gynecologicalHistory)
        {
             return Ok(_gynecologicalHistoryService.Delete(gynecologicalHistory));
        }
    }
}
