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
    public class MateryalTipService : IMateryalTipService
    {
        private IMateryalTipRepository _hastaUzmanlikRepository;
        public MateryalTipService(IMateryalTipRepository hastaUzmanlikRepository)
        {
            _hastaUzmanlikRepository = hastaUzmanlikRepository;
        }

        public MateryalTip GetById(int Id)
        {
            return _hastaUzmanlikRepository.Get(a => a.MateryalTipId == Id);
        }

        public List<MateryalTip> GetList()
        {
            return _hastaUzmanlikRepository.GetList().ToList();
        }
        public string Add(MateryalTip hastaUzmanlik)
        {
            _hastaUzmanlikRepository.Add(hastaUzmanlik);
            return "Ok";
        }
        public string Update(MateryalTip hastaUzmanlik)
        {
            _hastaUzmanlikRepository.Update(hastaUzmanlik);
            return "Ok";
        }
        public string Delete(MateryalTip hastaUzmanlik)
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
