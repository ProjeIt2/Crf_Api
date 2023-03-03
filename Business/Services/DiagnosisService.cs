using Business.Services.Interfeces;
using DataAccess.Repositories.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class DiagnosisService : IDiagnosisService
    {
        private IDiagnosisRepository _diagnosisRepository;
        public DiagnosisService(IDiagnosisRepository diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }

        public Diagnosis GetById(int Id)
        {
            return _diagnosisRepository.Get(a => a.ID == Id);
        }
        public List<Diagnosis> GetList()
        {
            return _diagnosisRepository.GetList().ToList();
        }
        public List<Diagnosis> GetActives()
        {
            return _diagnosisRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public Diagnosis GetActivesById(int id)
        {
            return _diagnosisRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Diagnosis diagnosis)
        {
            diagnosis.CreatedDate = DateTime.Now;

            _diagnosisRepository.Add(diagnosis);
            return "Ok";
        }
        public string Update(Diagnosis diagnosis)
        {
            var User = _diagnosisRepository.Get(a => a.ID == diagnosis.ID);
            diagnosis.CreatedDate = User.CreatedDate;
            diagnosis.ModifiedDate = DateTime.Now;
            diagnosis.Status = 2;
            _diagnosisRepository.Update(diagnosis);
            return "Ok";
        }
        public string Delete(Diagnosis diagnosis)
        {
            var User = _diagnosisRepository.Get(a => a.ID == diagnosis.ID);
            diagnosis.CreatedDate = User.CreatedDate;
            diagnosis.ModifiedDate = User.ModifiedDate;
            diagnosis.DeletedDate = DateTime.Now;
            diagnosis.Status = 3;
            _diagnosisRepository.Update(diagnosis);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
