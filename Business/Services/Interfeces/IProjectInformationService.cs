using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IProjectInformationService
    {
        ProjectInformation GetById(int Id);
        List<ProjectInformation> GetList();
        List<ProjectInformation> GetActivesById(int CompanyID);
      
        string Add(ProjectInformation projectInformation);
        string Update(ProjectInformation projectInformation);
        string Delete(ProjectInformation projectInformation);
        object GetById();
    }
}
