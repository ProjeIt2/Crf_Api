using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ISpecimenService
    {
        Specimen GetById(int Id);
        List<Specimen> GetList();
        List<Specimen> GetActives(int CompanyID);
        Specimen GetActivesById(int id);
        List<SpecimenVM> GetListSpecimens(int FormID);
        SpecimenVM GetListSpecimensID(int id);
        string Add(Specimen specimen);
        string Update(Specimen specimen);
        string Delete(Specimen specimen);
        object GetById();
    }
}
