using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IGynecologicalHistoryService
    {
        GynecologicalHistory GetById(int Id);
        List<GynecologicalHistory> GetList();
        List<GynecologicalHistory> GetActives(int CompanyID);
        GynecologicalHistory GetActivesById(int id);
        string Add(GynecologicalHistory gynecologicalHistory);
        string Update(GynecologicalHistory gynecologicalHistory);
        string Delete(GynecologicalHistory gynecologicalHistory);
        object GetById();
    }
}
