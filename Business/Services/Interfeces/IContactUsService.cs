using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IContactUsService
    {
        ContactUs GetById(int Id);
        List<ContactUs> GetList();
        List<ContactUs> GetActives(int CompanyID);
         ContactUs GetActivesById(int id);
        string Add(ContactUs contactUs);
        string Update(ContactUs contactUs);
        string Delete(ContactUs contactUs);
        object GetById();
    }
}
