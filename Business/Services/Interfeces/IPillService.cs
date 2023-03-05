using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IPillService
    {
        Pill GetById(int Id);
        List<Pill> GetList();
        List<Pill> GetActives(int CompanyID);
        Pill GetActivesById(int id);
        string Add(Pill pill);
        string Update(Pill pill);
        string Delete(Pill pill);
        object GetById();
    }
}
