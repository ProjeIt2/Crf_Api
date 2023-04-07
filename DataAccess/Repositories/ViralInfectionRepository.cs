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

    public class ViralInfectionRepository : EntityRepositoryBase<ViralInfection, ProjeItContext>, IViralInfectionRepository
    {

        public List<ViralInfectionVM> GetListViralInfections(int FormID)
        {
            var _result = new List<ViralInfectionVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _viralEnf in context.ViralInfections.Where(x => x.FormID == FormID&&x.Status!=3)
                              join _form in context.Forms on _viralEnf.FormID equals _form.ID
                              join _virus in context.Virus on _viralEnf.VirusID equals _virus.ID


                              select new ViralInfectionVM
                              {
                                  ID = _viralEnf.ID,
                                  TestStatus = _viralEnf.TestStatus,
                                  Status=_viralEnf.Status,
                                  Result = _viralEnf.Result,
                                  FormID = _viralEnf.FormID,
                                  Barcode = _form.Barcode,
                                  VirusID = _virus.ID,
                                  VirusName = _virus.VirusName,

                              }).ToList();

                _result = result;


            }
            return _result;
        }

    }
}
