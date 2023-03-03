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
    public class DonorMedicalHistoryRepository : EntityRepositoryBase<DonorMedicalHistory, ProjeItContext>, IDonorMedicalHistoryRepository
    {

        public List<DonorMedicalHistoryVM> GetListDonorMedicalHistorys(int FormID)
        {
            var _result = new List<DonorMedicalHistoryVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _donMedHis in context.DonorMedicalHistories.Where(x => x.FormID == FormID)
                              join _disease in context.Diseases on _donMedHis.DiseaseID equals _disease.ID
                              join _form in context.Forms on _donMedHis.FormID equals _form.ID
                              join _diagHis in context.DiagnosisHistories on _donMedHis.DiagnosisHistoryID equals _diagHis.ID
                              join _medStat in context.MedicalStatus on _donMedHis.MedicalStatusID equals _medStat.ID
                              join _icd in context.ICD10Code on _donMedHis.ICD10CodeID equals _icd.ID
                              select new DonorMedicalHistoryVM
                              {
                                  ID = _donMedHis.ID,
                                  FormID= _donMedHis.FormID,
                                  Barcode = _form.Barcode,
                                  DiagnosisHistoryDate = _donMedHis.DiagnosisHistoryDate,
                                  DiseaseID= _disease.ID,
                                  DiseaseName = _disease.DiseaseName,
                                  Diagnosis_History = _diagHis.Diagnosis_History,
                                  Medical_Status = _medStat.Medical_Status,
                                  MedicalStatusID = _medStat.ID,
                                  ICD10_Code = _icd.ICD10_Code,
                                  ICD10CodeID= _icd.ID,
                              }).ToList();

                _result = result;


            }
            return _result;
        }

    }
}
