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
   public class TNMService : ITNMService
    {
        private ITNMRepository _tNMRepository;
        public TNMService(ITNMRepository tNMRepository)
        {
            _tNMRepository = tNMRepository;
        }

        public TNM GetById(int Id)
        {
            return _tNMRepository.Get(a => a.ID == Id);
        }
        public List<TNM> GetList()
        {
            return _tNMRepository.GetList().ToList();
        }
        public List<TNM> GetActives(int CompanyID)
        {
            return _tNMRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public TNM GetActivesById(int id)
        {
            return _tNMRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(TNM tNM)
        {
            tNM.CreatedDate = DateTime.Now;

            _tNMRepository.Add(tNM);
            return "Ok";
        }
        public string Update(TNM tNM)
        {
            var User = _tNMRepository.Get(a => a.ID == tNM.ID);
            tNM.CreatedDate = User.CreatedDate;
            tNM.ModifiedDate = DateTime.Now;
            tNM.Status = 2;
            _tNMRepository.Update(tNM);
            return "Ok";
        }
        public string Delete(TNM tNM)
        {
            var User = _tNMRepository.Get(a => a.ID == tNM.ID);
            tNM.CreatedDate = User.CreatedDate;
            tNM.ModifiedDate = User.ModifiedDate;
            tNM.DeletedDate = DateTime.Now;
            tNM.Status = 3;
            _tNMRepository.Update(tNM);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
