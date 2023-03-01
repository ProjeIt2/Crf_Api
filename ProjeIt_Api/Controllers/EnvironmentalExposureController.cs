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
    public class EnvironmentalExposureController : Controller
    {
        private readonly IEnvironmentalExposureService _environmentalExposureService;
        public EnvironmentalExposureController(IEnvironmentalExposureService environmentalExposureService)
        {
            _environmentalExposureService = environmentalExposureService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_environmentalExposureService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_environmentalExposureService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_environmentalExposureService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(EnvironmentalExposure environmentalExposure)
        {
            environmentalExposure.CreatedDate = DateTime.Now;
            environmentalExposure.Status = 1;
            return Ok(_environmentalExposureService.Add(environmentalExposure));
        }
        [HttpPost("update")]
        public IActionResult Update(EnvironmentalExposure environmentalExposure)
        {
            return Ok(_environmentalExposureService.Update(environmentalExposure));
        }
        [HttpPost("delete")]
        public IActionResult Delete(EnvironmentalExposure environmentalExposure)
        {
            return Ok(_environmentalExposureService.Delete(environmentalExposure));
        }
    }
}
