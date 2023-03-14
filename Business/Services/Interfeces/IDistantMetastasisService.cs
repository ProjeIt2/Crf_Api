using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDistantMetastasisService
    {
        DistantMetastasis GetById(int Id);
        List<DistantMetastasis> GetList();
        List<DistantMetastasis> GetActives(int CompanyID);
        DistantMetastasis GetActivesById(int id);
        string Add(DistantMetastasis distantMetastasis);
        string Update(DistantMetastasis distantMetastasis);
        string Delete(DistantMetastasis distantMetastasis);
        object GetById();
    }
}
