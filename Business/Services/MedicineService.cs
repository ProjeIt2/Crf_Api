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
    public class MedicineService : IMedicineService
    {
        private IMedicineRepository _medicineRepository;
        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public Medicine GetById(int Id)
        {
            return _medicineRepository.Get(a => a.ID == Id);
        }
        public List<Medicine> GetList()
        {
            return _medicineRepository.GetList().ToList();
        }
        public List<Medicine> GetActives(int CompanyID)
        {
            return _medicineRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<MedicineVM> GetListMedicines(int FormID)
        {
            return new List<MedicineVM>(_medicineRepository.GetListMedicines(FormID).ToList());
        }
        public MedicineVM GetListMedicinesID(int id)
        {
            return  _medicineRepository.GetListMedicinesID(id);
        }
        public Medicine GetActivesById(int id)
        {
            return _medicineRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(Medicine appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _medicineRepository.Add(appUser);
            return "Ok";
        }
        public string Update(Medicine appUser)
        {
            var User = _medicineRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _medicineRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(Medicine appUser)
        {
            var User = _medicineRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _medicineRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
