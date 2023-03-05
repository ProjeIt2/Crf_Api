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
   public class VirusService : IVirusService
    {
        private IVirusRepository _virusRepository;
        public VirusService(IVirusRepository virusRepository)
        {
            _virusRepository = virusRepository;
        }

        public Virus GetById(int Id)
        {
            return _virusRepository.Get(a => a.ID == Id);
        }
        public List<Virus> GetList()
        {
            return _virusRepository.GetList().ToList();
        }
        public List<Virus> GetActives(int CompanyID)
        {
            return _virusRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Virus GetActivesById(int id)
        {
            return _virusRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Virus virus)
        {
            virus.CreatedDate = DateTime.Now;

            _virusRepository.Add(virus);
            return "Ok";
        }
        public string Update(Virus virus)
        {
            var User = _virusRepository.Get(a => a.ID == virus.ID);
            virus.CreatedDate = User.CreatedDate;
            virus.ModifiedDate = DateTime.Now;
            virus.Status = 2;
            _virusRepository.Update(virus);
            return "Ok";
        }
        public string Delete(Virus virus)
        {
            var User = _virusRepository.Get(a => a.ID == virus.ID);
            virus.CreatedDate = User.CreatedDate;
            virus.ModifiedDate = User.ModifiedDate;
            virus.DeletedDate = DateTime.Now;
            virus.Status = 3;
            _virusRepository.Update(virus);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
