using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IAnatomicalAreaService
    {
        AnatomicalArea GetById(int Id);
        List<AnatomicalArea> GetList();
        List<AnatomicalArea> GetActives(int CompanyID);
        AnatomicalArea GetActivesById(int id);
        string Add(AnatomicalArea anatomicalArea);
        string Update(AnatomicalArea anatomicalArea);
        string Delete(AnatomicalArea anatomicalArea);
        object GetById();
    }
}
