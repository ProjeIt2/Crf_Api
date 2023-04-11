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
        public IActionResult GetActivesById(int id)
        {
            return Ok(_projectInformationService.GetActivesById(id));
        }
        [HttpGet("GetActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_projectInformationService.GetActives(CompanyID));
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
            var test = _projectInformationService.GetActivesById(projectInformation.ID);

            projectInformation.ModifiedDate = DateTime.Now;
            projectInformation.Status = 2;
            projectInformation.CompanyID = test.CompanyID;
            projectInformation.CreatedDate = test.CreatedDate;
            return Ok(_projectInformationService.Update(projectInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProjectInformation projectInformation)
        {
            var test = _projectInformationService.GetActivesById(projectInformation.ID);

            projectInformation.ModifiedDate = test.ModifiedDate;
            projectInformation.Status = 3;
            projectInformation.CompanyID = test.CompanyID;
            projectInformation.CreatedDate = test.CreatedDate;
            projectInformation.DeletedDate = DateTime.Now;
            return Ok(_projectInformationService.Delete(projectInformation));
        }
    }
}
