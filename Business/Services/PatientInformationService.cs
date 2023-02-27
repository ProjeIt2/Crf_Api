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
    public class PatientInformationService : IPatientInformationService
    {
        private IPatientInformationRepository _patientInformationRepository;
        public PatientInformationService(IPatientInformationRepository patientInformationRepository)
        {
            _patientInformationRepository = patientInformationRepository;
        }

        public PatientInformation GetById(int Id)
        {
            return _patientInformationRepository.Get(a => a.ID == Id);
        }
        public PatientInformation GetByFormId(int FormId)
        {
            return _patientInformationRepository.Get(a => a.FormID == FormId);
        }
        public List<PatientInformation> GetList()
        {
            return _patientInformationRepository.GetList().ToList();
        }

        public List<PatientInformation> GetActivesById(int CompanyID)
        {
            return _patientInformationRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public string Add(PatientInformation patientInformation)
        {
            patientInformation.CreatedDate = DateTime.Now;

            _patientInformationRepository.Add(patientInformation);
            return "Ok";
        }
        public string Update(PatientInformation patientInformation)
        {
            var patInf = _patientInformationRepository.Get(a => a.FormID== patientInformation.FormID);
            patientInformation.CreatedDate = patInf.CreatedDate;
            patientInformation.DeletedDate = patInf.DeletedDate;
            patientInformation.ModifiedDate = DateTime.Now;
            patientInformation.Status = 2;
            patientInformation.ID = patInf.ID;
            patientInformation.FormID = patInf.FormID;
            patientInformation.CompanyID = patInf.CompanyID;
            _patientInformationRepository.Update(patientInformation);
            return "Ok";
        }
        public string Delete(PatientInformation patientInformation)
        {
            var User = _patientInformationRepository.Get(a => a.ID == patientInformation.ID);
            patientInformation.CreatedDate = User.CreatedDate;
            patientInformation.ModifiedDate = User.ModifiedDate;
            patientInformation.DeletedDate = DateTime.Now;
            patientInformation.Status = 3;
            _patientInformationRepository.Update(patientInformation);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
