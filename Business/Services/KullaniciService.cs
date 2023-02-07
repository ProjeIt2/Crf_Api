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
    public class KullaniciService : IKullaniciService
    {
        private IKullaniciRepository _kullaniciRepository;
        public KullaniciService(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public Kullanici GetById(int Id)
        {
            return _kullaniciRepository.Get(a => a.KullaniciId == Id);
        }

        public List<Kullanici> GetList()
        {
            return _kullaniciRepository.GetList().ToList();
        }
        public Kullanici Login(string KullaniciAdi, string Sifre)
        {
            return _kullaniciRepository.Get(a => a.KullaniciAdi == KullaniciAdi && a.Sifre == Sifre);
        }
        public List<KullaniciDto> GetListKullanici()
        {
            return new List<KullaniciDto>(_kullaniciRepository.GetListKullanici().ToList());
        }
        public string Add(Kullanici kullanici)
        {
            _kullaniciRepository.Add(kullanici);
            return "Ok";
        }
        public string Update(Kullanici kullanici)
        {
            _kullaniciRepository.Update(kullanici);
            return "Ok";
        }
        public string Delete(Kullanici kullanici)
        {
            _kullaniciRepository.Delete(kullanici);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
