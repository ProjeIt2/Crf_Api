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
   public class PillService : IPillService
    {
        private IPillRepository _pillRepository;
        public PillService(IPillRepository pillRepository)
        {
            _pillRepository = pillRepository;
        }

        public Pill GetById(int Id)
        {
            return _pillRepository.Get(a => a.ID == Id);
        }
        public List<Pill> GetList()
        {
            return _pillRepository.GetList().ToList();
        }
        public List<Pill> GetActives(int CompanyID)
        {
            return _pillRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Pill GetActivesById(int id)
        {
            return _pillRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Pill pill)
        {
            pill.CreatedDate = DateTime.Now;

            _pillRepository.Add(pill);
            return "Ok";
        }
        public string Update(Pill pill)
        {
            var User = _pillRepository.Get(a => a.ID == pill.ID);
            pill.CreatedDate = User.CreatedDate;
            pill.ModifiedDate = DateTime.Now;
            pill.Status = 2;
            _pillRepository.Update(pill);
            return "Ok";
        }
        public string Delete(Pill pill)
        {
            var User = _pillRepository.Get(a => a.ID == pill.ID);
            pill.CreatedDate = User.CreatedDate;
            pill.ModifiedDate = User.ModifiedDate;
            pill.DeletedDate = DateTime.Now;
            pill.Status = 3;
            _pillRepository.Update(pill);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
