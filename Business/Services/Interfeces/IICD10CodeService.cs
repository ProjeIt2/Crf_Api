using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IICD10CodeService
    {
        ICD10Code GetById(int Id);
        List<ICD10Code> GetList();
        List<ICD10Code> GetActives(int CompanyID);
        ICD10Code GetActivesById(int CompanyID);
        string Add(ICD10Code iCD10Code);
        string Update(ICD10Code iCD10Code);
        string Delete(ICD10Code iCD10Code);
        object GetById();
    }
}
