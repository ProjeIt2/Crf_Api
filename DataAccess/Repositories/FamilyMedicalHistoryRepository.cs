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

    public class FamilyMedicalHistoryRepository : EntityRepositoryBase<FamilyMedicalHistory, ProjeItContext>, IFamilyMedicalHistoryRepository
    {

        public List<FamilyMedicalHistoryVM> GetListFamilyMedicalHistorys(int FormID)
        {
            var _result = new List<FamilyMedicalHistoryVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _famMedHis in context.FamilyMedicalHistories.Where(x => x.FormID == FormID)
                         join _form in context.Forms on _famMedHis.FormID equals _form.ID
                              join _diagHis in context.Diagnosis on _famMedHis.DiagnosisID equals _diagHis.ID
                              join _affStat in context.Affinities on _famMedHis.AffinityID equals _affStat.ID

                              select new FamilyMedicalHistoryVM
                              {
                                  ID = _famMedHis.ID,
                                  FormID = _famMedHis.FormID,
                                  Barcode = _form.Barcode,
                                  DiagnosisHistoryDate = _famMedHis.DiagnosisDate,
                                  DiseaseID = _diagHis.ID,
                                  DiseaseName = _diagHis.DiagnosisName,
                                  AffinityType = _affStat.AffinityType,
                                  AffinityID = _affStat.ID,

                              }).ToList();

                _result = result;


            }
            return _result;
        }

    }
}
