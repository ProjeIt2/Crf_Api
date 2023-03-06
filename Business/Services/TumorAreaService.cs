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
   public class TumorAreaService : ITumorAreaService
    {
        private ITumorAreaRepository _tumorAreaRepository;
        public TumorAreaService(ITumorAreaRepository tumorAreaRepository)
        {
            _tumorAreaRepository = tumorAreaRepository;
        }

        public TumorArea GetById(int Id)
        {
            return _tumorAreaRepository.Get(a => a.ID == Id);
        }
        public List<TumorArea> GetList()
        {
            return _tumorAreaRepository.GetList().ToList();
        }
        public List<TumorArea> GetActives(int CompanyID)
        {
            return _tumorAreaRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public TumorArea GetActivesById(int id)
        {
            return _tumorAreaRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(TumorArea tumorArea)
        {
            tumorArea.CreatedDate = DateTime.Now;

            _tumorAreaRepository.Add(tumorArea);
            return "Ok";
        }
        public string Update(TumorArea tumorArea)
        {
            var User = _tumorAreaRepository.Get(a => a.ID == tumorArea.ID);
            tumorArea.CreatedDate = User.CreatedDate;
            tumorArea.ModifiedDate = DateTime.Now;
            tumorArea.Status = 2;
            _tumorAreaRepository.Update(tumorArea);
            return "Ok";
        }
        public string Delete(TumorArea tumorArea)
        {
            var User = _tumorAreaRepository.Get(a => a.ID == tumorArea.ID);
            tumorArea.CreatedDate = User.CreatedDate;
            tumorArea.ModifiedDate = User.ModifiedDate;
            tumorArea.DeletedDate = DateTime.Now;
            tumorArea.Status = 3;
            _tumorAreaRepository.Update(tumorArea);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
