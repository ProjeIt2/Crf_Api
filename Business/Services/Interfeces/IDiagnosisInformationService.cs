using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDiagnosisInformationService
    {
        DiagnosisInformation GetById(int Id);
        List<DiagnosisInformation> GetList();
        List<DiagnosisInformation> GetActives(int CompanyID);
       DiagnosisInformation GetActivesById(int id);
        List<DiagnosisInformationVM> GetListDiagnosisInformations(int FormID);
        DiagnosisInformationVM GetListDiagnosisInformationsID(int id);
        string Add(DiagnosisInformation diagnosisInformation);
        string Update(DiagnosisInformation diagnosisInformation);
        string Delete(DiagnosisInformation diagnosisInformation);
        object GetById();
    }
}
