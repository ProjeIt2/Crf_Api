using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IAdditionTypeService
    {
        AdditionType GetById(int Id);
        List<AdditionType> GetList();
        List<AdditionType> GetActives(int CompanyID);
        AdditionType GetActivesById(int id);
        string Add(AdditionType additionType);
        string Update(AdditionType additionType);
        string Delete(AdditionType additionType);
        object GetById();
    }
}
