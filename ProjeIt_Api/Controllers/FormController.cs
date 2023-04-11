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
        private readonly IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_formService.GetList());
        }
        [HttpGet("GetListForms")]
        public IActionResult GetListForms(int CompanyID)
        {

            return Ok(_formService.GetListForms(CompanyID));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_formService.GetActivesById(id));
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_formService.GetActives(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_formService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Form form)
        {
            form.CreatedDate = DateTime.Now;
            form.Status = 1;
            return Ok(_formService.Add(form));
        }
        [HttpPost("update")]
        public IActionResult Update(Form form)
        {
            var test = _formService.GetActivesById(form.ID);

            form.ModifiedDate = DateTime.Now;
            form.Status = 2;
            form.CompanyID = test.CompanyID;
            form.CreatedDate = test.CreatedDate;
            return Ok(_formService.Update(form));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Form form)
        {
            var test = _formService.GetActivesById(form.ID);

            form.ModifiedDate = test.ModifiedDate;
            form.Status = 3;
            form.CompanyID = test.CompanyID;
            form.CreatedDate = test.CreatedDate;
            form.DeletedDate = DateTime.Now;
            return Ok(_formService.Delete(form));
        }
    }
}
