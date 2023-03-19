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
    public class CurrentStatusController : Controller
    {
        private readonly ICurrentStatusService _currentStatusService;
        public CurrentStatusController(ICurrentStatusService currentStatusService)
        {
            _currentStatusService = currentStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_currentStatusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_currentStatusService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_currentStatusService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_currentStatusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(CurrentStatus currentStatus)
        {
            currentStatus.CreatedDate = DateTime.Now;
            currentStatus.Status = 1;
            return Ok(_currentStatusService.Add(currentStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(CurrentStatus currentStatus)
        {
            var test = _currentStatusService.GetActivesById(currentStatus.ID);

            currentStatus.ModifiedDate = DateTime.Now;
            currentStatus.Status = 2;
            currentStatus.CompanyID = test.CompanyID;
            currentStatus.CreatedDate = test.CreatedDate;
            return Ok(_currentStatusService.Update(currentStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(CurrentStatus currentStatus)
        {
            var test = _currentStatusService.GetActivesById(currentStatus.ID);

            currentStatus.ModifiedDate = test.ModifiedDate;
            currentStatus.Status = 3;
            currentStatus.CompanyID = test.CompanyID;
            currentStatus.CreatedDate = test.CreatedDate;
            currentStatus.DeletedDate = DateTime.Now;
            return Ok(_currentStatusService.Delete(currentStatus));
            return Ok(_currentStatusService.Delete(currentStatus));
        }
    }
}
