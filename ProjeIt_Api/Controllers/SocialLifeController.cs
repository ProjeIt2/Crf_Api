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
    public class SocialLifeController : ControllerBase
    {
        private readonly ISocialLifeService _socialLifeService;
        public SocialLifeController(ISocialLifeService socialLifeService)
        {
            _socialLifeService = socialLifeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_socialLifeService.GetList());
        }
        [HttpGet("GetActivesById")]
        public IActionResult GetActivesById(int id)
        {
            return Ok(_socialLifeService.GetActivesById(id));
        }
        [HttpGet("GetActives")]
        public IActionResult GetActives(int CompanyID)
        {
            return Ok(_socialLifeService.GetActives(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_socialLifeService.GetById(ID));
        }
        [HttpGet("GetByFormId")]
        public IActionResult GetByFormId(int ID)
        {
            return Ok(_socialLifeService.GetByFormId(ID));
        }
        [HttpPost("add")]
        public IActionResult Add(SocialLife socialLife)
        {
            socialLife.CreatedDate = DateTime.Now;
            socialLife.Status = 1;
            return Ok(_socialLifeService.Add(socialLife));
        }
        [HttpPost("update")]
        public IActionResult Update(SocialLife socialLife) {


            var test = _socialLifeService.GetByFormId((int)socialLife.FormID);
            socialLife.ID = test.ID;
           socialLife.ModifiedDate = DateTime.Now;
            socialLife.Status = 2;
            socialLife.CompanyID = test.CompanyID;
            socialLife.CreatedDate = test.CreatedDate;
            #region
            //eğer adam sıgara içmadiyse bilgiler bu şekilde güncellenecek
            if (socialLife.SmokeStatus == "N/A" || socialLife.SmokeStatus == "N0" || socialLife.SmokeStatus == "neverused ")
            {
                socialLife.SmokeAmount = "N/A";
                socialLife.SmokeCurrentStatus = "N/A";
                socialLife.QuitSmokingDate = new DateTime(1900, 01, 01);
                socialLife.SmokeType = "N/A";
            }
            //eğer adam halen sıgara içiyorsa bırakma tarihi 
            if (socialLife.SmokeStatus == "Current Smoker")
            {
                socialLife.QuitSmokingDate = new DateTime(1900, 01, 01);
            }
            //eğer adam sıgara içip bıraktıysa
            if (socialLife.SmokeStatus == "Former smoker ")
            {
                socialLife.SmokeAmount = "N/A";
                socialLife.SmokeCurrentStatus = "N/A";
                socialLife.SmokeType = "N/A";
            }
#endregion
            #region ALCOHOL USAGE
            // eğer adam alkol kullanmadıysa alcol  bilgiler bu şekilde güncellenecek
            if (socialLife.AlcoholStatus == "N/A" || socialLife.AlcoholStatus == "N0" || socialLife.AlcoholStatus == "NeverUsed ")
            {
                socialLife.AlcoholAmount = "N/A";
                socialLife.AlcoholCurrentStatus = "N/A";
                socialLife.QuitAlcoholingDate = new DateTime(1900, 01, 01);
                socialLife.AlcoholType = "N/A";
            }
            //eğer adam halen alkol kullanıyorsa bırakma tarihi  bilgiler bu şekilde güncellenecek
            if (socialLife.AlcoholStatus == "Current")
            {
                socialLife.QuitAlcoholingDate = new DateTime(1900, 01, 01);
            }
            //eğer adam alcol kullanıp bıraktıysa bilgiler bu şekilde güncellenecek
            if (socialLife.AlcoholStatus == "Former")
            {
                socialLife.AlcoholAmount = "N/A";
                socialLife.AlcoholCurrentStatus = "N/A";
                socialLife.AlcoholType = "N/A";
            }
            #endregion
            #region DRUG USAGE
            //ilaç kullanmadıysa  bilgiler bu şekilde güncellenecek
            if (socialLife.DrugStatus == "N/A" || socialLife.DrugStatus == "N0" || socialLife.DrugStatus == "NeverUsed")
            {
                socialLife.DrugAmount = "N/A";
                socialLife.DrugCurrentStatus = "N/A";
                socialLife.DrugType = "N/A";
            }
            #endregion
            return Ok(_socialLifeService.Update(socialLife));
        }
        [HttpPost("delete")]
        public IActionResult Delete(SocialLife socialLife)
        {
            var test = _socialLifeService.GetByFormId((int)socialLife.FormID);
            socialLife.ID = test.ID;
            socialLife.ModifiedDate = test.ModifiedDate;
            socialLife.Status = 3;
            socialLife.CompanyID = test.CompanyID;
            socialLife.CreatedDate = test.CreatedDate;
            socialLife.DeletedDate = DateTime.Now;
            return Ok(_socialLifeService.Delete(socialLife));
        }
    }
}
