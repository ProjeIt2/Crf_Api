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
   public class AffinityService : IAffinityService
    {
        private IAffinityRepository _affinityRepository;
        public AffinityService(IAffinityRepository affinityRepository)
        {
            _affinityRepository = affinityRepository;
        }

        public Affinity GetById(int Id)
        {
            return _affinityRepository.Get(a => a.ID == Id);
        }
        public List<Affinity> GetList()
        {
            return _affinityRepository.GetList().ToList();
        }
        public List<Affinity> GetActives()
        {
            return _affinityRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public Affinity GetActivesById(int id)
        {
            return _affinityRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Affinity affinity)
        {
            affinity.CreatedDate = DateTime.Now;

            _affinityRepository.Add(affinity);
            return "Ok";
        }
        public string Update(Affinity affinity)
        {
            var User = _affinityRepository.Get(a => a.ID == affinity.ID);
            affinity.CreatedDate = User.CreatedDate;
            affinity.ModifiedDate = DateTime.Now;
            affinity.Status = 2;
            _affinityRepository.Update(affinity);
            return "Ok";
        }
        public string Delete(Affinity affinity)
        {
            var User = _affinityRepository.Get(a => a.ID == affinity.ID);
            affinity.CreatedDate = User.CreatedDate;
            affinity.ModifiedDate = User.ModifiedDate;
            affinity.DeletedDate = DateTime.Now;
            affinity.Status = 3;
            _affinityRepository.Update(affinity);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
