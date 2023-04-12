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
        public IActionResult GetActives(int CompanyID)
        {

            return Ok(_uploadFileService.GetActives((int)CompanyID));
        }

        [HttpGet("getActivesFormID")]
        public IActionResult GetActivesFormID(int FormID)
        {

            return Ok(_uploadFileService.GetActivesFormID((int)FormID));
        }
        [HttpGet("getFileNames")]
        public IActionResult GetFileNames(string FileName)
        {

            return Ok(_uploadFileService.GetFileNames(FileName));
        }

        [HttpGet("getFileName")]
        public IActionResult GetFileName(string FileName)
        {

            return Ok(_uploadFileService.GetFileName(FileName));
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
        private const string ContentType = "application/octet-stream";
        [HttpGet("dowloand")]
        public IActionResult Download(string filename)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", filename);
            var file = _uploadFileService.GetList().Where(x => x.UploadFileName == filename).FirstOrDefault();
            //var filePath = Path.Combine("UploadFile", filename);
            //var filePath = file.UploadPath;
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            var fileInfo = new FileInfo(filePath);
            var response = new FileStreamResult(fileStream, ContentType)
            {
                FileDownloadName = fileInfo.Name
            };
            return response;
        }
        [HttpGet("GetFileWithName")]
        public IActionResult GetFileWithName(string filename)
        {
            var file = _uploadFileService.GetList().Where(x => x.UploadFileName == filename).FirstOrDefault();
            if (!System.IO.File.Exists(file.UploadPath))
            {
                return NotFound();
            }
            var stream = new FileStream(file.UploadPath, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] UploadFileVM uploadFile
            //IFormFile formFile, int formId
            )
        {
            var UF = new UploadFile();
            if (uploadFile.FilePickerResults != null)
            {
                var guid = Guid.NewGuid().ToString();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", guid+".pdf");
                //string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", uploadFile.imagePath);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    uploadFile.FilePickerResults.CopyTo(stream);
                }
                //UF.FormID = Convert.ToInt32(uploadFile.FilePickerResults.FileName);
                UF.FormID = uploadFile.FormID;
                UF.CreatedDate = DateTime.Now;
                UF.Status = 1;
                UF.CompanyID = 2;
                UF.UploadFileName =  guid+".pdf" ;
                UF.UploadPath = path;
            }
            else if (uploadFile.imageItem != null)
            {
                var guid = Guid.NewGuid().ToString();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", guid + ".pdf");
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    uploadFile.imageItem.CopyTo(stream);
                }

                UF.FormID = uploadFile.FormID;
                UF.CreatedDate = DateTime.Now;
                UF.Status = 1;
                UF.CompanyID = 2;
                UF.UploadFileName = guid ;
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
