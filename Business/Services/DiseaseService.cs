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
   public class DiseaseService : IDiseaseService
    {
        private IDiseaseRepository _diseaseRepository;
        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public Disease GetById(int Id)
        {
            return _diseaseRepository.Get(a => a.ID == Id);
        }
        public List<Disease> GetList()
        {
            return _diseaseRepository.GetList().ToList();
        }
        public List<Disease> GetActivesById(int CompanyID)
        {
            return _diseaseRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(Disease disease)
        {
            disease.CreatedDate = DateTime.Now;

            _diseaseRepository.Add(disease);
            return "Ok";
        }
        public string Update(Disease disease)
        {
            var User = _diseaseRepository.Get(a => a.ID == disease.ID);
            disease.CreatedDate = User.CreatedDate;
            disease.ModifiedDate = DateTime.Now;
            disease.Status = 2;
            _diseaseRepository.Update(disease);
            return "Ok";
        }
        public string Delete(Disease disease)
        {
            var User = _diseaseRepository.Get(a => a.ID == disease.ID);
            disease.CreatedDate = User.CreatedDate;
            disease.ModifiedDate = User.ModifiedDate;
            disease.DeletedDate = DateTime.Now;
            disease.Status = 3;
            _diseaseRepository.Update(disease);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
