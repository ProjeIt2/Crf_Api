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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_medicineService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_medicineService.GetActives((int)CompanyID));
        }
        [HttpGet("getListMedicines")]
        public IActionResult GetListMedicines(int FormID)
        {

            return Ok(_medicineService.GetListMedicines(FormID));

        }
        [HttpGet("getListMedicinesID")]
        public IActionResult GetListMedicinesID(int id)
        {

            return Ok(_medicineService.GetListMedicinesID(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_medicineService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_medicineService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(Medicine medicine)
        {
            medicine.CreatedDate = DateTime.Now;
            medicine.Status = 1;
            return Ok(_medicineService.Add(medicine));
        }
        [HttpPost("update")]
        public IActionResult Update(Medicine medicine)
        {
            return Ok(_medicineService.Update(medicine));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Medicine medicine)
        {
            return Ok(_medicineService.Delete(medicine));
        }
    }
}
