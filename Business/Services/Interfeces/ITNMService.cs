using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITNMService
    {
        TNM GetById(int Id);
        List<TNM> GetList();
        List<TNM> GetActives(int CompanyID);
        TNM GetActivesById(int id);
        string Add(TNM tNM);
        string Update(TNM tNM);
        string Delete(TNM tNM);
        object GetById();
    }
}
