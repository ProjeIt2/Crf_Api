using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDiseaseService
    {
        Disease GetById(int Id);
        List<Disease> GetList();
        List<Disease> GetActives(int CompanyID);
        Disease GetActivesById(int id);
        string Add(Disease disease);
        string Update(Disease disease);
        string Delete(Disease disease);
        object GetById();
    }
}
