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

    public class ClinicalStatusRepository : EntityRepositoryBase<ClinicalStatus, ProjeItContext>, IClinicalStatusRepository
    {

        public List<ClinicalStatusVM> GetListClinicalStatuss(int FormID,int CompanyID)
        {
            var _result = new List<ClinicalStatusVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _clinStat in context.ClinicalStatus.Where(x => x.FormID == FormID&&x.CompanyID==CompanyID&&x.Status!=3)
                              join _form in context.Forms on _clinStat.FormID equals _form.ID
                              join _tumArea in context.TumorAreas on _clinStat.TumorAreaID equals _tumArea.ID
                              join _tnm in context.TNMs on _clinStat.TNMID equals _tnm.ID
                              join _tumTyp in context.TumorTypes on _clinStat.TumorTypeID equals _tumTyp.ID
                              join _phase in context.Phases on _clinStat.PhaseID equals _phase.ID into gj
                              from x in gj.DefaultIfEmpty()
                              join _docReqRep in context.DoctorRequestedReports on _clinStat.DoctorRequestedReportID equals _docReqRep.ID
                              join _rep in context.Reports on _docReqRep.ReportID equals _rep.ID
                              select new ClinicalStatusVM
                              {
                                  ID = _clinStat.ID,
                                  FormID = _clinStat.FormID,
                                  Barcode = _form.Barcode,
                                  TumorSize = _clinStat.TumorSize,
                                  TumorAreaID = _tumArea.ID,
                                  Tumor_Area = _tumArea.Tumor_Area,
                                  TNMID = _tnm.ID,
                                  TTNM = _tnm.TTNM,
                                  TumorTypeID = _tumTyp.ID,
                                  Tumor_Type = _tumTyp.Tumor_Type,
                                  PhaseID = x != null ? x.ID : 0,
                                  PhaseName = x != null ? x.Name : "N/A",
                                  DoctorRequestedReportID = _docReqRep.ID,
                                  ReportName = _rep.Name,
                              }).ToList();

                _result = result;


            }
            return _result;
        }


        public ClinicalStatusVM GetListClinicalStatu(int id, int CompanyID)
        {
            var _result = new ClinicalStatusVM();
            using (var context = new ProjeItContext())
            {
                var result = (from _clinStat in context.ClinicalStatus.Where(x => x.ID == id && x.CompanyID == CompanyID && x.Status != 3)
                              join _form in context.Forms on _clinStat.FormID equals _form.ID
                              join _tumArea in context.TumorAreas on _clinStat.TumorAreaID equals _tumArea.ID
                              join _tnm in context.TNMs on _clinStat.TNMID equals _tnm.ID
                              join _tumTyp in context.TumorTypes on _clinStat.TumorTypeID equals _tumTyp.ID
                              join _phase in context.Phases on _clinStat.PhaseID equals _phase.ID into gj
                              from x in gj.DefaultIfEmpty()
                              join _docReqRep in context.DoctorRequestedReports on _clinStat.DoctorRequestedReportID equals _docReqRep.ID
                              join _rep in context.Reports on _docReqRep.ReportID equals _rep.ID
                              select new ClinicalStatusVM
                              {
                                  ID = _clinStat.ID,
                                  FormID = _clinStat.FormID,
                                  Barcode = _form.Barcode,
                                  TumorSize = _clinStat.TumorSize,
                                  TumorAreaID = _tumArea.ID,
                                  Tumor_Area = _tumArea.Tumor_Area,
                                  TNMID = _tnm.ID,
                                  TTNM = _tnm.TTNM,
                                  TumorTypeID = _tumTyp.ID,
                                  Tumor_Type = _tumTyp.Tumor_Type,
                                  PhaseID = x != null ? x.ID : 0,
                                  PhaseName = x != null ? x.Name : "N/A",
                                  DoctorRequestedReportID = _docReqRep.ID,
                                  ReportName = _rep.Name,
                              }).FirstOrDefault();

                _result = result;


            }
            return _result;
        }
    }
}
