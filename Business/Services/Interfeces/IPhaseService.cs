using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IPhaseService
    {
        Phase GetById(int Id);
        List<Phase> GetList();
        List<Phase> GetActives(int CompanyID);
        Phase GetActivesById(int id);
        string Add(Phase phase);
        string Update(Phase phase);
        string Delete(Phase phase);
        object GetById();
    }
}
