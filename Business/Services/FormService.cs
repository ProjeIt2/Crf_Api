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
    public class FormService : IFormService
    {
        private IFormRepository _kullaniciRepository;
        public FormService(IFormRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public Form GetById(int Id)
        {
            return _kullaniciRepository.Get(a => a.ID == Id);
        }
        public List<Form> GetList()
        {
            return _kullaniciRepository.GetList().ToList();
        }
        public List<FormListVM> GetListForms(int CompanyID)
        {
            return new List<FormListVM>(_kullaniciRepository.GetListForms(CompanyID).ToList());
        }
        public Form GetActivesById(int id)
        {
            return _kullaniciRepository.GetList(x=>x.ID==id&&x.Status!=3).FirstOrDefault();
        }
        public List<Form> GetActives(int CompanyID)
        {
            return _kullaniciRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(Form appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _kullaniciRepository.Add(appUser);
            return "Ok";
        }
        public string Update(Form appUser)
        {
            var User = _kullaniciRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _kullaniciRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(Form appUser)
        {
            var User = _kullaniciRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _kullaniciRepository.Update(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
