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
   public class MedicalStatusService : IMedicalStatusService
    {
        private IMedicalStatusRepository _medicalStatusRepository;
        public MedicalStatusService(IMedicalStatusRepository medicalStatusRepository)
        {
            _medicalStatusRepository = medicalStatusRepository;
        }

        public MedicalStatus GetById(int Id)
        {
            return _medicalStatusRepository.Get(a => a.ID == Id);
        }
        public List<MedicalStatus> GetList()
        {
            return _medicalStatusRepository.GetList().ToList();
        }
        public List<MedicalStatus> GetActives(int CompanyID)
        {
            return _medicalStatusRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public MedicalStatus GetActivesById(int id)
        {
            return _medicalStatusRepository.GetList(x => x.CompanyID == id && x.Status != 3).FirstOrDefault();
        }
        public string Add(MedicalStatus medicalStatus)
        {
            medicalStatus.CreatedDate = DateTime.Now;

            _medicalStatusRepository.Add(medicalStatus);
            return "Ok";
        }
        public string Update(MedicalStatus medicalStatus)
        {
            var User = _medicalStatusRepository.Get(a => a.ID == medicalStatus.ID);
            medicalStatus.CreatedDate = User.CreatedDate;
            medicalStatus.ModifiedDate = DateTime.Now;
            medicalStatus.Status = 2;
            _medicalStatusRepository.Update(medicalStatus);
            return "Ok";
        }
        public string Delete(MedicalStatus medicalStatus)
        {
            var User = _medicalStatusRepository.Get(a => a.ID == medicalStatus.ID);
            medicalStatus.CreatedDate = User.CreatedDate;
            medicalStatus.ModifiedDate = User.ModifiedDate;
            medicalStatus.DeletedDate = DateTime.Now;
            medicalStatus.Status = 3;
            _medicalStatusRepository.Update(medicalStatus);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
