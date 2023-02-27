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
    public class ProjectInformationController : ControllerBase
    {
        private readonly IProjectInformationService _projectInformationService;
        public ProjectInformationController(IProjectInformationService projectInformationService)
        {
            _projectInformationService = projectInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_projectInformationService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_projectInformationService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_projectInformationService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ProjectInformation projectInformation)
        {
            projectInformation.CreatedDate = DateTime.Now;
            projectInformation.Status = 1;
            return Ok(_projectInformationService.Add(projectInformation));
        }
        [HttpPost("update")]
        public IActionResult Update(ProjectInformation projectInformation)
        {
            return Ok(_projectInformationService.Update(projectInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProjectInformation projectInformation)
        {
            return Ok(_projectInformationService.Delete(projectInformation));
        }
    }
}
