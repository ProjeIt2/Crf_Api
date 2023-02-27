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
    public class FormController : ControllerBase
    {
        private readonly IFormService _appUserService;
        public FormController(IFormService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_appUserService.GetList());
        }
        [HttpGet("GetListForms")]
        public IActionResult GetListForms()
        {

            return Ok(_appUserService.GetListForms());

        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_appUserService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_appUserService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Form appUser)
        {
            appUser.CreatedDate = DateTime.Now;
            appUser.Status = 1;
            return Ok(_appUserService.Add(appUser));
        }
        [HttpPost("update")]
        public IActionResult Update(Form appUser)
        {
            return Ok(_appUserService.Update(appUser));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Form appUser)
        {
            return Ok(_appUserService.Delete(appUser));
        }
    }
}
