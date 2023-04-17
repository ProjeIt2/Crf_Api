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
    public class BranchNameController : Controller
    {
        private readonly IBranchNameService _branchNameService;
        public BranchNameController(IBranchNameService branchNameService)
        {
            _branchNameService = branchNameService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_branchNameService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
         
            return Ok(_branchNameService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_branchNameService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_branchNameService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(BranchName branchName)
        {
            branchName.CreatedDate = DateTime.Now;
            branchName.Status = 1;
            return Ok(_branchNameService.Add(branchName));
        }
        [HttpPost("update")]
        public IActionResult Update(BranchName branchName)
        {
            var test = _branchNameService.GetActivesById(branchName.ID);

            branchName.ModifiedDate = DateTime.Now;
            branchName.Status = 2;
            branchName.CompanyID = test.CompanyID;
            branchName.CreatedDate = test.CreatedDate;
            return Ok(_branchNameService.Update(branchName));
        }
        [HttpPost("delete")]
        public IActionResult Delete(BranchName branchName)
        {
            var test = _branchNameService.GetActivesById(branchName.ID);

            branchName.ModifiedDate = test.ModifiedDate;
            branchName.Status = 3;
            branchName.CompanyID = test.CompanyID;
            branchName.CreatedDate = test.CreatedDate;
            branchName.DeletedDate = DateTime.Now;
            return Ok(_branchNameService.Delete(branchName));
        }
    }
}
