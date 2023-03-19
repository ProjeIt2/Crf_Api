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
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_personnelService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_personnelService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_personnelService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Personnel personnel)
        {
            personnel.CreatedDate = DateTime.Now;
            personnel.Status = 1;
            return Ok(_personnelService.Add(personnel));
        }
        [HttpPost("update")]
        public IActionResult Update(Personnel personnel)
        {
            var test = _personnelService.GetActivesById(personnel.ID).FirstOrDefault();

            personnel.ModifiedDate = DateTime.Now;
            personnel.Status = 2;
            personnel.CompanyID = test.CompanyID;
            personnel.CreatedDate = test.CreatedDate;
            return Ok(_personnelService.Update(personnel));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Personnel personnel)
        {
            var test = _personnelService.GetActivesById(personnel.ID).FirstOrDefault();

            personnel.ModifiedDate = test.ModifiedDate;
            personnel.Status = 3;
            personnel.CompanyID = test.CompanyID;
            personnel.CreatedDate = test.CreatedDate;
            personnel.DeletedDate = DateTime.Now;
            return Ok(_personnelService.Delete(personnel));
        }
    }
}
