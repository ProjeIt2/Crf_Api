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
    public class CancerTreatmentService : ICancerTreatmentService
    {
        private ICancerTreatmentRepository _cancerTreatmentRepository;
        public CancerTreatmentService(ICancerTreatmentRepository cancerTreatmentRepository)
        {
            _cancerTreatmentRepository = cancerTreatmentRepository;
        }

        public CancerTreatment GetById(int Id)
        {
            return _cancerTreatmentRepository.Get(a => a.ID == Id);
        }
        public List<CancerTreatment> GetList()
        {
            return _cancerTreatmentRepository.GetList().ToList();
        }
        public List<CancerTreatment> GetActives(int CompanyID)
        {
            return _cancerTreatmentRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<CancerTreatmentVM> GetListCancerTreatments(int FormID)
        {
            return new List<CancerTreatmentVM>(_cancerTreatmentRepository.GetListCancerTreatments(FormID).ToList());
        }
        public CancerTreatmentVM GetListCancerTreatmentsID(int id)
        {
            return _cancerTreatmentRepository.GetListCancerTreatmentsID(id);
        }
        public CancerTreatment GetActivesById(int id)
        {
            return _cancerTreatmentRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(CancerTreatment appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _cancerTreatmentRepository.Add(appUser);
            return "Ok";
        }
        public string Update(CancerTreatment appUser)
        {
            var User = _cancerTreatmentRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _cancerTreatmentRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(CancerTreatment appUser)
        {
            var User = _cancerTreatmentRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _cancerTreatmentRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
