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
    public class PhaseController : Controller
    {
        private readonly IPhaseService _phaseService;
        public PhaseController(IPhaseService phaseService)
        {
            _phaseService = phaseService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_phaseService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
             return Ok(_phaseService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_phaseService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_phaseService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Phase phase)
        {
            phase.CreatedDate = DateTime.Now;
            phase.Status = 1;
            return Ok(_phaseService.Add(phase));
        }
        [HttpPost("update")]
        public IActionResult Update(Phase phase) 
        {
            var test = _phaseService.GetActivesById(phase.ID);

            phase.ModifiedDate = DateTime.Now;
            phase.Status = 2;
            phase.CompanyID = test.CompanyID;
            phase.CreatedDate = test.CreatedDate;
            return Ok(_phaseService.Update(phase));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Phase phase)
        { 
         var test = _phaseService.GetActivesById(phase.ID);

        phase.ModifiedDate = test.ModifiedDate;
            phase.Status = 3;
            phase.CompanyID = test.CompanyID;
            phase.CreatedDate = test.CreatedDate;
            phase.DeletedDate = DateTime.Now;
            return Ok(_phaseService.Delete(phase));
        }
    }
}
