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
    public class TumorStatusController : ControllerBase
    {
        private readonly ITumorStatusService _tumorStatusService;
        public TumorStatusController(ITumorStatusService tumorStatusService)
        {
            _tumorStatusService = tumorStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_tumorStatusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_tumorStatusService.GetActives((int)CompanyID));
        }
        [HttpGet("getListTumorStatuss")]
        public IActionResult GetListTumorStatuss(int FormID)
        {

            return Ok(_tumorStatusService.GetListTumorStatuss(FormID));

        }
        [HttpGet("getListTumorStatussID")]
        public IActionResult GetListTumorStatussID(int id)
        {

            return Ok(_tumorStatusService.GetListTumorStatussID(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_tumorStatusService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_tumorStatusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(TumorStatus tumorStatus)
        {
            tumorStatus.CreatedDate = DateTime.Now;
            tumorStatus.Status = 1;
            return Ok(_tumorStatusService.Add(tumorStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(TumorStatus tumorStatus)
        {
            var test = _tumorStatusService.GetActivesById(tumorStatus.ID);

            tumorStatus.ModifiedDate = DateTime.Now;
            tumorStatus.Status = 2;
            tumorStatus.CompanyID = test.CompanyID;
            tumorStatus.CreatedDate = test.CreatedDate;
            return Ok(_tumorStatusService.Update(tumorStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TumorStatus tumorStatus)
        {
                     return Ok(_tumorStatusService.Delete(tumorStatus));
        }
    }
}
