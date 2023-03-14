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
   public class ReportService : IReportService
    {
        private IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public Report GetById(int Id)
        {
            return _reportRepository.Get(a => a.ID == Id);
        }
        public List<Report> GetList()
        {
            return _reportRepository.GetList().ToList();
        }
        public List<Report> GetActives(int CompanyID)
        {
            return _reportRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public Report GetActivesById(int id)
        {
            return _reportRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(Report report)
        {
            report.CreatedDate = DateTime.Now;

            _reportRepository.Add(report);
            return "Ok";
        }
        public string Update(Report report)
        {
            var User = _reportRepository.Get(a => a.ID == report.ID);
            report.CreatedDate = User.CreatedDate;
            report.ModifiedDate = DateTime.Now;
            report.Status = 2;
            _reportRepository.Update(report);
            return "Ok";
        }
        public string Delete(Report report)
        {
            var User = _reportRepository.Get(a => a.ID == report.ID);
            report.CreatedDate = User.CreatedDate;
            report.ModifiedDate = User.ModifiedDate;
            report.DeletedDate = DateTime.Now;
            report.Status = 3;
            _reportRepository.Update(report);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
