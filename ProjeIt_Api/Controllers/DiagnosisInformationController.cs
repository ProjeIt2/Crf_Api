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
    public class DiagnosisInformationController : ControllerBase
    {
        private readonly IDiagnosisInformationService _diagnosisInformationService;
        public DiagnosisInformationController(IDiagnosisInformationService diagnosisInformationService)
        {
            _diagnosisInformationService = diagnosisInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_diagnosisInformationService.GetList());
        }
        [HttpGet("GetListDiagnosisInformations")]
        public IActionResult GetListDiagnosisInformations(int FormID)
        {

            return Ok(_diagnosisInformationService.GetListDiagnosisInformations(FormID));

        }
        [HttpGet("tetListDiagnosisInformationsID")]
        public IActionResult GetListDiagnosisInformationsID(int id)
        {

            return Ok(_diagnosisInformationService.GetListDiagnosisInformationsID(id));

        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_diagnosisInformationService.GetActivesById(id));
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {
             
            return Ok(_diagnosisInformationService.GetActives(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_diagnosisInformationService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(DiagnosisInformation diagnosisInformation)
        {
            diagnosisInformation.CreatedDate = DateTime.Now;
            diagnosisInformation.Status = 1;
            return Ok(_diagnosisInformationService.Add(diagnosisInformation));
        }
        [HttpPost("update")]
        public IActionResult Update(DiagnosisInformation diagnosisInformation)
        {
            var test = _diagnosisInformationService.GetActivesById(diagnosisInformation.ID);

            diagnosisInformation.ModifiedDate = DateTime.Now;
            diagnosisInformation.Status = 2;
            diagnosisInformation.CompanyID = test.CompanyID;
            diagnosisInformation.CreatedDate = test.CreatedDate;
            return Ok(_diagnosisInformationService.Update(diagnosisInformation));
        }
        [HttpPost("delete")]
        public IActionResult Delete(DiagnosisInformation diagnosisInformation)
        {
            return Ok(_diagnosisInformationService.Delete(diagnosisInformation));
        }
    }
}
