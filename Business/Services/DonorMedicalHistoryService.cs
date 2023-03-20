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
    public class DonorMedicalHistoryService : IDonorMedicalHistoryService
    {
        private IDonorMedicalHistoryRepository _donorMedicalHistoryRepository;
        public DonorMedicalHistoryService(IDonorMedicalHistoryRepository donorMedicalHistoryRepository)
        {
            _donorMedicalHistoryRepository = donorMedicalHistoryRepository;
        }

        public DonorMedicalHistory GetById(int Id)
        {
            return _donorMedicalHistoryRepository.Get(a => a.ID == Id);
        }
        public List<DonorMedicalHistory> GetList()
        {
            return _donorMedicalHistoryRepository.GetList().ToList();
        }
        public List<DonorMedicalHistoryVM> GetListDonorMedicalHistorys(int FormID)
        {
            return new List<DonorMedicalHistoryVM>(_donorMedicalHistoryRepository.GetListDonorMedicalHistorys(FormID).ToList());
        }
        public List<DonorMedicalHistory> GetActives(int CompanyID)
        {
            return _donorMedicalHistoryRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public DonorMedicalHistory GetActivesById(int id)
        {
            return _donorMedicalHistoryRepository.GetList(x => x.ID == id && x.Status != 3).FirstOrDefault();
        }
        public string Add(DonorMedicalHistory appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _donorMedicalHistoryRepository.Add(appUser);
            return "Ok";
        }
        public string Update(DonorMedicalHistory appUser)
        {
            var User = _donorMedicalHistoryRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _donorMedicalHistoryRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(DonorMedicalHistory appUser)
        {
            var User = _donorMedicalHistoryRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _donorMedicalHistoryRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
