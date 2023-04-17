using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITaskUploadFileService
    {
        TaskUploadFile GetById(int Id);
        List<TaskUploadFile> GetList();
        List<TaskUploadFile> GetActives(int CompanyID);
        List<TaskUploadFile> GetActivesFormID(int TaskID);
        List<TaskUploadFile> GetFileNames(string FileName);
       TaskUploadFile GetFileName(string FileName);
        TaskUploadFile GetActivesById(int id);
        string Add(TaskUploadFile taskUploadFile);
        string Update(TaskUploadFile taskUploadFile);
        string Delete(TaskUploadFile taskUploadFile);
        object GetById();
    }
}
