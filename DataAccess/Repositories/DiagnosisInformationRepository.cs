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
    public class DiagnosisInformationRepository : EntityRepositoryBase<DiagnosisInformation, ProjeItContext>, IDiagnosisInformationRepository
    {

        public List<DiagnosisInformationVM> GetListDiagnosisInformations(int FormID)
        {
            var _result = new List<DiagnosisInformationVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _diagInfs in context.DiagnosisInformations.Where(x => x.FormID == FormID)
                              join _form in context.Forms on _diagInfs.FormID equals _form.ID
                              join _clinDiag in context.ClinicalDiagnosis on _diagInfs.ClinicalDiagnosisID equals _clinDiag.ID
                              join _icd in context.ICD10Code on _diagInfs.ICD10CodeID equals _icd.ID
                              select new DiagnosisInformationVM
                              {
                                  ID = _diagInfs.ID,
                                  FormID = _diagInfs.FormID,
                                  DiagnosisDate = _diagInfs.DiagnosisDate,
                                  Barcode = _form.Barcode,
                                  ClinicalDiagnosisID = _clinDiag.ID,
                                  DiagnosisName = _clinDiag.DiagnosisName,
                                  ICD10_Code = _icd.ICD10_Code,
                                  ICD10CodeID = _icd.ID,
                              }).ToList();

                _result = result;


            }
            return _result;
        }

    }
}
