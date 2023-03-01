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
   public class EnvironmentalExposureService : IEnvironmentalExposureService
    {
        private IEnvironmentalExposureRepository _environmentalExposureRepository;
        public EnvironmentalExposureService(IEnvironmentalExposureRepository environmentalExposureRepository)
        {
            _environmentalExposureRepository = environmentalExposureRepository;
        }

        public EnvironmentalExposure GetById(int Id)
        {
            return _environmentalExposureRepository.Get(a => a.ID == Id);
        }
        public List<EnvironmentalExposure> GetList()
        {
            return _environmentalExposureRepository.GetList().ToList();
        }
        public List<EnvironmentalExposure> GetActivesById(int CompanyID)
        {
            return _environmentalExposureRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(EnvironmentalExposure environmentalExposure)
        {
            environmentalExposure.CreatedDate = DateTime.Now;

            _environmentalExposureRepository.Add(environmentalExposure);
            return "Ok";
        }
        public string Update(EnvironmentalExposure environmentalExposure)
        {
            var User = _environmentalExposureRepository.Get(a => a.ID == environmentalExposure.ID);
            environmentalExposure.CreatedDate = User.CreatedDate;
            environmentalExposure.ModifiedDate = DateTime.Now;
            environmentalExposure.Status = 2;
            _environmentalExposureRepository.Update(environmentalExposure);
            return "Ok";
        }
        public string Delete(EnvironmentalExposure environmentalExposure)
        {
            var User = _environmentalExposureRepository.Get(a => a.ID == environmentalExposure.ID);
            environmentalExposure.CreatedDate = User.CreatedDate;
            environmentalExposure.ModifiedDate = User.ModifiedDate;
            environmentalExposure.DeletedDate = DateTime.Now;
            environmentalExposure.Status = 3;
            _environmentalExposureRepository.Update(environmentalExposure);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
