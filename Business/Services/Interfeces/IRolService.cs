using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IRolService
    {
        Rol GetById(int Id);
        List<Rol> GetList();
        string Add(Rol rol);
        string Update(Rol rol);
        string Delete(Rol rol);
        object GetById();
    }
}
