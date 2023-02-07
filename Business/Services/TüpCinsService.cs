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
    public class TüpCinsService : ITüpCinsService
    {
        private ITüpCinsRepository _tüpCinsRepository;
        public TüpCinsService(ITüpCinsRepository tüpCinsRepository)
        {
            _tüpCinsRepository = tüpCinsRepository;
        }

        public TüpCins GetById(int Id)
        {
            return _tüpCinsRepository.Get(a => a.TüpCinsId == Id);
        }

        public List<TüpCins> GetList()
        {
            return _tüpCinsRepository.GetList().ToList();
        }
        public string Add(TüpCins tüpCins)
        {
            _tüpCinsRepository.Add(tüpCins);
            return "Ok";
        }
        public string Update(TüpCins tüpCins)
        {
            _tüpCinsRepository.Update(tüpCins);
            return "Ok";
        }
        public string Delete(TüpCins tüpCins)
        {
            _tüpCinsRepository.Delete(tüpCins);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
