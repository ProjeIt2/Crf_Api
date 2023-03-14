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

    public class TumorStatusRepository : EntityRepositoryBase<TumorStatus, ProjeItContext>, ITumorStatusRepository
    {

        public List<TumorStatusVM> GetListTumorStatuss(int FormID)
        {
            var _result = new List<TumorStatusVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _tumStat in context.TumorStatus.Where(x => x.FormID == FormID)
                         join _form in context.Forms on _tumStat.FormID equals _form.ID
                              join _tumArea in context.TumorAreas on _tumStat.TumorAreaID equals _tumArea.ID
                              join _tnm in context.TNMs on _tumStat.TNMID equals _tnm.ID
                              join _tumTyp in context.TumorTypes on _tumStat.TumorTypeID equals _tumTyp.ID
                              join _phase in context.Phases on _tumStat.PhaseID equals _phase.ID
                              select new TumorStatusVM
                              {
                                  ID = _tumStat.ID,
                                  FormID = _tumStat.FormID,
                                  Barcode = _form.Barcode,
                                  TumorSize= _tumStat.TumorSize,
                                  TumorPercent= _tumStat.TumorPercent,
                                  NecrosisPercent = _tumStat.NecrosisPercent,
                                  Grade = _tumStat.Grade,
                                  TumorPrimary = _tumStat.TumorPrimary,
                                   TumorDate = _tumStat.TumorDate,
                                  TumorClock = _tumStat.TumorClock,
                                  ExcisiontimeHours = _tumStat.ExcisiontimeHours,
                                TumorAreaID = _tumArea.ID,
                                  Tumor_Area = _tumArea.Tumor_Area,
                                  TNMID = _tnm.ID,
                                  TTNM = _tnm.TTNM,
                                  TumorTypeID = _tumTyp.ID,
                                  Tumor_Type = _tumTyp.Tumor_Type,
                                  PhaseID = _phase.ID,
                                  PhaseName = _phase.Name,

                              }).ToList();

                _result = result;


            }
            return _result;
        }
        public TumorStatusVM GetListTumorStatussID(int id)
        {
            var _result = new TumorStatusVM();
            using (var context = new ProjeItContext())
            {
                var result = (from _tumStat in context.TumorStatus.Where(x => x.ID == id)
                              join _form in context.Forms on _tumStat.FormID equals _form.ID
                              join _tumArea in context.TumorAreas on _tumStat.TumorAreaID equals _tumArea.ID
                              join _tnm in context.TNMs on _tumStat.TNMID equals _tnm.ID
                              join _tumTyp in context.TumorTypes on _tumStat.TumorTypeID equals _tumTyp.ID
                              join _phase in context.Phases on _tumStat.PhaseID equals _phase.ID
                              select new TumorStatusVM
                              {
                                  ID = _tumStat.ID,
                                  FormID = _tumStat.FormID,
                                  Barcode = _form.Barcode,
                                  TumorSize = _tumStat.TumorSize,
                                  TumorPercent = _tumStat.TumorPercent,
                                  NecrosisPercent = _tumStat.NecrosisPercent,
                                  Grade = _tumStat.Grade,
                                  TumorPrimary = _tumStat.TumorPrimary,
                                  TumorDate = _tumStat.TumorDate,
                                  TumorClock = _tumStat.TumorClock,
                                  ExcisiontimeHours = _tumStat.ExcisiontimeHours,
                                  TumorAreaID = _tumArea.ID,
                                  Tumor_Area = _tumArea.Tumor_Area,
                                  TNMID = _tnm.ID,
                                  TTNM = _tnm.TTNM,
                                  TumorTypeID = _tumTyp.ID,
                                  Tumor_Type = _tumTyp.Tumor_Type,
                                  PhaseID = _phase.ID,
                                  PhaseName = _phase.Name,

                              }).FirstOrDefault();

                _result = result;


            }
            return _result;
        }
    }
}
