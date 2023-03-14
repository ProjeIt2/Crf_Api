using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITreatmentService
    {
        Treatment GetById(int Id);
        List<Treatment> GetList();
        List<Treatment> GetActives(int CompanyID);
        Treatment GetActivesById(int id);
        string Add(Treatment treatment);
        string Update(Treatment treatment);
        string Delete(Treatment treatment);
        object GetById();
    }
}
