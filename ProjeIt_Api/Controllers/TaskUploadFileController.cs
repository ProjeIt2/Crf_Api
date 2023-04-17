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
    public class TaskUploadFileController : Controller
    {
        private readonly ITaskUploadFileService _taskUploadFileService;

        public TaskUploadFileController(ITaskUploadFileService taskUploadFileService)
        {
            _taskUploadFileService = taskUploadFileService;
        }
     

        
         
        
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_taskUploadFileService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives(int CompanyID)
        {

            return Ok(_taskUploadFileService.GetActives((int)CompanyID));
        }

        [HttpGet("getActivesFormID")]
        public IActionResult GetActivesFormID(int FormID)
        {

            return Ok(_taskUploadFileService.GetActivesFormID((int)FormID));
        }
        [HttpGet("getFileNames")]
        public IActionResult GetFileNames(string FileName)
        {

            return Ok(_taskUploadFileService.GetFileNames(FileName));
        }

        [HttpGet("getFileName")]
        public IActionResult GetFileName(string FileName)
        {

            return Ok(_taskUploadFileService.GetFileName(FileName));
        }
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_taskUploadFileService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_taskUploadFileService.GetById(ID));
        }
        private const string ContentType = "application/octet-stream";
        [HttpGet("dowloand")]
        public IActionResult Download(string filename)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TaskUploadFile", filename);
            var file = _taskUploadFileService.GetList().Where(x => x.UploadFileName == filename).FirstOrDefault();
            //var filePath = Path.Combine("TaskUploadFile", filename);
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
            //görüntülenecek dosyanın yolu isimden yakalanıp görüntülenmesi için yazıldı
            var file = _taskUploadFileService.GetList().Where(x => x.UploadFileName == filename).FirstOrDefault();
            if (!System.IO.File.Exists(file.UploadPath))
            {
                return NotFound();
            }
            var stream = new FileStream(file.UploadPath, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }
        [HttpGet("fileImagename")]
  
        [HttpPost("add")]
        public IActionResult Add([FromForm] TaskUploadFielVM taskUploadFile
            //IFormFile formFile, int formId
            )
        {
            var UF = new TaskUploadFile();
            if (taskUploadFile != null)
            {
                //dosya isminden dosya yakalanacağı için dosya isminde benzerlik ve hata olmaması için dosya ismi guis değerlere set edildi
                var guid = Guid.NewGuid().ToString();
            //eklenecek dosyanın eklentisi alındı
            //webde bulunan dosyanın yolu
            //D:\vhosts\crfhubspot.com\httpdocs\TaskUploadFile\
                ////D:\vhosts\crfhubspot.com\httpdocs\TaskUploadFile\
                //Api localde kaydedince gelen yol
                //D:\Projects\ProjeIt\Crf_Api\Crf_Api\ProjeIt_Api\TaskUploadFile
                var fileExtension = Path.GetExtension(taskUploadFile.FilePickerResults.FileName);
                //var path = @"d:\vhosts\crfhubspot.com\httpdocs\uploadfile\" + guid + fileExtension;
                //var ServerSavePath = Path.Combine(Server.MapPath("~//TaskUploadFile/") + InputFileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile", guid + fileExtension);
                //string path = Path.Combine(Directory.GetCurrentDirectory(), "~//httpdocs/TaskUploadFile/", guid + fileExtension);
                //string path = Path.Combine("httpdocs/TaskUploadFile", guid + fileExtension);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    taskUploadFile.FilePickerResults.CopyTo(stream);
                }
                //değerler set edildi
                UF.TaskSystemID = taskUploadFile.TaskSystemID;
                UF.CreatedDate = DateTime.Now;
                UF.Status = 1;
                UF.CompanyID = 2;
                UF.UploadFileName =  guid+ fileExtension;
                UF.UploadPath = path;
            }
                  else
            {
                return BadRequest("File not found");
            }

            return Ok(_taskUploadFileService.Add(UF));
        }
        [HttpPost("update")]
        public IActionResult Update(TaskUploadFile taskUploadFile)
        {
            return Ok(_taskUploadFileService.Update(taskUploadFile));
        }
        [HttpPost("delete")]
        public IActionResult Delete(TaskUploadFile taskUploadFile)
        {
            return Ok(_taskUploadFileService.Delete(taskUploadFile));
        }
    }
}
