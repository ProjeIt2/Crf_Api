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
    public class MetastasisStatusController : ControllerBase
    {
        private readonly IMetastasisStatusService _metastasisStatusService;
        public MetastasisStatusController(IMetastasisStatusService metastasisStatusService)
        {
            _metastasisStatusService = metastasisStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_metastasisStatusService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int? CompanyID)
        {
            CompanyID = 2;
            return Ok(_metastasisStatusService.GetActives((int)CompanyID));
        }
        [HttpGet("getListMetastasisStatuss")]
        public IActionResult GetListMetastasisStatuss(int FormID)
        {

            return Ok(_metastasisStatusService.GetListMetastasisStatuss(FormID));

        }
        [HttpGet("getListMetastasisStatussID")]
        public IActionResult GetListMetastasisStatussID(int id)
        {

            return Ok(_metastasisStatusService.GetListMetastasisStatussID(id));

        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_metastasisStatusService.GetActivesById(id));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_metastasisStatusService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(MetastasisStatus metastasisStatus)
        {
            metastasisStatus.CreatedDate = DateTime.Now;
            metastasisStatus.Status = 1;
            return Ok(_metastasisStatusService.Add(metastasisStatus));
        }
        [HttpPost("update")]
        public IActionResult Update(MetastasisStatus metastasisStatus)
        {
            return Ok(_metastasisStatusService.Update(metastasisStatus));
        }
        [HttpPost("delete")]
        public IActionResult Delete(MetastasisStatus metastasisStatus)
        {
            return Ok(_metastasisStatusService.Delete(metastasisStatus));
        }
    }
}
