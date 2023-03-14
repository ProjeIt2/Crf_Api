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
   public class MetastasisService : IMetastasisService
    {
        private IMetastasisRepository _metastasisRepository;
        public MetastasisService(IMetastasisRepository metastasisRepository)
        {
            _metastasisRepository = metastasisRepository;
        }

        public Metastasis GetById(int Id)
        {
            return _metastasisRepository.Get(a => a.ID == Id);
        }
        public List<Metastasis> GetList()
        {
            return _metastasisRepository.GetList().ToList();
        }
        public List<Metastasis> GetActives(int CompanyID)
        {
            return _metastasisRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Metastasis GetActivesById(int id)
        {
            return _metastasisRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Metastasis metastasis)
        {
            metastasis.CreatedDate = DateTime.Now;

            _metastasisRepository.Add(metastasis);
            return "Ok";
        }
        public string Update(Metastasis metastasis)
        {
            var User = _metastasisRepository.Get(a => a.ID == metastasis.ID);
            metastasis.CreatedDate = User.CreatedDate;
            metastasis.ModifiedDate = DateTime.Now;
            metastasis.Status = 2;
            _metastasisRepository.Update(metastasis);
            return "Ok";
        }
        public string Delete(Metastasis metastasis)
        {
            var User = _metastasisRepository.Get(a => a.ID == metastasis.ID);
            metastasis.CreatedDate = User.CreatedDate;
            metastasis.ModifiedDate = User.ModifiedDate;
            metastasis.DeletedDate = DateTime.Now;
            metastasis.Status = 3;
            _metastasisRepository.Update(metastasis);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
