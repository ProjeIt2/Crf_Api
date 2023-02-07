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
    public class HastaUzmanlikService : IHastaUzmanlikService
    {
        private IHastaUzmanlikRepository _hastaUzmanlikRepository;
        public HastaUzmanlikService(IHastaUzmanlikRepository hastaUzmanlikRepository)
        {
            _hastaUzmanlikRepository = hastaUzmanlikRepository;
        }

        public HastaUzmanlik GetById(int Id)
        {
            return _hastaUzmanlikRepository.Get(a => a.HastaUzmanlikId == Id);
        }

        public List<HastaUzmanlik> GetList()
        {
            return _hastaUzmanlikRepository.GetList().ToList();
        }
        public string Add(HastaUzmanlik hastaUzmanlik)
        {
            _hastaUzmanlikRepository.Add(hastaUzmanlik);
            return "Ok";
        }
        public string Update(HastaUzmanlik hastaUzmanlik)
        {
            _hastaUzmanlikRepository.Update(hastaUzmanlik);
            return "Ok";
        }
        public string Delete(HastaUzmanlik hastaUzmanlik)
        {
            _hastaUzmanlikRepository.Delete(hastaUzmanlik);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
