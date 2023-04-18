using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IPersonnelService
    {
        Personnel GetById(int Id);
        List<Personnel> GetList();
        Personnel GetActivesById(int ID);
        List<Personnel> GetActives(int CompanyID);
        string Add(Personnel personnel);
        string Update(Personnel personnel);
        string Delete(Personnel personnel);
        object GetById();
    }
}
