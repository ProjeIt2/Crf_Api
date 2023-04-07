using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDoctorRequestedReportService
    {
        DoctorRequestedReport GetById(int Id);
        List<DoctorRequestedReport> GetList();
        List<DoctorRequestedReport> GetActives(int CompanyID);
        List<DoctorRequestedReport> GetProjectID(int ProjectID);
        DoctorRequestedReport GetActivesById(int id);
        string Add(DoctorRequestedReport doctorRequestedReport);
        string Update(DoctorRequestedReport doctorRequestedReport);
        string Delete(DoctorRequestedReport doctorRequestedReport);
        object GetById();
    }
}
