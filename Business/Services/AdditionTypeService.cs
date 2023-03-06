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
   public class AdditionTypeService : IAdditionTypeService
    {
        private IAdditionTypeRepository _additionTypeRepository;
        public AdditionTypeService(IAdditionTypeRepository additionTypeRepository)
        {
            _additionTypeRepository = additionTypeRepository;
        }

        public AdditionType GetById(int Id)
        {
            return _additionTypeRepository.Get(a => a.ID == Id);
        }
        public List<AdditionType> GetList()
        {
            return _additionTypeRepository.GetList().ToList();
        }
        public List<AdditionType> GetActives(int CompanyID)
        {
            return _additionTypeRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public AdditionType GetActivesById(int id)
        {
            return _additionTypeRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(AdditionType additionType)
        {
            additionType.CreatedDate = DateTime.Now;

            _additionTypeRepository.Add(additionType);
            return "Ok";
        }
        public string Update(AdditionType additionType)
        {
            var User = _additionTypeRepository.Get(a => a.ID == additionType.ID);
            additionType.CreatedDate = User.CreatedDate;
            additionType.ModifiedDate = DateTime.Now;
            additionType.Status = 2;
            _additionTypeRepository.Update(additionType);
            return "Ok";
        }
        public string Delete(AdditionType additionType)
        {
            var User = _additionTypeRepository.Get(a => a.ID == additionType.ID);
            additionType.CreatedDate = User.CreatedDate;
            additionType.ModifiedDate = User.ModifiedDate;
            additionType.DeletedDate = DateTime.Now;
            additionType.Status = 3;
            _additionTypeRepository.Update(additionType);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
