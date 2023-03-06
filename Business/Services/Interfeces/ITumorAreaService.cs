using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITumorAreaService
    {
        TumorArea GetById(int Id);
        List<TumorArea> GetList();
        List<TumorArea> GetActives(int CompanyID);
        TumorArea GetActivesById(int id);
        string Add(TumorArea tumorArea);
        string Update(TumorArea tumorArea);
        string Delete(TumorArea tumorArea);
        object GetById();
    }
}
