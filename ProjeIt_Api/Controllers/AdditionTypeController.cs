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
    public class AdditionTypeController : Controller
    {
        private readonly IAdditionTypeService _additionTypeService;
        public AdditionTypeController(IAdditionTypeService additionTypeService)
        {
            _additionTypeService = additionTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_additionTypeService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
           
            return Ok(_additionTypeService.GetActives((int)CompanyID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_additionTypeService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_additionTypeService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(AdditionType additionType)
        {
            additionType.CreatedDate = DateTime.Now;
            additionType.Status = 1;
            return Ok(_additionTypeService.Add(additionType));
        }
        [HttpPost("update")]
        public IActionResult Update(AdditionType additionType)
        {
            var test = _additionTypeService.GetActivesById(additionType.ID);

            additionType.ModifiedDate = DateTime.Now;
            additionType.Status = 2;
            additionType.CompanyID = test.CompanyID;
            additionType.CreatedDate = test.CreatedDate;
            return Ok(_additionTypeService.Update(additionType));
        }
        [HttpPost("delete")]
        public IActionResult Delete(AdditionType additionType)
        {
            var test = _additionTypeService.GetActivesById(additionType.ID);

            additionType.ModifiedDate = test.ModifiedDate;
            additionType.Status = 3;
            additionType.CompanyID = test.CompanyID;
            additionType.CreatedDate = test.CreatedDate;
            additionType.DeletedDate = DateTime.Now;
            return Ok(_additionTypeService.Delete(additionType));
        }
    }
}
