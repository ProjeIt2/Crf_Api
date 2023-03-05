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
   public class CurrentStatusService : ICurrentStatusService
    {
        private ICurrentStatusRepository _currentStatusRepository;
        public CurrentStatusService(ICurrentStatusRepository currentStatusRepository)
        {
            _currentStatusRepository = currentStatusRepository;
        }

        public CurrentStatus GetById(int Id)
        {
            return _currentStatusRepository.Get(a => a.ID == Id);
        }
        public List<CurrentStatus> GetList()
        {
            return _currentStatusRepository.GetList().ToList();
        }
        public List<CurrentStatus> GetActives(int CompanyID)
        {
            return _currentStatusRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public CurrentStatus GetActivesById(int id)
        {
            return _currentStatusRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(CurrentStatus currentStatus)
        {
            currentStatus.CreatedDate = DateTime.Now;

            _currentStatusRepository.Add(currentStatus);
            return "Ok";
        }
        public string Update(CurrentStatus currentStatus)
        {
            var User = _currentStatusRepository.Get(a => a.ID == currentStatus.ID);
            currentStatus.CreatedDate = User.CreatedDate;
            currentStatus.ModifiedDate = DateTime.Now;
            currentStatus.Status = 2;
            _currentStatusRepository.Update(currentStatus);
            return "Ok";
        }
        public string Delete(CurrentStatus currentStatus)
        {
            var User = _currentStatusRepository.Get(a => a.ID == currentStatus.ID);
            currentStatus.CreatedDate = User.CreatedDate;
            currentStatus.ModifiedDate = User.ModifiedDate;
            currentStatus.DeletedDate = DateTime.Now;
            currentStatus.Status = 3;
            _currentStatusRepository.Update(currentStatus);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
