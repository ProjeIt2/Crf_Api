using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IKullaniciService
    {
        Kullanici GetById(int Id);
        List<Kullanici> GetList();
        Kullanici Login(string KullaniciAdi, string Sifre);
        List<KullaniciDto> GetListKullanici();
        string Add(Kullanici kullanici);
        string Update(Kullanici kullanici);
        string Delete(Kullanici kullanici);
        object GetById();
    }
}
