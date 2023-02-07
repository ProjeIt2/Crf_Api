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
    public class SponsorService : ISponsorService
    {
        private ISponsorRepository _sponsorRepository;
        public SponsorService(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public Sponsor GetById(int Id)
        {
            return _sponsorRepository.Get(a => a.SponsorId == Id);
        }

        public List<Sponsor> GetList()
        {
            return _sponsorRepository.GetList().ToList();
        }
        public string Add(Sponsor sponsor)
        {
            _sponsorRepository.Add(sponsor);
            return "Ok";
        }
        public string Update(Sponsor sponsor)
        {
            _sponsorRepository.Update(sponsor);
            return "Ok";
        }
        public string Delete(Sponsor sponsor)
        {
            _sponsorRepository.Delete(sponsor);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
