using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDoctorService
    {
        Doctor GetById(int Id);
        List<Doctor> GetList();
        List<Doctor> GetActivesById(int CompanyID);
      
        string Add(Doctor personnel);
        string Update(Doctor personnel);
        string Delete(Doctor personnel);
        object GetById();
    }
}
