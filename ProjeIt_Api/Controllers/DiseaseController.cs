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
    public class DiseaseController : Controller
    {
        private readonly IDiseaseService _diseaseService;
        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_diseaseService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_diseaseService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_diseaseService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Disease disease)
        {
            disease.CreatedDate = DateTime.Now;
            disease.Status = 1;
            return Ok(_diseaseService.Add(disease));
        }
        [HttpPost("update")]
        public IActionResult Update(Disease disease)
        {
            return Ok(_diseaseService.Update(disease));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Disease disease)
        {
            return Ok(_diseaseService.Delete(disease));
        }
    }
}
