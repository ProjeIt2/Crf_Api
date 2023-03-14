using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ICancerTreatmentService
    {
        CancerTreatment GetById(int Id);
        List<CancerTreatment> GetList();
        List<CancerTreatment> GetActives(int CompanyID);
        CancerTreatment GetActivesById(int id);
        List<CancerTreatmentVM> GetListCancerTreatments(int FormID);
        CancerTreatmentVM GetListCancerTreatmentsID(int id);
        string Add(CancerTreatment cancerTreatment);
        string Update(CancerTreatment cancerTreatment);
        string Delete(CancerTreatment cancerTreatment);
        object GetById();
    }
}
