using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ICurrentStatusService
    {
        CurrentStatus GetById(int Id);
        List<CurrentStatus> GetList();
        List<CurrentStatus> GetActives(int CompanyID);
        CurrentStatus GetActivesById(int id);
        string Add(CurrentStatus currentStatus);
        string Update(CurrentStatus currentStatus);
        string Delete(CurrentStatus currentStatus);
        object GetById();
    }
}
