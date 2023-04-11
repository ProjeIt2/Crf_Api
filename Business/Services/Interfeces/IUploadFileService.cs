using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IUploadFileService
    {
        UploadFile GetById(int Id);
        List<UploadFile> GetList();
        List<UploadFile> GetActives(int CompanyID);
        List<UploadFile> GetActivesFormID(int FormID);
        List<UploadFile> GetFileNames(string FileName);
       UploadFile GetFileName(string FileName);
        UploadFile GetActivesById(int id);
        string Add(UploadFile uploadFile);
        string Update(UploadFile uploadFile);
        string Delete(UploadFile uploadFile);
        object GetById();
    }
}
