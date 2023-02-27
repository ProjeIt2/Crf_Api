using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IHospitalService
    {
        Hospital GetById(int Id);
        List<Hospital> GetList();
        List<Hospital> GetActivesById(int CompanyID);
      
        string Add(Hospital kullanici);
        string Update(Hospital kullanici);
        string Delete(Hospital kullanici);
        object GetById();
    }
}
