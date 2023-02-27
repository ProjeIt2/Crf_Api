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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_doctorService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_doctorService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_doctorService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Doctor doctor)
        {
            doctor.CreatedDate = DateTime.Now;
            doctor.Status = 1;
            return Ok(_doctorService.Add(doctor));
        }
        [HttpPost("update")]
        public IActionResult Update(Doctor doctor)
        {
            return Ok(_doctorService.Update(doctor));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Doctor doctor)
        {
            return Ok(_doctorService.Delete(doctor));
        }
    }
}
