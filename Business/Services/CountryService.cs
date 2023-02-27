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
   public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Country GetById(int Id)
        {
            return _countryRepository.Get(a => a.ID == Id);
        }
        public List<Country> GetList()
        {
            return _countryRepository.GetList().ToList();
        }
        public List<Country> GetActivesById(int CompanyID)
        {
            return _countryRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(Country country)
        {
            country.CreatedDate = DateTime.Now;

            _countryRepository.Add(country);
            return "Ok";
        }
        public string Update(Country country)
        {
            var User = _countryRepository.Get(a => a.ID == country.ID);
            country.CreatedDate = User.CreatedDate;
            country.ModifiedDate = DateTime.Now;
            country.Status = 2;
            _countryRepository.Update(country);
            return "Ok";
        }
        public string Delete(Country country)
        {
            var User = _countryRepository.Get(a => a.ID == country.ID);
            country.CreatedDate = User.CreatedDate;
            country.ModifiedDate = User.ModifiedDate;
            country.DeletedDate = DateTime.Now;
            country.Status = 3;
            _countryRepository.Delete(country);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
