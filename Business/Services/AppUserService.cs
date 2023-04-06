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
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _appUserRepository;
        public AppUserService(IAppUserRepository kullaniciRepository)
        {
            _appUserRepository = kullaniciRepository;
        }

        public AppUser GetById(int Id)
        {
            return _appUserRepository.Get(a => a.ID == Id);
        }
        public List<AppUser> GetList()
        {
            return _appUserRepository.GetList().ToList();
        }
        public List<AppUser> GetActivesById(int CompanyID)
        {
            return _appUserRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public AppUser Login(string UserName, string Password)
        {
            var User = _appUserRepository.Get(a => a.UserName.ToLower() == UserName.ToLower());
            if (User!=null)
            {
                if (Dantex.DeCrypt(User.Password)== Password)
                {
                    return User;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
        //public List<KullaniciDto> GetListKullanici()
        //{
        //    return new List<KullaniciDto>(_appUserRepository.GetListKullanici().ToList());
        //}
        public string Add(AppUser appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _appUserRepository.Add(appUser);
            return "Ok";
        }
        public string Update(AppUser appUser)
        {
            var User = _appUserRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _appUserRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(AppUser appUser)
        {
            _appUserRepository.Update(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
