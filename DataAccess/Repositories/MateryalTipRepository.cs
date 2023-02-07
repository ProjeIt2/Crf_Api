using Core;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MateryalTipRepository : EntityRepositoryBase<MateryalTip, ProjeItContext>, IMateryalTipRepository
    {
    }
}
