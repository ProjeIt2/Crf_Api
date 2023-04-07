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
    public class ViralInfectionService : IViralInfectionService
    {
        private IViralInfectionRepository _viralInfectionRepository;
        public ViralInfectionService(IViralInfectionRepository viralInfectionRepository)
        {
            _viralInfectionRepository = viralInfectionRepository;
        }

        public ViralInfection GetById(int Id)
        {
            return _viralInfectionRepository.Get(a => a.ID == Id);
        }
        public List<ViralInfection> GetList()
        {
            return _viralInfectionRepository.GetList().ToList();
        }
        public List<ViralInfection> GetActives(int CompanyID)
        {
            return _viralInfectionRepository.GetList(x => x.CompanyID == 2 && x.Status != 3).ToList();
        }
        public List<ViralInfectionVM> GetListViralInfections(int FormID)
        {
            return new List<ViralInfectionVM>(_viralInfectionRepository.GetListViralInfections(FormID).ToList());
        }
        public ViralInfection GetActivesById(int id)
        {
            return _viralInfectionRepository.Get(x => x.ID == id && x.Status != 3);
        }

        public string Add(ViralInfection appUser)
        {
            appUser.CreatedDate = DateTime.Now;

            _viralInfectionRepository.Add(appUser);
            return "Ok";
        }
        public string Update(ViralInfection appUser)
        {
            var User = _viralInfectionRepository.Get(a => a.ID == appUser.ID);
            appUser.CreatedDate = User.CreatedDate;
            appUser.ModifiedDate = DateTime.Now;
            appUser.Status = 2;
            _viralInfectionRepository.Update(appUser);
            return "Ok";
        }
        public string Delete(ViralInfection appUser)
        {
            var Data = _viralInfectionRepository.Get(a => a.ID == appUser.ID);
            Data.DeletedDate = DateTime.Now;
            Data.Status = 3;
            _viralInfectionRepository.Delete(Data);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
