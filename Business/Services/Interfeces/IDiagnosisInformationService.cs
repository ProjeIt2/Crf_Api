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
        List<DiagnosisInformation> GetActivesById(int CompanyID);
        List<DiagnosisInformationVM> GetListDiagnosisInformations(int FormID);
        string Add(DiagnosisInformation diagnosisInformation);
        string Update(DiagnosisInformation diagnosisInformation);
        string Delete(DiagnosisInformation diagnosisInformation);
        object GetById();
    }
}
