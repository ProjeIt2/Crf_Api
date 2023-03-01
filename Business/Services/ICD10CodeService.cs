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
   public class ICD10CodeService : IICD10CodeService
    {
        private IICD10CodeRepository _iCD10CodeRepository;
        public ICD10CodeService(IICD10CodeRepository iCD10CodeRepository)
        {
            _iCD10CodeRepository = iCD10CodeRepository;
        }

        public ICD10Code GetById(int Id)
        {
            return _iCD10CodeRepository.Get(a => a.ID == Id);
        }
        public List<ICD10Code> GetList()
        {
            return _iCD10CodeRepository.GetList().ToList();
        }
        public List<ICD10Code> GetActivesById(int CompanyID)
        {
            return _iCD10CodeRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(ICD10Code iCD10Code)
        {
            iCD10Code.CreatedDate = DateTime.Now;

            _iCD10CodeRepository.Add(iCD10Code);
            return "Ok";
        }
        public string Update(ICD10Code iCD10Code)
        {
            var User = _iCD10CodeRepository.Get(a => a.ID == iCD10Code.ID);
            iCD10Code.CreatedDate = User.CreatedDate;
            iCD10Code.ModifiedDate = DateTime.Now;
            iCD10Code.Status = 2;
            _iCD10CodeRepository.Update(iCD10Code);
            return "Ok";
        }
        public string Delete(ICD10Code iCD10Code)
        {
            var User = _iCD10CodeRepository.Get(a => a.ID == iCD10Code.ID);
            iCD10Code.CreatedDate = User.CreatedDate;
            iCD10Code.ModifiedDate = User.ModifiedDate;
            iCD10Code.DeletedDate = DateTime.Now;
            iCD10Code.Status = 3;
            _iCD10CodeRepository.Update(iCD10Code);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
