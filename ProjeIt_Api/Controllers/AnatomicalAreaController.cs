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
        public IActionResult GetActives()
        {
            int CompanyID=2;
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
            return Ok(_anatomicalAreaService.Update(anatomicalArea));
        }
        [HttpPost("delete")]
        public IActionResult Delete(AnatomicalArea anatomicalArea)
        {
            return Ok(_anatomicalAreaService.Delete(anatomicalArea));
        }
    }
}
