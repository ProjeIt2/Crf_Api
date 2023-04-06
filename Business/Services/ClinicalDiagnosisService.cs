using Business.Services.Interfeces;
using Core.Tools;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClinicalDiagnosisService : IClinicalDiagnosisService
    {
        private IClinicalDiagnosisRepository _clinicalDiagnosisRepository;
        public ClinicalDiagnosisService(IClinicalDiagnosisRepository clinicalDiagnosisRepository)
        {
            _clinicalDiagnosisRepository = clinicalDiagnosisRepository;
        }

        public ClinicalDiagnosis GetById(int Id)
        {
            return _clinicalDiagnosisRepository.Get(a => a.ID == Id);
        }
        public List<ClinicalDiagnosis> GetList()
        {
            return _clinicalDiagnosisRepository.GetList().ToList();
        }
        public List<ClinicalDiagnosis> GetActivesById(int CompanyID)
        {
            return _clinicalDiagnosisRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public string Add(ClinicalDiagnosis clinicalDiagnosis)
        {
            clinicalDiagnosis.CreatedDate = DateTime.Now;

            _clinicalDiagnosisRepository.Add(clinicalDiagnosis);
            return "Ok";
        }
        public string Update(ClinicalDiagnosis clinicalDiagnosis)
        {
            var User = _clinicalDiagnosisRepository.Get(a => a.ID== clinicalDiagnosis.ID);
            clinicalDiagnosis.CreatedDate = User.CreatedDate;
            clinicalDiagnosis.ModifiedDate = DateTime.Now;
            clinicalDiagnosis.Status = 2;
            _clinicalDiagnosisRepository.Update(clinicalDiagnosis);
            return "Ok";
        }
        public string Delete(ClinicalDiagnosis clinicalDiagnosis)
        {
            var User = _clinicalDiagnosisRepository.Get(a => a.ID == clinicalDiagnosis.ID);
            clinicalDiagnosis.CreatedDate = User.CreatedDate;
            clinicalDiagnosis.ModifiedDate = User.ModifiedDate;
            clinicalDiagnosis.DeletedDate = DateTime.Now;
            clinicalDiagnosis.Status = 3;
            _clinicalDiagnosisRepository.Update(clinicalDiagnosis);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
