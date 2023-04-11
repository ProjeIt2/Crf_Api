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
   public class JobService : IJobService
    {
        private IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Job GetById(int Id)
        {
            return _jobRepository.Get(a => a.ID == Id);
        }
        public List<Job> GetList()
        {
            return _jobRepository.GetList().ToList();
        }
        public Job GetActivesById(int id)
        {
            return _jobRepository.GetList(x => x.ID == id && x.Status != 3).FirstOrDefault();
        }
        public List<Job> GetActives(int CompanyID)
        {
            return _jobRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(Job job)
        {
            job.CreatedDate = DateTime.Now;

            _jobRepository.Add(job);
            return "Ok";
        }
        public string Update(Job job)
        {
            var User = _jobRepository.Get(a => a.ID == job.ID);
            job.CreatedDate = User.CreatedDate;
            job.ModifiedDate = DateTime.Now;
            job.Status = 2;
            _jobRepository.Update(job);
            return "Ok";
        }
        public string Delete(Job job)
        {
            var User = _jobRepository.Get(a => a.ID == job.ID);
            job.CreatedDate = User.CreatedDate;
            job.ModifiedDate = User.ModifiedDate;
            job.DeletedDate = DateTime.Now;
            job.Status = 3;
            _jobRepository.Update(job);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
