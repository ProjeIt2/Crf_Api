using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ICountryService
    {
        Country GetById(int Id);
        List<Country> GetList();
        List<Country> GetActivesById(int CompanyID);
        string Add(Country country);
        string Update(Country country);
        string Delete(Country country);
        object GetById();
    }
}
