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
    public class TNMController : Controller
    {
        private readonly ITNMService _tNMService;
        public TNMController(ITNMService tNMService)
        {
            _tNMService = tNMService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_tNMService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_tNMService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_tNMService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_tNMService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(TNM tNM)
        {
            tNM.CreatedDate = DateTime.Now;
            tNM.Status = 1;
            return Ok(_tNMService.Add(tNM));
        }
        [HttpPost("update")]
        public IActionResult Update(TNM tNM) 
        {
            var test = _tNMService.GetActivesById(tNM.ID);

            tNM.ModifiedDate = DateTime.Now;
            tNM.Status = 2;
            tNM.CompanyID = test.CompanyID;
            tNM.CreatedDate = test.CreatedDate;
            return Ok(_tNMService.Update(tNM));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TNM tNM)
        {
            var test = _tNMService.GetActivesById(tNM.ID);

            tNM.ModifiedDate = test.ModifiedDate;
            tNM.Status = 3;
            tNM.CompanyID = test.CompanyID;
            tNM.CreatedDate = test.CreatedDate;
            tNM.DeletedDate = DateTime.Now;
            return Ok(_tNMService.Delete(tNM));
        }
    }
}
