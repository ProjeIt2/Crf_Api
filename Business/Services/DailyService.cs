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
   public class DailyService : IDailyService
    {
        private IDailyRepository _dailyRepository;
        public DailyService(IDailyRepository dailyRepository)
        {
            _dailyRepository = dailyRepository;
        }

        public Daily GetById(int Id)
        {
            return _dailyRepository.Get(a => a.ID == Id);
        }
        public List<Daily> GetList()
        {
            return _dailyRepository.GetList().ToList();
        }
        public List<Daily> GetActives(int CompanyID)
        {
            return _dailyRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<Daily> GetDailyMyVisite(int PersonnelID)
        {
            return _dailyRepository.GetList(x => x.PersonelID==PersonnelID&&x.SelectLabel== "VisitePlan" && x.Status != 3).ToList();
        }
        public List<Daily> GetDailyVisite(int PersonnelID)
        {
            return _dailyRepository.GetList(x => x.SenderID == PersonnelID && x.SelectLabel == "VisitePlan" && x.Status != 3).ToList();
        }
        public Daily GetActivesById(int id)
        {
            return _dailyRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Daily daily)
        {
            daily.CreatedDate = DateTime.Now;

            _dailyRepository.Add(daily);
            return "Ok";
        }
        public string Update(Daily daily)
        {
            var User = _dailyRepository.Get(a => a.ID == daily.ID);
            daily.CreatedDate = User.CreatedDate;
            daily.ModifiedDate = DateTime.Now;
            daily.Status = 2;
            _dailyRepository.Update(daily);
            return "Ok";
        }
        public string Delete(Daily daily)
        {
            var User = _dailyRepository.Get(a => a.ID == daily.ID);
            daily.CreatedDate = User.CreatedDate;
            daily.ModifiedDate = User.ModifiedDate;
            daily.DeletedDate = DateTime.Now;
            daily.Status = 3;
            _dailyRepository.Update(daily);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
