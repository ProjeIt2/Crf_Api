using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDiagnosisService
    {
        Diagnosis GetById(int Id);
        List<Diagnosis> GetList();
        List<Diagnosis> GetActives(int CompanyID);
        Diagnosis GetActivesById(int id);
        string Add(Diagnosis diagnosis);
        string Update(Diagnosis diagnosis);
        string Delete(Diagnosis diagnosis);
        object GetById();
    }
}
