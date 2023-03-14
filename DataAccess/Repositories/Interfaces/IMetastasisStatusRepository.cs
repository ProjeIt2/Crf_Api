using Core;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMetastasisStatusRepository : IEntityRepository<MetastasisStatus>
    {
        List<MetastasisStatusVM> GetListMetastasisStatuss(int FormID);
        MetastasisStatusVM GetListMetastasisStatussID(int id);
    }
}
