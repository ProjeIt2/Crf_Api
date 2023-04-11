using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ISocialLifeService
    {
        SocialLife GetById(int Id);
        SocialLife GetByFormId(int FormId);
        List<SocialLife> GetList();
        SocialLife GetActivesById(int id);
        List<SocialLife> GetActives(int CompanyID);
        string Add(SocialLife socialLife);
        string Update(SocialLife socialLife);
        string Delete(SocialLife socialLife);
        object GetById();
    }
}
