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
   public class ContactUsService : IContactUsService
    {
        private IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public ContactUs GetById(int Id)
        {
            return _contactUsRepository.Get(a => a.ID == Id);
        }
        public List<ContactUs> GetList()
        {
            return _contactUsRepository.GetList().ToList();
        }
        public List<ContactUs> GetActives(int CompanyID)
        {
            return _contactUsRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
    
        public ContactUs GetActivesById(int id)
        {
            return _contactUsRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(ContactUs contactUs)
        {
            contactUs.CreatedDate = DateTime.Now;

            _contactUsRepository.Add(contactUs);
            return "Ok";
        }
        public string Update(ContactUs contactUs)
        {
            var User = _contactUsRepository.Get(a => a.ID == contactUs.ID);
            contactUs.CreatedDate = User.CreatedDate;
            contactUs.ModifiedDate = DateTime.Now;
            contactUs.Status = 2;
            _contactUsRepository.Update(contactUs);
            return "Ok";
        }
        public string Delete(ContactUs contactUs)
        {
            var User = _contactUsRepository.Get(a => a.ID == contactUs.ID);
            contactUs.CreatedDate = User.CreatedDate;
            contactUs.ModifiedDate = User.ModifiedDate;
            contactUs.DeletedDate = DateTime.Now;
            contactUs.Status = 3;
            _contactUsRepository.Update(contactUs);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
