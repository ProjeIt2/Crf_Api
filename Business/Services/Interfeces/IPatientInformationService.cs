using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IPatientInformationService
    {
        PatientInformation GetById(int Id);
        PatientInformation GetByFormId(int FormId);
        List<PatientInformation> GetList();
        List<PatientInformation> GetActivesById(int CompanyID);
        string Add(PatientInformation patientInformation);
        string Update(PatientInformation patientInformation);
        string Delete(PatientInformation patientInformation);
        object GetById();
    }
}
