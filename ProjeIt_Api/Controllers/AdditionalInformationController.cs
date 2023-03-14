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
    public class AdditionalInformationController : Controller
    {
        private readonly IAdditionalInformationService _additionalInformationService;
        public AdditionalInformationController(IAdditionalInformationService additionalInformationService)
        {
            _additionalInformationService = additionalInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_additionalInformationService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_additionalInformationService.GetActives((int)CompanyID));
        }

        [HttpGet("getActivesFormID")]
        public IActionResult GetActivesFormID(int FormID)
        {
           
            return Ok(_additionalInformationService.GetActivesFormID((int)FormID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_additionalInformationService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_additionalInformationService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(AdditionalInformation additionalInformation)
        {
            additionalInformation.CreatedDate = DateTime.Now;
            additionalInformation.Status = 1;
            additionalInformation.CompanyID = 2;
       
            return Ok(_additionalInformationService.Add(additionalInformation));
        }
        [HttpPost("update")]
        public IActionResult Update(AdditionalInformation additionalInformation)
        {
            return Ok(_additionalInformationService.Update(additionalInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(AdditionalInformation additionalInformation)
        {
            return Ok(_additionalInformationService.Delete(additionalInformation));
        }
    }
}
