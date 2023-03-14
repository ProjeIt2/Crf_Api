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
    public class DiagnosisInformationService : IDiagnosisInformationService
    {
        private IDiagnosisInformationRepository _diagnosisInformationRepository;
        public DiagnosisInformationService(IDiagnosisInformationRepository diagnosisInformationRepository)
        {
            _diagnosisInformationRepository = diagnosisInformationRepository;
        }

        public DiagnosisInformation GetById(int Id)
        {
            return _diagnosisInformationRepository.Get(a => a.ID == Id);
        }
        public List<DiagnosisInformation> GetList()
        {
            return _diagnosisInformationRepository.GetList().ToList();
        }
        public List<DiagnosisInformationVM> GetListDiagnosisInformations(int FormID)
        {
            return new List<DiagnosisInformationVM>(_diagnosisInformationRepository.GetListDiagnosisInformations(FormID).ToList());
        }
        public DiagnosisInformationVM GetListDiagnosisInformationsID(int id)
        {
            return _diagnosisInformationRepository.GetListDiagnosisInformationsID(id);
        }
        public List<DiagnosisInformation> GetActivesById(int CompanyID)
        {
            return _diagnosisInformationRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
  
        public string Add(DiagnosisInformation appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _diagnosisInformationRepository.Add(appUser);
            return "Ok";
        }
        public string Update(DiagnosisInformation appUser)
        {
            var User = _diagnosisInformationRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _diagnosisInformationRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(DiagnosisInformation appUser)
        {
            var User = _diagnosisInformationRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _diagnosisInformationRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
