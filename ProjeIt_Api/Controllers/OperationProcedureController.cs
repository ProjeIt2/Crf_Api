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
    public class OperationProcedureController : Controller
    {
        private readonly IOperationProcedureService _operationProcedureService;
        public OperationProcedureController(IOperationProcedureService operationProcedureService)
        {
            _operationProcedureService = operationProcedureService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_operationProcedureService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_operationProcedureService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_operationProcedureService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_operationProcedureService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(OperationProcedure operationProcedure)
        {
            operationProcedure.CreatedDate = DateTime.Now;
            operationProcedure.Status = 1;
            return Ok(_operationProcedureService.Add(operationProcedure));
        }
        [HttpPost("update")]
        public IActionResult Update(OperationProcedure operationProcedure)
        {
            return Ok(_operationProcedureService.Update(operationProcedure));
        }
        [HttpPost("delete")]
        public IActionResult Delete(OperationProcedure operationProcedure)
        {
            return Ok(_operationProcedureService.Delete(operationProcedure));
        }
    }
}
