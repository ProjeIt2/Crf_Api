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
   public class DiagnosisHistoryService : IDiagnosisHistoryService
    {
        private IDiagnosisHistoryRepository _diagnosisHistoryRepository;
        public DiagnosisHistoryService(IDiagnosisHistoryRepository diagnosisHistoryRepository)
        {
            _diagnosisHistoryRepository = diagnosisHistoryRepository;
        }

        public DiagnosisHistory GetById(int Id)
        {
            return _diagnosisHistoryRepository.Get(a => a.ID == Id);
        }
        public List<DiagnosisHistory> GetList()
        {
            return _diagnosisHistoryRepository.GetList().ToList();
        }
        public List<DiagnosisHistory> GetActivesById(int CompanyID)
        {
            return _diagnosisHistoryRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(DiagnosisHistory diagnosisHistory)
        {
            diagnosisHistory.CreatedDate = DateTime.Now;

            _diagnosisHistoryRepository.Add(diagnosisHistory);
            return "Ok";
        }
        public string Update(DiagnosisHistory diagnosisHistory)
        {
            var User = _diagnosisHistoryRepository.Get(a => a.ID == diagnosisHistory.ID);
            diagnosisHistory.CreatedDate = User.CreatedDate;
            diagnosisHistory.ModifiedDate = DateTime.Now;
            diagnosisHistory.Status = 2;
            _diagnosisHistoryRepository.Update(diagnosisHistory);
            return "Ok";
        }
        public string Delete(DiagnosisHistory diagnosisHistory)
        {
            var User = _diagnosisHistoryRepository.Get(a => a.ID == diagnosisHistory.ID);
            diagnosisHistory.CreatedDate = User.CreatedDate;
            diagnosisHistory.ModifiedDate = User.ModifiedDate;
            diagnosisHistory.DeletedDate = DateTime.Now;
            diagnosisHistory.Status = 3;
            _diagnosisHistoryRepository.Update(diagnosisHistory);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
