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
   public class TumorTypeService : ITumorTypeService
    {
        private ITumorTypeRepository _tumorTypeRepository;
        public TumorTypeService(ITumorTypeRepository tumorTypeRepository)
        {
            _tumorTypeRepository = tumorTypeRepository;
        }

        public TumorType GetById(int Id)
        {
            return _tumorTypeRepository.Get(a => a.ID == Id);
        }
        public List<TumorType> GetList()
        {
            return _tumorTypeRepository.GetList().ToList();
        }
        public List<TumorType> GetActives(int CompanyID)
        {
            return _tumorTypeRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public TumorType GetActivesById(int id)
        {
            return _tumorTypeRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(TumorType tumorType)
        {
            tumorType.CreatedDate = DateTime.Now;

            _tumorTypeRepository.Add(tumorType);
            return "Ok";
        }
        public string Update(TumorType tumorType)
        {
            var User = _tumorTypeRepository.Get(a => a.ID == tumorType.ID);
            tumorType.CreatedDate = User.CreatedDate;
            tumorType.ModifiedDate = DateTime.Now;
            tumorType.Status = 2;
            _tumorTypeRepository.Update(tumorType);
            return "Ok";
        }
        public string Delete(TumorType tumorType)
        {
            var User = _tumorTypeRepository.Get(a => a.ID == tumorType.ID);
            tumorType.CreatedDate = User.CreatedDate;
            tumorType.ModifiedDate = User.ModifiedDate;
            tumorType.DeletedDate = DateTime.Now;
            tumorType.Status = 3;
            _tumorTypeRepository.Update(tumorType);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
