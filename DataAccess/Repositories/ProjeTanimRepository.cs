using Core;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProjeTanimRepository : EntityRepositoryBase<ProjeTanim, ProjeItContext>, IProjeTanimRepository
    {
        public List<ProjeTanimDto> GetListProje()
        {
            using (var db = new ProjeItContext())

            {
                return db.ProjeTanimDtoQuery.FromSqlRaw($"EXEC  [dbo].[GetListProje] ").ToList();
            }
        }
    }
}
