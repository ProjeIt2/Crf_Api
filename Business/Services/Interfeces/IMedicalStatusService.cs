using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IMedicalStatusService
    {
        MedicalStatus GetById(int Id);
        List<MedicalStatus> GetList();
        List<MedicalStatus> GetActives(int CompanyID);
        MedicalStatus GetActivesById(int id);
        string Add(MedicalStatus medicalStatus);
        string Update(MedicalStatus medicalStatus);
        string Delete(MedicalStatus medicalStatus);
        object GetById();
    }
}
