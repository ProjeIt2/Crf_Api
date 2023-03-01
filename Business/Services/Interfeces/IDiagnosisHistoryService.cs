using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDiagnosisHistoryService
    {
        DiagnosisHistory GetById(int Id);
        List<DiagnosisHistory> GetList();
        List<DiagnosisHistory> GetActivesById(int CompanyID);
        string Add(DiagnosisHistory diagnosisHistory);
        string Update(DiagnosisHistory diagnosisHistory);
        string Delete(DiagnosisHistory diagnosisHistory);
        object GetById();
    }
}
