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
    public class HospitalService : IHospitalService
    {
        private IHospitalRepository _kullaniciRepository;
        public HospitalService(IHospitalRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public Hospital GetById(int Id)
        {
            return _kullaniciRepository.Get(a => a.ID == Id);
        }
        public List<Hospital> GetList()
        {
            return _kullaniciRepository.GetList().ToList();
        }
        public List<Hospital> GetActivesById(int CompanyID)
        {
            return _kullaniciRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }

        //public List<KullaniciDto> GetListKullanici()
        //{
        //    return new List<KullaniciDto>(_kullaniciRepository.GetListKullanici().ToList());
        //}
        public string Add(Hospital appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _kullaniciRepository.Add(appUser);
            return "Ok";
        }
        public string Update(Hospital appUser)
        {
            var User = _kullaniciRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _kullaniciRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(Hospital appUser)
        {
            var User = _kullaniciRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _kullaniciRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
