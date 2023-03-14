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
   public class LymphNodeService : ILymphNodeService
    {
        private ILymphNodeRepository _lymphNodeRepository;
        public LymphNodeService(ILymphNodeRepository lymphNodeRepository)
        {
            _lymphNodeRepository = lymphNodeRepository;
        }

        public LymphNode GetById(int Id)
        {
            return _lymphNodeRepository.Get(a => a.ID == Id);
        }
        public List<LymphNode> GetList()
        {
            return _lymphNodeRepository.GetList().ToList();
        }
        public List<LymphNode> GetActives(int CompanyID)
        {
            return _lymphNodeRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public LymphNode GetActivesById(int id)
        {
            return _lymphNodeRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(LymphNode lymphNode)
        {
            lymphNode.CreatedDate = DateTime.Now;

            _lymphNodeRepository.Add(lymphNode);
            return "Ok";
        }
        public string Update(LymphNode lymphNode)
        {
            var User = _lymphNodeRepository.Get(a => a.ID == lymphNode.ID);
            lymphNode.CreatedDate = User.CreatedDate;
            lymphNode.ModifiedDate = DateTime.Now;
            lymphNode.Status = 2;
            _lymphNodeRepository.Update(lymphNode);
            return "Ok";
        }
        public string Delete(LymphNode lymphNode)
        {
            var User = _lymphNodeRepository.Get(a => a.ID == lymphNode.ID);
            lymphNode.CreatedDate = User.CreatedDate;
            lymphNode.ModifiedDate = User.ModifiedDate;
            lymphNode.DeletedDate = DateTime.Now;
            lymphNode.Status = 3;
            _lymphNodeRepository.Update(lymphNode);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
