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
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_countryService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_countryService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_countryService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Country country)
        {
            country.CreatedDate = DateTime.Now;
            country.Status = 1;
            return Ok(_countryService.Add(country));
        }
        [HttpPost("update")]
        public IActionResult Update(Country country)
        {
            var test = _countryService.GetActivesById(country.ID).FirstOrDefault();

            country.ModifiedDate = DateTime.Now;
            country.Status = 2;
            country.CompanyID = test.CompanyID;
            country.CreatedDate = test.CreatedDate;
            return Ok(_countryService.Update(country));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Country country)
        {
            var test = _countryService.GetActivesById(country.ID).FirstOrDefault();

            country.ModifiedDate = test.ModifiedDate;
            country.Status = 3;
            country.CompanyID = test.CompanyID;
            country.CreatedDate = test.CreatedDate;
            country.DeletedDate = DateTime.Now;
            return Ok(_countryService.Delete(country));
            return Ok(_countryService.Delete(country));
        }
    }
}
