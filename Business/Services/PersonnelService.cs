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
    public class PersonnelService : IPersonnelService
    {
        private IPersonnelRepository _personnelRepository;
        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public Personnel GetById(int Id)
        {
            return _personnelRepository.Get(a => a.ID == Id);
        }
        public List<Personnel> GetList()
        {
            return _personnelRepository.GetList().ToList();
        }
        public List<Personnel> GetActivesById(int CompanyID)
        {
            return _personnelRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public string Add(Personnel personnel)
        {
            personnel.CreatedDate = DateTime.Now;

            _personnelRepository.Add(personnel);
            return "Ok";
        }
        public string Update(Personnel personnel)
        {
            var User = _personnelRepository.Get(a => a.ID== personnel.ID);
            personnel.CreatedDate = User.CreatedDate;
            personnel.ModifiedDate = DateTime.Now;
            personnel.Status = 2;
            _personnelRepository.Update(personnel);
            return "Ok";
        }
        public string Delete(Personnel personnel)
        {
            var User = _personnelRepository.Get(a => a.ID == personnel.ID);
            personnel.CreatedDate = User.CreatedDate;
            personnel.ModifiedDate = User.ModifiedDate;
            personnel.DeletedDate = DateTime.Now;
            personnel.Status = 3;
            _personnelRepository.Delete(personnel);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
