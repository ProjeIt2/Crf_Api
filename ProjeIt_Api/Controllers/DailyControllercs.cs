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
    public class DailyController : Controller
    {
        private readonly IDailyService _dailyService;
        public DailyController(IDailyService dailyService)
        {
            _dailyService = dailyService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_dailyService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_dailyService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_dailyService.GetActivesById(id));
        }
        [HttpGet("getDailyMyVisite")]
        public IActionResult GetDailyMyVisite(int PersonnelID)
        {

            return Ok(_dailyService.GetDailyMyVisite(PersonnelID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_dailyService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Daily daily)
        {
            daily.CreatedDate = DateTime.Now;
            daily.Status = 1;
            return Ok(_dailyService.Add(daily));
        }
        [HttpPost("update")]
        public IActionResult Update(Daily daily)
        {
            var test = _dailyService.GetActivesById(daily.ID);
            test.HospitalName = daily.HospitalName;
            test.DoctorName = daily.DoctorName;
            test.BranchNameID = daily.BranchNameID;
            test.MadeStatus = daily.MadeStatus;
            test.Latitude = daily.Latitude;
            test.Longitude = daily.Longitude;
            daily.ModifiedDate = DateTime.Now;
            daily.Status = 2;
        
            return Ok(_dailyService.Update(test));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Daily daily)
        {
            var test = _dailyService.GetActivesById(daily.ID);

            daily.ModifiedDate = test.ModifiedDate;
            daily.Status = 3;
            daily.CompanyID = test.CompanyID;
            daily.CreatedDate = test.CreatedDate;
            daily.DeletedDate = DateTime.Now;
            return Ok(_dailyService.Delete(daily));
        }
    }
}
