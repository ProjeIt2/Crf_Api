using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IAffinityService
    {
        Affinity GetById(int Id);
        List<Affinity> GetList();
        List<Affinity> GetActives(int CompanyID);
        Affinity GetActivesById(int id);
        string Add(Affinity affinity);
        string Update(Affinity affinity);
        string Delete(Affinity affinity);
        object GetById();
    }
}
