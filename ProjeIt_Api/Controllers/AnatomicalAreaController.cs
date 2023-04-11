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
    public class AnatomicalAreaController : Controller
    {
        private readonly IAnatomicalAreaService _anatomicalAreaService;
        public AnatomicalAreaController(IAnatomicalAreaService anatomicalAreaService)
        {
            _anatomicalAreaService = anatomicalAreaService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_anatomicalAreaService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
            
            return Ok(_anatomicalAreaService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_anatomicalAreaService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_anatomicalAreaService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(AnatomicalArea anatomicalArea)
        {
            anatomicalArea.CreatedDate = DateTime.Now;
            anatomicalArea.Status = 1;
            return Ok(_anatomicalAreaService.Add(anatomicalArea));
        }
        [HttpPost("update")]
        public IActionResult Update(AnatomicalArea anatomicalArea)
        {
            var test = _anatomicalAreaService.GetActivesById(anatomicalArea.ID);

            anatomicalArea.ModifiedDate = DateTime.Now;
            anatomicalArea.Status = 2;
            anatomicalArea.CompanyID = test.CompanyID;
            anatomicalArea.CreatedDate = test.CreatedDate;
            return Ok(_anatomicalAreaService.Update(anatomicalArea));
        }
        [HttpPost("delete")]
        public IActionResult Delete(AnatomicalArea anatomicalArea)
        {
            var test = _anatomicalAreaService.GetActivesById(anatomicalArea.ID);

            anatomicalArea.ModifiedDate = test.ModifiedDate;
            anatomicalArea.Status = 3;
            anatomicalArea.CompanyID = test.CompanyID;
            anatomicalArea.CreatedDate = test.CreatedDate;
            anatomicalArea.DeletedDate = DateTime.Now;
            return Ok(_anatomicalAreaService.Delete(anatomicalArea));
        }
    }
}
