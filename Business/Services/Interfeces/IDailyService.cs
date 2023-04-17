using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDailyService
    {
        Daily GetById(int Id);
        List<Daily> GetList();
        List<Daily> GetActives(int CompanyID);
        Daily GetActivesById(int id);
        List<Daily> GetDailyMyVisite( int PersonnelID);
        string Add(Daily daily);
        string Update(Daily daily);
        string Delete(Daily daily);
        object GetById();
    }
}
