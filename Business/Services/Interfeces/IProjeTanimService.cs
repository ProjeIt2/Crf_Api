using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IProjeTanimService
    {
        ProjeTanim GetById(int Id);
        List<ProjeTanim> GetList();
        List<ProjeTanimDto> GetListProje();
        string Add(ProjeTanim projeTanim);
        string Update(ProjeTanim projeTanim);
        string Delete(ProjeTanim projeTanim);
        object GetById();
    }
}
