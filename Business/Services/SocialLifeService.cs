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
    public class SocialLifeService : ISocialLifeService
    {
        private ISocialLifeRepository _socialLifeRepository;
        public SocialLifeService(ISocialLifeRepository socialLifeRepository)
        {
            _socialLifeRepository = socialLifeRepository;
        }

        public SocialLife GetById(int Id)
        {
            return _socialLifeRepository.Get(a => a.ID == Id);
        }
        public SocialLife GetByFormId(int FormId)
        {
            return _socialLifeRepository.Get(a => a.FormID == FormId);
        }
        public List<SocialLife> GetList()
        {
            return _socialLifeRepository.GetList().ToList();
        }

        public List<SocialLife> GetActivesById(int CompanyID)
        {
            return _socialLifeRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }
        public string Add(SocialLife socialLife)
        {
            socialLife.CreatedDate = DateTime.Now;

            _socialLifeRepository.Add(socialLife);
            return "Ok";
        }
        public string Update(SocialLife socialLife)
        {
            var patInf = _socialLifeRepository.Get(a => a.FormID== socialLife.FormID);
            socialLife.CreatedDate = patInf.CreatedDate;
            socialLife.DeletedDate = patInf.DeletedDate;
            socialLife.ModifiedDate = DateTime.Now;
            socialLife.Status = 2;
            socialLife.ID = patInf.ID;
            socialLife.FormID = patInf.FormID;
            socialLife.CompanyID = patInf.CompanyID;
            _socialLifeRepository.Update(socialLife);
            return "Ok";
        }
        public string Delete(SocialLife socialLife)
        {
            var User = _socialLifeRepository.Get(a => a.ID == socialLife.ID);
            socialLife.CreatedDate = User.CreatedDate;
            socialLife.ModifiedDate = User.ModifiedDate;
            socialLife.DeletedDate = DateTime.Now;
            socialLife.Status = 3;
            _socialLifeRepository.Update(socialLife);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
