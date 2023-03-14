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
    public class SpecimenService : ISpecimenService
    {
        private ISpecimenRepository _specimenRepository;
        public SpecimenService(ISpecimenRepository specimenRepository)
        {
            _specimenRepository = specimenRepository;
        }

        public Specimen GetById(int Id)
        {
            return _specimenRepository.Get(a => a.ID == Id);
        }
        public List<Specimen> GetList()
        {
            return _specimenRepository.GetList().ToList();
        }
        public List<Specimen> GetActives(int CompanyID)
        {
            return _specimenRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<SpecimenVM> GetListSpecimens(int FormID)
        {
            return new List<SpecimenVM>(_specimenRepository.GetListSpecimens(FormID).ToList());
        }

        public SpecimenVM GetListSpecimensID(int id)
        {
            return _specimenRepository.GetListSpecimensID(id);
        }
        public Specimen GetActivesById(int id)
        {
            return _specimenRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(Specimen appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _specimenRepository.Add(appUser);
            return "Ok";
        }
        public string Update(Specimen appUser)
        {
            var User = _specimenRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _specimenRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(Specimen appUser)
        {
            var User = _specimenRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _specimenRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
