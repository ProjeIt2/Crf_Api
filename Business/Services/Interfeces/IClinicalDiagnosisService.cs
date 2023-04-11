using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IClinicalDiagnosisService
    {
        ClinicalDiagnosis GetById(int Id);
        List<ClinicalDiagnosis> GetList();
        ClinicalDiagnosis GetActivesById(int id);
        List<ClinicalDiagnosis> GetActives(int CompanyID);
        string Add(ClinicalDiagnosis clinicalDiagnosis);
        string Update(ClinicalDiagnosis clinicalDiagnosis);
        string Delete(ClinicalDiagnosis clinicalDiagnosis);
        object GetById();
    }
}
