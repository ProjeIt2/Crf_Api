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

    public class CancerTreatmentRepository : EntityRepositoryBase<CancerTreatment, ProjeItContext>, ICancerTreatmentRepository
    {

        public List<CancerTreatmentVM> GetListCancerTreatments(int FormID)
        {
            var _result = new List<CancerTreatmentVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _cancTret in context.CancerTreatments.Where(x => x.FormID == FormID&&x.Status!=3)
                         join _form in context.Forms on _cancTret.FormID equals _form.ID
                              join _tret in context.Treatments on _cancTret.TreatmentID equals _tret.ID
                             

                              select new CancerTreatmentVM
                              {Status =_cancTret.Status,
                                  ID = _cancTret.ID,
                                  FormID = _cancTret.FormID,
                                  TreatmentStartDate= _cancTret.TreatmentStartDate,
                                  TreatmentEndDate= _cancTret.TreatmentEndDate,
                                  TreatmentResult= _cancTret.TreatmentResult,
                                  FromOfTreatment = _cancTret.FromOfTreatment,
                                  Barcode = _form.Barcode,
                                    TreatmentID = _tret.ID,
                                  TreatmentType = _tret.TreatmentType,
                              
                              }).ToList();

                _result = result;


            }
            return _result;
        }

        public CancerTreatmentVM GetListCancerTreatmentsID(int id)
        {
            var _result = new CancerTreatmentVM();
            using (var context = new ProjeItContext())
            {
                var result = (from _cancTret in context.CancerTreatments.Where(x => x.ID == id&&x.Status!=3)
                              join _form in context.Forms on _cancTret.FormID equals _form.ID
                              join _tret in context.Treatments on _cancTret.TreatmentID equals _tret.ID


                              select new CancerTreatmentVM
                              {
                                  ID = _cancTret.ID,
                                  FormID = _cancTret.FormID,
                                  TreatmentStartDate = _cancTret.TreatmentStartDate,
                                  TreatmentEndDate = _cancTret.TreatmentEndDate,
                                  TreatmentResult = _cancTret.TreatmentResult,
                                  FromOfTreatment = _cancTret.FromOfTreatment,
                                  Barcode = _form.Barcode,
                                  TreatmentID = _tret.ID,
                                  TreatmentType = _tret.TreatmentType,

                              }).FirstOrDefault();

                _result = result;


            }
            return _result;
        }

    }
}
