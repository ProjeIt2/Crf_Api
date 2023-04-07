using Business.Services.Interfeces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : ControllerBase
    {
        private readonly ISpecimenService _specimenService;
        public SpecimenController(ISpecimenService specimenService)
        {
            _specimenService = specimenService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_specimenService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
           int CompanyID = 2;
            return Ok(_specimenService.GetActives((int)CompanyID));
        }
        [HttpGet("getListSpecimens")]
        public IActionResult GetListSpecimens(int FormID)
        {

            return Ok(_specimenService.GetListSpecimens(FormID));

        }
        [HttpGet("getListSpecimensID")]
        public IActionResult GetListSpecimensID(int id)
        {

            return Ok(_specimenService.GetListSpecimensID(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_specimenService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_specimenService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Specimen specimen)
        {
            specimen.CreatedDate = DateTime.Now;
            specimen.Status = 1;
            return Ok(_specimenService.Add(specimen));
        }
        [HttpPost("update")]
        public IActionResult Update(Specimen specimen)
        {
            var test = _specimenService.GetActivesById(specimen.ID);

            specimen.ModifiedDate = DateTime.Now;
            specimen.Status = 2;
            specimen.CompanyID = test.CompanyID;
            specimen.CreatedDate = test.CreatedDate;
            return Ok(_specimenService.Update(specimen));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Specimen specimen)
        {
                       return Ok(_specimenService.Delete(specimen));
        }
    }
}
