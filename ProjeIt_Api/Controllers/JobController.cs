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
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_jobService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_jobService.GetById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_jobService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Job job)
        {
            job.CreatedDate = DateTime.Now;
            job.Status = 1;
            return Ok(_jobService.Add(job));
        }
        [HttpPost("update")]
        public IActionResult Update(Job job)
        {
            var test = _jobService.GetActivesById(job.ID).FirstOrDefault();

            job.ModifiedDate = DateTime.Now;
            job.Status = 2;
            job.CompanyID = test.CompanyID;
            job.CreatedDate = test.CreatedDate;
            return Ok(_jobService.Update(job));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Job job)
        {
            var test = _jobService.GetActivesById(job.ID).FirstOrDefault();

            job.ModifiedDate = test.ModifiedDate;
            job.Status = 3;
            job.CompanyID = test.CompanyID;
            job.CreatedDate = test.CreatedDate;
            job.DeletedDate = DateTime.Now;
            return Ok(_jobService.Delete(job));
        }
    }
}
