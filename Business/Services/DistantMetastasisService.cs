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
   public class DistantMetastasisService : IDistantMetastasisService
    {
        private IDistantMetastasisRepository _distantMetastasisRepository;
        public DistantMetastasisService(IDistantMetastasisRepository distantMetastasisRepository)
        {
            _distantMetastasisRepository = distantMetastasisRepository;
        }

        public DistantMetastasis GetById(int Id)
        {
            return _distantMetastasisRepository.Get(a => a.ID == Id);
        }
        public List<DistantMetastasis> GetList()
        {
            return _distantMetastasisRepository.GetList().ToList();
        }
        public List<DistantMetastasis> GetActives(int CompanyID)
        {
            return _distantMetastasisRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public DistantMetastasis GetActivesById(int id)
        {
            return _distantMetastasisRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(DistantMetastasis distantMetastasis)
        {
            distantMetastasis.CreatedDate = DateTime.Now;

            _distantMetastasisRepository.Add(distantMetastasis);
            return "Ok";
        }
        public string Update(DistantMetastasis distantMetastasis)
        {
            var User = _distantMetastasisRepository.Get(a => a.ID == distantMetastasis.ID);
            distantMetastasis.CreatedDate = User.CreatedDate;
            distantMetastasis.ModifiedDate = DateTime.Now;
            distantMetastasis.Status = 2;
            _distantMetastasisRepository.Update(distantMetastasis);
            return "Ok";
        }
        public string Delete(DistantMetastasis distantMetastasis)
        {
            var User = _distantMetastasisRepository.Get(a => a.ID == distantMetastasis.ID);
            distantMetastasis.CreatedDate = User.CreatedDate;
            distantMetastasis.ModifiedDate = User.ModifiedDate;
            distantMetastasis.DeletedDate = DateTime.Now;
            distantMetastasis.Status = 3;
            _distantMetastasisRepository.Update(distantMetastasis);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
