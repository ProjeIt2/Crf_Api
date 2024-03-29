﻿using Business.Services.Interfeces;
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
    public class LymphNodeController : Controller
    {
        private readonly ILymphNodeService _lymphNodeService;
        public LymphNodeController(ILymphNodeService lymphNodeService)
        {
            _lymphNodeService = lymphNodeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_lymphNodeService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
            
            return Ok(_lymphNodeService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_lymphNodeService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_lymphNodeService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(LymphNode lymphNode)
        {
            lymphNode.CreatedDate = DateTime.Now;
            lymphNode.Status = 1;
            return Ok(_lymphNodeService.Add(lymphNode));
        }
        [HttpPost("update")]
        public IActionResult Update(LymphNode lymphNode)
        {
            var test = _lymphNodeService.GetActivesById(lymphNode.ID);

            lymphNode.ModifiedDate = DateTime.Now;
            lymphNode.Status = 2;
            lymphNode.CompanyID = test.CompanyID;
            lymphNode.CreatedDate = test.CreatedDate;
            return Ok(_lymphNodeService.Update(lymphNode));
        }
        [HttpPost("delete")]
        public IActionResult Delete(LymphNode lymphNode)
        {
            var test = _lymphNodeService.GetActivesById(lymphNode.ID);

            lymphNode.ModifiedDate = test.ModifiedDate;
            lymphNode.Status = 3;
            lymphNode.CompanyID = test.CompanyID;
            lymphNode.CreatedDate = test.CreatedDate;
            lymphNode.DeletedDate = DateTime.Now;
            return Ok(_lymphNodeService.Delete(lymphNode));
        }
    }
}
