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
   public class UsageService : IUsageService
    {
        private IUsageRepository _usageRepository;
        public UsageService(IUsageRepository usageRepository)
        {
            _usageRepository = usageRepository;
        }

        public Usage GetById(int Id)
        {
            return _usageRepository.Get(a => a.ID == Id);
        }
        public List<Usage> GetList()
        {
            return _usageRepository.GetList().ToList();
        }
        public List<Usage> GetActives(int CompanyID)
        {
            return _usageRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Usage GetActivesById(int id)
        {
            return _usageRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Usage usage)
        {
            usage.CreatedDate = DateTime.Now;

            _usageRepository.Add(usage);
            return "Ok";
        }
        public string Update(Usage usage)
        {
            var User = _usageRepository.Get(a => a.ID == usage.ID);
            usage.CreatedDate = User.CreatedDate;
            usage.ModifiedDate = DateTime.Now;
            usage.Status = 2;
            _usageRepository.Update(usage);
            return "Ok";
        }
        public string Delete(Usage usage)
        {
            var User = _usageRepository.Get(a => a.ID == usage.ID);
            usage.CreatedDate = User.CreatedDate;
            usage.ModifiedDate = User.ModifiedDate;
            usage.DeletedDate = DateTime.Now;
            usage.Status = 3;
            _usageRepository.Update(usage);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
