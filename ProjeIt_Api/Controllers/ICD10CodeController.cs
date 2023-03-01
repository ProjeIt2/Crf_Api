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
    public class ICD10CodeController : Controller
    {
        private readonly IICD10CodeService _iCD10CodeService;
        public ICD10CodeController(IICD10CodeService iCD10CodeService)
        {
            _iCD10CodeService = iCD10CodeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_iCD10CodeService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_iCD10CodeService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_iCD10CodeService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ICD10Code iCD10Code)
        {
            iCD10Code.CreatedDate = DateTime.Now;
            iCD10Code.Status = 1;
            return Ok(_iCD10CodeService.Add(iCD10Code));
        }
        [HttpPost("update")]
        public IActionResult Update(ICD10Code iCD10Code)
        {
            return Ok(_iCD10CodeService.Update(iCD10Code));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ICD10Code iCD10Code)
        {
            return Ok(_iCD10CodeService.Delete(iCD10Code));
        }
    }
}
