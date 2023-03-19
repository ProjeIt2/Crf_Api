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
    public class PillController : Controller
    {
        private readonly IPillService _pillService;
        public PillController(IPillService pillService)
        {
            _pillService = pillService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_pillService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID = 2;
            return Ok(_pillService.GetActives(CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_pillService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_pillService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Pill pill)
        {
            pill.CreatedDate = DateTime.Now;
            pill.Status = 1;
            return Ok(_pillService.Add(pill));
        }
        [HttpPost("update")]
        public IActionResult Update(Pill pill) 
        {
            var test = _pillService.GetActivesById(pill.ID);

            pill.ModifiedDate = DateTime.Now;
            pill.Status = 2;
            pill.CompanyID = test.CompanyID;
            pill.CreatedDate = test.CreatedDate;
            return Ok(_pillService.Update(pill));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Pill pill)
        {
            var test = _pillService.GetActivesById(pill.ID);

            pill.ModifiedDate = test.ModifiedDate;
            pill.Status = 3;
            pill.CompanyID = test.CompanyID;
            pill.CreatedDate = test.CreatedDate;
            pill.DeletedDate = DateTime.Now;
            return Ok(_pillService.Delete(pill));
        }
    }
}
