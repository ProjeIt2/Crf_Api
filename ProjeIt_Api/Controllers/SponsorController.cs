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
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _SponsorService;
        public SponsorController(ISponsorService rolService)
        {
            _SponsorService = rolService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_SponsorService.GetList());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int SponsorId)
        {
            return Ok(_SponsorService.GetById(SponsorId));
        }

        [HttpPost("add")]
        public IActionResult Add(Sponsor sponsor)
        {
            return Ok(_SponsorService.Add(sponsor));
        }
        [HttpPost("update")]
        public IActionResult Update(Sponsor sponsor)
        {
            return Ok(_SponsorService.Update(sponsor));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Sponsor sponsor)
        {
            return Ok(_SponsorService.Delete(sponsor));
        }
    }
}
