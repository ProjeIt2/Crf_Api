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
   public class DoctorRequestedReportService : IDoctorRequestedReportService
    {
        private IDoctorRequestedReportRepository _doctorRequestedReportRepository;
        public DoctorRequestedReportService(IDoctorRequestedReportRepository doctorRequestedReportRepository)
        {
            _doctorRequestedReportRepository = doctorRequestedReportRepository;
        }

        public DoctorRequestedReport GetById(int Id)
        {
            return _doctorRequestedReportRepository.Get(a => a.ID == Id);
        }
        public List<DoctorRequestedReport> GetList()
        {
            return _doctorRequestedReportRepository.GetList().ToList();
        }
        public List<DoctorRequestedReport> GetActives(int CompanyID)
        {
            return _doctorRequestedReportRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<DoctorRequestedReport> GetProjectID(int ProjectID)
        {
            return _doctorRequestedReportRepository.GetList(x => x.ProjectInformationID == ProjectID && x.Status != 3).ToList();
        }
        public DoctorRequestedReport GetActivesById(int id)
        {
            return _doctorRequestedReportRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(DoctorRequestedReport doctorRequestedReport)
        {
            doctorRequestedReport.CreatedDate = DateTime.Now;

            _doctorRequestedReportRepository.Add(doctorRequestedReport);
            return "Ok";
        }
        public string Update(DoctorRequestedReport doctorRequestedReport)
        {
            var User = _doctorRequestedReportRepository.Get(a => a.ID == doctorRequestedReport.ID);
            doctorRequestedReport.CreatedDate = User.CreatedDate;
            doctorRequestedReport.ModifiedDate = DateTime.Now;
            doctorRequestedReport.Status = 2;
            _doctorRequestedReportRepository.Update(doctorRequestedReport);
            return "Ok";
        }
        public string Delete(DoctorRequestedReport doctorRequestedReport)
        {
            var User = _doctorRequestedReportRepository.Get(a => a.ID == doctorRequestedReport.ID);
            doctorRequestedReport.CreatedDate = User.CreatedDate;
            doctorRequestedReport.ModifiedDate = User.ModifiedDate;
            doctorRequestedReport.DeletedDate = DateTime.Now;
            doctorRequestedReport.Status = 3;
            _doctorRequestedReportRepository.Update(doctorRequestedReport);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
