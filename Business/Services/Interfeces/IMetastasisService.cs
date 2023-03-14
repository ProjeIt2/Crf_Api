using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IMetastasisService
    {
        Metastasis GetById(int Id);
        List<Metastasis> GetList();
        List<Metastasis> GetActives(int CompanyID);
        Metastasis GetActivesById(int id);
        string Add(Metastasis metastasis);
        string Update(Metastasis metastasis);
        string Delete(Metastasis metastasis);
        object GetById();
    }
}
