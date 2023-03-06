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
   public class OperationProcedureService : IOperationProcedureService
    {
        private IOperationProcedureRepository _operationProcedureRepository;
        public OperationProcedureService(IOperationProcedureRepository operationProcedureRepository)
        {
            _operationProcedureRepository = operationProcedureRepository;
        }

        public OperationProcedure GetById(int Id)
        {
            return _operationProcedureRepository.Get(a => a.ID == Id);
        }
        public List<OperationProcedure> GetList()
        {
            return _operationProcedureRepository.GetList().ToList();
        }
        public List<OperationProcedure> GetActives(int CompanyID)
        {
            return _operationProcedureRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public OperationProcedure GetActivesById(int id)
        {
            return _operationProcedureRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(OperationProcedure operationProcedure)
        {
            operationProcedure.CreatedDate = DateTime.Now;

            _operationProcedureRepository.Add(operationProcedure);
            return "Ok";
        }
        public string Update(OperationProcedure operationProcedure)
        {
            var User = _operationProcedureRepository.Get(a => a.ID == operationProcedure.ID);
            operationProcedure.CreatedDate = User.CreatedDate;
            operationProcedure.ModifiedDate = DateTime.Now;
            operationProcedure.Status = 2;
            _operationProcedureRepository.Update(operationProcedure);
            return "Ok";
        }
        public string Delete(OperationProcedure operationProcedure)
        {
            var User = _operationProcedureRepository.Get(a => a.ID == operationProcedure.ID);
            operationProcedure.CreatedDate = User.CreatedDate;
            operationProcedure.ModifiedDate = User.ModifiedDate;
            operationProcedure.DeletedDate = DateTime.Now;
            operationProcedure.Status = 3;
            _operationProcedureRepository.Update(operationProcedure);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
