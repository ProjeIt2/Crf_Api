using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IMetastasisStatusService
    {
        MetastasisStatus GetById(int Id);
        List<MetastasisStatus> GetList();
        List<MetastasisStatus> GetActives(int CompanyID);
        MetastasisStatus GetActivesById(int id);
        List<MetastasisStatusVM> GetListMetastasisStatuss(int FormID);
        MetastasisStatusVM GetListMetastasisStatussID(int id);
        string Add(MetastasisStatus metastasisStatus);
        string Update(MetastasisStatus metastasisStatus);
        string Delete(MetastasisStatus metastasisStatus);
        object GetById();
    }
}
