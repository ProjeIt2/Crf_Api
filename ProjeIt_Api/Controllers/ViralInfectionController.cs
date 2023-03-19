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
    public class ViralInfectionController : ControllerBase
    {
        private readonly IViralInfectionService _viralInfectionService;
        public ViralInfectionController(IViralInfectionService viralInfectionService)
        {
            _viralInfectionService = viralInfectionService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_viralInfectionService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_viralInfectionService.GetActives((int)CompanyID));
        }
        [HttpGet("getListViralInfections")]
        public IActionResult GetListViralInfections(int FormID)
        {

            return Ok(_viralInfectionService.GetListViralInfections(FormID));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_viralInfectionService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_viralInfectionService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ViralInfection viralInfection)
        {
            viralInfection.CreatedDate = DateTime.Now;
            viralInfection.Status = 1;
            return Ok(_viralInfectionService.Add(viralInfection));
        }
        [HttpPost("update")]
        public IActionResult Update(ViralInfection viralInfection)
        {
            var test = _viralInfectionService.GetActivesById(viralInfection.ID);

            viralInfection.ModifiedDate = DateTime.Now;
            viralInfection.Status = 2;
            viralInfection.CompanyID = test.CompanyID;
            viralInfection.CreatedDate = test.CreatedDate;
            return Ok(_viralInfectionService.Update(viralInfection));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ViralInfection viralInfection)
        {
            var test = _viralInfectionService.GetActivesById(viralInfection.ID);

            viralInfection.ModifiedDate = test.ModifiedDate;
            viralInfection.Status = 3;
            viralInfection.CompanyID = test.CompanyID;
            viralInfection.CreatedDate = test.CreatedDate;
            viralInfection.DeletedDate = DateTime.Now;
            return Ok(_viralInfectionService.Delete(viralInfection));
        }
    }
}