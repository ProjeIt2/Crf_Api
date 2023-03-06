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
   public class AnatomicalAreaService : IAnatomicalAreaService
    {
        private IAnatomicalAreaRepository _anatomicalAreaRepository;
        public AnatomicalAreaService(IAnatomicalAreaRepository anatomicalAreaRepository)
        {
            _anatomicalAreaRepository = anatomicalAreaRepository;
        }

        public AnatomicalArea GetById(int Id)
        {
            return _anatomicalAreaRepository.Get(a => a.ID == Id);
        }
        public List<AnatomicalArea> GetList()
        {
            return _anatomicalAreaRepository.GetList().ToList();
        }
        public List<AnatomicalArea> GetActives(int CompanyID)
        {
            return _anatomicalAreaRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public AnatomicalArea GetActivesById(int id)
        {
            return _anatomicalAreaRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(AnatomicalArea anatomicalArea)
        {
            anatomicalArea.CreatedDate = DateTime.Now;

            _anatomicalAreaRepository.Add(anatomicalArea);
            return "Ok";
        }
        public string Update(AnatomicalArea anatomicalArea)
        {
            var User = _anatomicalAreaRepository.Get(a => a.ID == anatomicalArea.ID);
            anatomicalArea.CreatedDate = User.CreatedDate;
            anatomicalArea.ModifiedDate = DateTime.Now;
            anatomicalArea.Status = 2;
            _anatomicalAreaRepository.Update(anatomicalArea);
            return "Ok";
        }
        public string Delete(AnatomicalArea anatomicalArea)
        {
            var User = _anatomicalAreaRepository.Get(a => a.ID == anatomicalArea.ID);
            anatomicalArea.CreatedDate = User.CreatedDate;
            anatomicalArea.ModifiedDate = User.ModifiedDate;
            anatomicalArea.DeletedDate = DateTime.Now;
            anatomicalArea.Status = 3;
            _anatomicalAreaRepository.Update(anatomicalArea);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
