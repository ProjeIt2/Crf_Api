using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITumorTypeService
    {
        TumorType GetById(int Id);
        List<TumorType> GetList();
        List<TumorType> GetActives(int CompanyID);
        TumorType GetActivesById(int id);
        string Add(TumorType tumorType);
        string Update(TumorType tumorType);
        string Delete(TumorType tumorType);
        object GetById();
    }
}
