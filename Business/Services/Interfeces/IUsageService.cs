using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IUsageService
    {
        Usage GetById(int Id);
        List<Usage> GetList();
        List<Usage> GetActives(int CompanyID);
        Usage GetActivesById(int id);
        string Add(Usage usage);
        string Update(Usage usage);
        string Delete(Usage usage);
        object GetById();
    }
}
