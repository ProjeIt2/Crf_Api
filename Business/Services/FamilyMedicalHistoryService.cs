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
    public class FamilyMedicalHistoryService : IFamilyMedicalHistoryService
    {
        private IFamilyMedicalHistoryRepository _familyMedicalHistoryRepository;
        public FamilyMedicalHistoryService(IFamilyMedicalHistoryRepository familyMedicalHistoryRepository)
        {
            _familyMedicalHistoryRepository = familyMedicalHistoryRepository;
        }

        public FamilyMedicalHistory GetById(int Id)
        {
            return _familyMedicalHistoryRepository.Get(a => a.ID == Id);
        }
        public List<FamilyMedicalHistory> GetList()
        {
            return _familyMedicalHistoryRepository.GetList().ToList();
        }
        public List<FamilyMedicalHistory> GetActives(int CompanyID)
        {
            return _familyMedicalHistoryRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<FamilyMedicalHistoryVM> GetListFamilyMedicalHistorys(int FormID)
        {
            return new List<FamilyMedicalHistoryVM>(_familyMedicalHistoryRepository.GetListFamilyMedicalHistorys(FormID).ToList());
        }
        public FamilyMedicalHistory GetActivesById(int id)
        {
            return _familyMedicalHistoryRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(FamilyMedicalHistory appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _familyMedicalHistoryRepository.Add(appUser);
            return "Ok";
        }
        public string Update(FamilyMedicalHistory appUser)
        {
            var User = _familyMedicalHistoryRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _familyMedicalHistoryRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(FamilyMedicalHistory appUser)
        {
            var Data = _familyMedicalHistoryRepository.Get(a => a.ID == appUser.ID);
            Data.DeletedDate = DateTime.Now;
            Data.Status = 3;
            _familyMedicalHistoryRepository.Delete(Data);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
