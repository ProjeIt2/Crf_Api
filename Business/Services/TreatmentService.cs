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
   public class TreatmentService : ITreatmentService
    {
        private ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public Treatment GetById(int Id)
        {
            return _treatmentRepository.Get(a => a.ID == Id);
        }
        public List<Treatment> GetList()
        {
            return _treatmentRepository.GetList().ToList();
        }
        public List<Treatment> GetActives(int CompanyID)
        {
            return _treatmentRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Treatment GetActivesById(int id)
        {
            return _treatmentRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Treatment treatment)
        {
            treatment.CreatedDate = DateTime.Now;

            _treatmentRepository.Add(treatment);
            return "Ok";
        }
        public string Update(Treatment treatment)
        {
            var User = _treatmentRepository.Get(a => a.ID == treatment.ID);
            treatment.CreatedDate = User.CreatedDate;
            treatment.ModifiedDate = DateTime.Now;
            treatment.Status = 2;
            _treatmentRepository.Update(treatment);
            return "Ok";
        }
        public string Delete(Treatment treatment)
        {
            var User = _treatmentRepository.Get(a => a.ID == treatment.ID);
            treatment.CreatedDate = User.CreatedDate;
            treatment.ModifiedDate = User.ModifiedDate;
            treatment.DeletedDate = DateTime.Now;
            treatment.Status = 3;
            _treatmentRepository.Update(treatment);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
