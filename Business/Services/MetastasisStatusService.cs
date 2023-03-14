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
    public class MetastasisStatusService : IMetastasisStatusService
    {
        private IMetastasisStatusRepository _metastasisStatusRepository;
        public MetastasisStatusService(IMetastasisStatusRepository metastasisStatusRepository)
        {
            _metastasisStatusRepository = metastasisStatusRepository;
        }

        public MetastasisStatus GetById(int Id)
        {
            return _metastasisStatusRepository.Get(a => a.ID == Id);
        }
        public List<MetastasisStatus> GetList()
        {
            return _metastasisStatusRepository.GetList().ToList();
        }
        public List<MetastasisStatus> GetActives(int CompanyID)
        {
            return _metastasisStatusRepository.GetList(x=>x.CompanyID==2 && x.Status != 3).ToList();
        }
        public List<MetastasisStatusVM> GetListMetastasisStatuss(int FormID)
        {
            return new List<MetastasisStatusVM>(_metastasisStatusRepository.GetListMetastasisStatuss(FormID).ToList());
        }
        public MetastasisStatusVM GetListMetastasisStatussID(int id)
        {
            return _metastasisStatusRepository.GetListMetastasisStatussID(id);
        }
        public MetastasisStatus GetActivesById(int id)
        {
            return _metastasisStatusRepository.Get(x=>x.ID==id&&x.Status!=3);
        }
  
        public string Add(MetastasisStatus appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _metastasisStatusRepository.Add(appUser);
            return "Ok";
        }
        public string Update(MetastasisStatus appUser)
        {
            var User = _metastasisStatusRepository.Get(a => a.ID== appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _metastasisStatusRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(MetastasisStatus appUser)
        {
            var User = _metastasisStatusRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = User.ModifiedDate;
            appUser.DeletedDate = DateTime.Now;
            appUser.Status = 3;
            _metastasisStatusRepository.Delete(appUser);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
