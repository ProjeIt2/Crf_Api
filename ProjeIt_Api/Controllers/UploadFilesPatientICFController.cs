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
    public class UploadFilesPatientICFController : Controller
    {
        private readonly IUploadFilesPatientICFService _uploadFileService;
        public UploadFilesPatientICFController(IUploadFilesPatientICFService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_uploadFileService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_uploadFileService.GetActives((int)CompanyID));
        }

        [HttpGet("getActivesFormID")]
        public IActionResult GetActivesFormID(int FormID)
        {
           
            return Ok(_uploadFileService.GetActivesFormID((int)FormID));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_uploadFileService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_uploadFileService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(UploadFilesPatientICF uploadFile)
        {
            uploadFile.CreatedDate = DateTime.Now;
            uploadFile.Status = 1;
            uploadFile.CompanyID = 2;
            uploadFile.UploadPath = "~//UploadFile/" + uploadFile.UploadFileName;
            return Ok(_uploadFileService.Add(uploadFile));
        }
        [HttpPost("update")]
        public IActionResult Update(UploadFilesPatientICF uploadFile)
        {
            var test = _uploadFileService.GetActivesById(uploadFile.ID);

            uploadFile.ModifiedDate = DateTime.Now;
            uploadFile.Status = 2;
            uploadFile.CompanyID = test.CompanyID;
            uploadFile.CreatedDate = test.CreatedDate;
            return Ok(_uploadFileService.Update(uploadFile));
        }
        [HttpPost("delete")]
        public IActionResult Delete(UploadFilesPatientICF uploadFile)
        {
            var test = _uploadFileService.GetActivesById(uploadFile.ID);

            uploadFile.ModifiedDate = test.ModifiedDate;
            uploadFile.Status = 3;
            uploadFile.CompanyID = test.CompanyID;
            uploadFile.CreatedDate = test.CreatedDate;
            uploadFile.DeletedDate = DateTime.Now;
            return Ok(_uploadFileService.Delete(uploadFile));
        }
    }
}
