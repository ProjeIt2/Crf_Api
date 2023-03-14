using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IReportService
    {
        Report GetById(int Id);
        List<Report> GetList();
        List<Report> GetActives(int CompanyID);
        Report GetActivesById(int id);
        string Add(Report report);
        string Update(Report report);
        string Delete(Report report);
        object GetById();
    }
}
