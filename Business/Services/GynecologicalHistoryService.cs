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
   public class GynecologicalHistoryService : IGynecologicalHistoryService
    {
        private IGynecologicalHistoryRepository _gynecologicalHistoryRepository;
        public GynecologicalHistoryService(IGynecologicalHistoryRepository gynecologicalHistoryRepository)
        {
            _gynecologicalHistoryRepository = gynecologicalHistoryRepository;
        }

        public GynecologicalHistory GetById(int Id)
        {
            return _gynecologicalHistoryRepository.Get(a => a.ID == Id);
        }
        public List<GynecologicalHistory> GetList()
        {
            return _gynecologicalHistoryRepository.GetList().ToList();
        }
        public List<GynecologicalHistory> GetActives(int CompanyID)
        {
            return _gynecologicalHistoryRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<GynecologicalHistory> GetActivesFormID(int FormID)
        {
            return _gynecologicalHistoryRepository.GetList(x => x.FormID == FormID && x.Status != 3).ToList();
        }
        public GynecologicalHistory GetActivesById(int id)
        {
            return _gynecologicalHistoryRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(GynecologicalHistory gynecologicalHistory)
        {
            gynecologicalHistory.CreatedDate = DateTime.Now;

            _gynecologicalHistoryRepository.Add(gynecologicalHistory);
            return "Ok";
        }
        public string Update(GynecologicalHistory gynecologicalHistory)
        {
            var User = _gynecologicalHistoryRepository.Get(a => a.ID == gynecologicalHistory.ID);
            gynecologicalHistory.CreatedDate = User.CreatedDate;
            gynecologicalHistory.ModifiedDate = DateTime.Now;
            gynecologicalHistory.Status = 2;
            _gynecologicalHistoryRepository.Update(gynecologicalHistory);
            return "Ok";
        }
        public string Delete(GynecologicalHistory gynecologicalHistory)
        {
            var User = _gynecologicalHistoryRepository.Get(a => a.ID == gynecologicalHistory.ID);
             User.DeletedDate = DateTime.Now;
            User.Status = 3;
            _gynecologicalHistoryRepository.Delete(User);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
