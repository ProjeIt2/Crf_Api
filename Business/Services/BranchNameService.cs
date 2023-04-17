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
   public class BranchNameService : IBranchNameService
    {
        private IBranchNameRepository _branchNameRepository;
        public BranchNameService(IBranchNameRepository branchNameRepository)
        {
            _branchNameRepository = branchNameRepository;
        }

        public BranchName GetById(int Id)
        {
            return _branchNameRepository.Get(a => a.ID == Id);
        }
        public List<BranchName> GetList()
        {
            return _branchNameRepository.GetList().ToList();
        }
        public List<BranchName> GetActives(int CompanyID)
        {
            return _branchNameRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public BranchName GetActivesById(int id)
        {
            return _branchNameRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(BranchName branchName)
        {
            branchName.CreatedDate = DateTime.Now;

            _branchNameRepository.Add(branchName);
            return "Ok";
        }
        public string Update(BranchName branchName)
        {
            var User = _branchNameRepository.Get(a => a.ID == branchName.ID);
            branchName.CreatedDate = User.CreatedDate;
            branchName.ModifiedDate = DateTime.Now;
            branchName.Status = 2;
            _branchNameRepository.Update(branchName);
            return "Ok";
        }
        public string Delete(BranchName branchName)
        {
            var User = _branchNameRepository.Get(a => a.ID == branchName.ID);
            branchName.CreatedDate = User.CreatedDate;
            branchName.ModifiedDate = User.ModifiedDate;
            branchName.DeletedDate = DateTime.Now;
            branchName.Status = 3;
            _branchNameRepository.Update(branchName);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
