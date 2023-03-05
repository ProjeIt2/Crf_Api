using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IViralInfectionService
    {
        ViralInfection GetById(int Id);
        List<ViralInfection> GetList();
        List<ViralInfection> GetActives(int CompanyID);
        ViralInfection GetActivesById(int id);
        List<ViralInfectionVM> GetListViralInfections(int FormID);
        string Add(ViralInfection viralInfection);
        string Update(ViralInfection viralInfection);
        string Delete(ViralInfection viralInfection);
        object GetById();
    }
}
