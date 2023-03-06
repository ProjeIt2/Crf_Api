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
   public class PhaseService : IPhaseService
    {
        private IPhaseRepository _phaseRepository;
        public PhaseService(IPhaseRepository phaseRepository)
        {
            _phaseRepository = phaseRepository;
        }

        public Phase GetById(int Id)
        {
            return _phaseRepository.Get(a => a.ID == Id);
        }
        public List<Phase> GetList()
        {
            return _phaseRepository.GetList().ToList();
        }
        public List<Phase> GetActives(int CompanyID)
        {
            return _phaseRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Phase GetActivesById(int id)
        {
            return _phaseRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Phase phase)
        {
            phase.CreatedDate = DateTime.Now;

            _phaseRepository.Add(phase);
            return "Ok";
        }
        public string Update(Phase phase)
        {
            var User = _phaseRepository.Get(a => a.ID == phase.ID);
            phase.CreatedDate = User.CreatedDate;
            phase.ModifiedDate = DateTime.Now;
            phase.Status = 2;
            _phaseRepository.Update(phase);
            return "Ok";
        }
        public string Delete(Phase phase)
        {
            var User = _phaseRepository.Get(a => a.ID == phase.ID);
            phase.CreatedDate = User.CreatedDate;
            phase.ModifiedDate = User.ModifiedDate;
            phase.DeletedDate = DateTime.Now;
            phase.Status = 3;
            _phaseRepository.Update(phase);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
