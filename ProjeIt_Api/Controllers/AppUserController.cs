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
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_appUserService.GetList());
        }
        [HttpGet("Login")]
        public IActionResult Login(string UserName, string Password)
        {
            return Ok(_appUserService.Login(UserName, Password));
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
        public IActionResult Add(AppUser appUser)
        {
            appUser.CreatedDate = DateTime.Now;
            appUser.Status = 1;
            return Ok(_appUserService.Add(appUser));
        }
        [HttpPost("update")]
        public IActionResult Update(AppUser appUser)
        {
            var test = _appUserService.GetActivesById(appUser.ID).FirstOrDefault();

            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            appUser.CompanyID = test.CompanyID;
            appUser.CreatedDate = test.CreatedDate;
            return Ok(_appUserService.Update(appUser));
        }
        [HttpPost("delete")]
        public IActionResult Delete(AppUser appUser)
        {
            var test = _appUserService.GetActivesById(appUser.ID).FirstOrDefault();

            appUser.ModifiedDate = test.ModifiedDate;
            appUser.Status = 3;
            appUser.CompanyID = test.CompanyID;
            appUser.CreatedDate = test.CreatedDate;
            appUser.DeletedDate = DateTime.Now;
            return Ok(_appUserService.Delete(appUser));
            return Ok(_appUserService.Delete(appUser));
        }
    }
}
