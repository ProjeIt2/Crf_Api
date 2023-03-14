using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IUploadFilesPatientICFService
    {
        UploadFilesPatientICF GetById(int Id);
        List<UploadFilesPatientICF> GetList();
        List<UploadFilesPatientICF> GetActives(int CompanyID);
        List<UploadFilesPatientICF> GetActivesFormID(int FormID);
        UploadFilesPatientICF GetActivesById(int id);
        string Add(UploadFilesPatientICF uploadFile);
        string Update(UploadFilesPatientICF uploadFile);
        string Delete(UploadFilesPatientICF uploadFile);
        object GetById();
    }
}
