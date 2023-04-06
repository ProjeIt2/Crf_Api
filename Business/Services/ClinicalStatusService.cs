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
    public class ClinicalStatusService : IClinicalStatusService
    {
        private IClinicalStatusRepository _clinicalStatusRepository;
        public ClinicalStatusService(IClinicalStatusRepository clinicalStatusRepository)
        {
            _clinicalStatusRepository = clinicalStatusRepository;
        }

        public ClinicalStatus GetById(int Id)
        {
            return _clinicalStatusRepository.Get(a => a.ID == Id);
        }
        public List<ClinicalStatus> GetList()
        {
            return _clinicalStatusRepository.GetList().ToList();
        }
        public List<ClinicalStatus> GetActives(int CompanyID)
        {
            return _clinicalStatusRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<ClinicalStatusVM> GetListClinicalStatuss(int FormID,int CompanyID)
        {
            var test = _clinicalStatusRepository.GetList(x => x.FormID == FormID && x.Status != 3).ToList();
            return new List<ClinicalStatusVM>(_clinicalStatusRepository.GetListClinicalStatuss(FormID, CompanyID).ToList());
        }
        public ClinicalStatusVM GetListClinicalStatu(int id, int CompanyID)
        {
            var test = _clinicalStatusRepository.GetList(x => x.ID == id && x.Status != 3).ToList();
            return  _clinicalStatusRepository.GetListClinicalStatu(id, CompanyID);
        }
        public ClinicalStatus GetActivesById(int id)
        {
            return _clinicalStatusRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(ClinicalStatus appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _clinicalStatusRepository.Add(appUser);
            return "Ok";
        }
        public string Update(ClinicalStatus appUser)
        {
            var User = _clinicalStatusRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _clinicalStatusRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(ClinicalStatus appUser)
        {
            var User = _clinicalStatusRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _clinicalStatusRepository.Update(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
