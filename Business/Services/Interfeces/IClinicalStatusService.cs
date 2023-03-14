using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IClinicalStatusService
    {
        ClinicalStatus GetById(int Id);
        List<ClinicalStatus> GetList();
        List<ClinicalStatus> GetActives(int CompanyID);
        ClinicalStatus GetActivesById(int id);
        List<ClinicalStatusVM> GetListClinicalStatuss(int FormID);
        string Add(ClinicalStatus clinicalStatus);
        string Update(ClinicalStatus clinicalStatus);
        string Delete(ClinicalStatus clinicalStatus);
        object GetById();
    }
}
