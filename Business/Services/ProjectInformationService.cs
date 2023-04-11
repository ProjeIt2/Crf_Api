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
    public class ProjectInformationService : IProjectInformationService
    {
        private IProjectInformationRepository _projectInformationRepository;
        public ProjectInformationService(IProjectInformationRepository projectInformationRepository)
        {
            _projectInformationRepository = projectInformationRepository;
        }

        public ProjectInformation GetById(int Id)
        {
            return _projectInformationRepository.Get(a => a.ID == Id);
        }
        public List<ProjectInformation> GetList()
        {
            return _projectInformationRepository.GetList().ToList();
        }
        public ProjectInformation GetActivesById(int id)
        {
            return _projectInformationRepository.GetList(x=>x.ID==id&&x.Status!=3).FirstOrDefault();
        }
        public List<ProjectInformation> GetActives(int CompanyID)
        {
            return _projectInformationRepository.GetList(x => x.CompanyID == CompanyID && x.Status != 3).ToList();
        }
        public string Add(ProjectInformation projectInformation)
        {
            projectInformation.CreatedDate = DateTime.Now;

            _projectInformationRepository.Add(projectInformation);
            return "Ok";
        }
        public string Update(ProjectInformation projectInformation)
        {
            var User = _projectInformationRepository.Get(a => a.ID== projectInformation.ID);
            projectInformation.CreatedDate = User.CreatedDate;
            projectInformation.ModifiedDate = DateTime.Now;
            projectInformation.Status = 2;
            _projectInformationRepository.Update(projectInformation);
            return "Ok";
        }
        public string Delete(ProjectInformation projectInformation)
        {
            var User = _projectInformationRepository.Get(a => a.ID == projectInformation.ID);
            projectInformation.CreatedDate = User.CreatedDate;
            projectInformation.ModifiedDate = User.ModifiedDate;
            projectInformation.DeletedDate = DateTime.Now;
            projectInformation.Status = 3;
            _projectInformationRepository.Update(projectInformation);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
