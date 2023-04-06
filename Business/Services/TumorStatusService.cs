using Business.Services.Interfeces;
using Core.Tools;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TumorStatusService : ITumorStatusService
    {
        private ITumorStatusRepository _tumorStatusRepository;
        public TumorStatusService(ITumorStatusRepository tumorStatusRepository)
        {
            _tumorStatusRepository = tumorStatusRepository;
        }

        public TumorStatus GetById(int Id)
        {
            return _tumorStatusRepository.Get(a => a.ID == Id);
        }
        public List<TumorStatus> GetList()
        {
            return _tumorStatusRepository.GetList().ToList();
        }
        public List<TumorStatus> GetActives(int CompanyID)
        {
            return _tumorStatusRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<TumorStatusVM> GetListTumorStatuss(int FormID)
        {
            return new List<TumorStatusVM>(_tumorStatusRepository.GetListTumorStatuss(FormID).ToList());
        }
        public TumorStatusVM GetListTumorStatussID(int id)
        {
            return _tumorStatusRepository.GetListTumorStatussID(id);
        }
        public TumorStatus GetActivesById(int id)
        {
            return _tumorStatusRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(TumorStatus appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _tumorStatusRepository.Add(appUser);
            return "Ok";
        }
        public string Update(TumorStatus appUser)
        {
            var User = _tumorStatusRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _tumorStatusRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(TumorStatus appUser)
        {
            var User = _tumorStatusRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _tumorStatusRepository.Update(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
