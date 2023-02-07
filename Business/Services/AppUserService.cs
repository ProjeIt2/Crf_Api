using Business.Services.Interfeces;
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
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _kullaniciRepository;
        public AppUserService(IAppUserRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public AppUser GetById(int Id)
        {
            return _kullaniciRepository.Get(a => a.ID == Id);
        }

        public List<AppUser> GetList()
        {
            return _kullaniciRepository.GetList().ToList();
        }
        public AppUser Login(string UserName, string Password)
        {
            return _kullaniciRepository.Get(a => a.UserName == UserName && a.Password == Password);
        }
        //public List<KullaniciDto> GetListKullanici()
        //{
        //    return new List<KullaniciDto>(_kullaniciRepository.GetListKullanici().ToList());
        //}
        public string Add(AppUser appUser)
        {
            _kullaniciRepository.Add(appUser);
            return "Ok";
        }
        public string Update(AppUser appUser)
        {
            _kullaniciRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(AppUser appUser)
        {
            _kullaniciRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
