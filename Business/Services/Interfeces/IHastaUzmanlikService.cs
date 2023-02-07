using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IHastaUzmanlikService
    {
        HastaUzmanlik GetById(int Id);
        List<HastaUzmanlik> GetList();
        string Add(HastaUzmanlik hastaUzmanlik);
        string Update(HastaUzmanlik hastaUzmanlik);
        string Delete(HastaUzmanlik hastaUzmanlik);
        object GetById();
    }
}
