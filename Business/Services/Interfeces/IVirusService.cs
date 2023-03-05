using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IVirusService
    {
        Virus GetById(int Id);
        List<Virus> GetList();
        List<Virus> GetActives(int CompanyID);
        Virus GetActivesById(int id);
        string Add(Virus virus);
        string Update(Virus virus);
        string Delete(Virus virus);
        object GetById();
    }
}
