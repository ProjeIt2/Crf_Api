using Business.Services.Interfeces;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : Controller
    {
        private readonly IUploadFileService _uploadFileService;
        public UploadFileController(IUploadFileService uploadFileService)
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
            int CompanyID = 2;
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
        public IActionResult Add([FromForm] UploadFileVM uploadFile
            //IFormFile formFile, int formId
            )
        {
            var UF = new UploadFile();

            if (uploadFile.FilePickerResults != null)
            {
               

                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", uploadFile.FilePickerResults.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    uploadFile.FilePickerResults.CopyTo(stream);
                }
               
                UF.FormID = uploadFile.FormID;
                UF.CreatedDate = DateTime.Now;
                UF.Status = 1;
                UF.CompanyID = 2;
                UF.UploadFileName = uploadFile.FilePickerResults.FileName;
                UF.UploadPath = path;
            }
            else if(uploadFile.imageItem != null)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", uploadFile.imageItem.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    uploadFile.imageItem.CopyTo(stream);
                }

                UF.FormID = uploadFile.FormID;
                UF.CreatedDate = DateTime.Now;
                UF.Status = 1;
                UF.CompanyID = 2;
                UF.UploadFileName = uploadFile.imageItem.FileName;
                UF.UploadPath = path;
            }
            else
            {
                return BadRequest("File not found");
            }
        
            return Ok(_uploadFileService.Add(UF));
        }
        [HttpPost("update")]
        public IActionResult Update(UploadFile uploadFile)
        {
            return Ok(_uploadFileService.Update(uploadFile));
        }
        [HttpPost("delete")]
        public IActionResult Delete(UploadFile uploadFile)
        {
            return Ok(_uploadFileService.Delete(uploadFile));
        }
    }
}
