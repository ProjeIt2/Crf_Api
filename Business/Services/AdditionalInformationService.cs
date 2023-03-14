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
   public class AdditionalInformationService : IAdditionalInformationService
    {
        private IAdditionalInformationRepository _additionalInformationRepository;
        public AdditionalInformationService(IAdditionalInformationRepository additionalInformationRepository)
        {
            _additionalInformationRepository = additionalInformationRepository;
        }

        public AdditionalInformation GetById(int Id)
        {
            return _additionalInformationRepository.Get(a => a.ID == Id);
        }
        public List<AdditionalInformation> GetList()
        {
            return _additionalInformationRepository.GetList().ToList();
        }
        public List<AdditionalInformation> GetActives(int CompanyID)
        {
            return _additionalInformationRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<AdditionalInformation> GetActivesFormID(int FormID)
        {
            return _additionalInformationRepository.GetList(x => x.FormID == FormID && x.Status != 3).ToList();
        }
        public AdditionalInformation GetActivesById(int id)
        {
            return _additionalInformationRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(AdditionalInformation additionalInformation)
        {
            additionalInformation.CreatedDate = DateTime.Now;

            _additionalInformationRepository.Add(additionalInformation);
            return "Ok";
        }
        public string Update(AdditionalInformation additionalInformation)
        {
            var User = _additionalInformationRepository.Get(a => a.ID == additionalInformation.ID);
            additionalInformation.CreatedDate = User.CreatedDate;
            additionalInformation.ModifiedDate = DateTime.Now;
            additionalInformation.Status = 2;
            _additionalInformationRepository.Update(additionalInformation);
            return "Ok";
        }
        public string Delete(AdditionalInformation additionalInformation)
        {
            var User = _additionalInformationRepository.Get(a => a.ID == additionalInformation.ID);
            additionalInformation.CreatedDate = User.CreatedDate;
            additionalInformation.ModifiedDate = User.ModifiedDate;
            additionalInformation.DeletedDate = DateTime.Now;
            additionalInformation.Status = 3;
            _additionalInformationRepository.Update(additionalInformation);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
