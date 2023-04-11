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
        ProjectInformation GetActivesById(int id);
        List<ProjectInformation> GetActives(int CompanyID);
        string Add(ProjectInformation projectInformation);
        string Update(ProjectInformation projectInformation);
        string Delete(ProjectInformation projectInformation);
        object GetById();
    }
}
