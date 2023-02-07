using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITüpCinsService
    {
        TüpCins GetById(int Id);
        List<TüpCins> GetList();
        string Add(TüpCins tüpCins);
        string Update(TüpCins tüpCins);
        string Delete(TüpCins tüpCins);
        object GetById();
    }
}
