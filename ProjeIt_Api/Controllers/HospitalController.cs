﻿using Business.Services.Interfeces;
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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_hospitalService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_hospitalService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_hospitalService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Hospital hospital)
        {
            hospital.CreatedDate = DateTime.Now;
            hospital.Status = 1;
            return Ok(_hospitalService.Add(hospital));
        }
        [HttpPost("update")]
        public IActionResult Update(Hospital hospital)
        {
            return Ok(_hospitalService.Update(hospital));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Hospital hospital)
        {
            return Ok(_hospitalService.Delete(hospital));
        }
    }
}
