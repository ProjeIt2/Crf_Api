using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IAppUserService
    {
        AppUser GetById(int Id);
        List<AppUser> GetList();
        List<AppUser> GetActivesById(int CompanyID);
        AppUser Login(string KullaniciAdi, string Sifre);
        //List<KullaniciDto> GetListKullanici();
        string Add(AppUser kullanici);
        string Update(AppUser kullanici);
        string Delete(AppUser kullanici);
        object GetById();
    }
}
