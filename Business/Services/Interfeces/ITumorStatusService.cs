using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ITumorStatusService
    {
        TumorStatus GetById(int Id);
        List<TumorStatus> GetList();
        List<TumorStatus> GetActives(int CompanyID);
        TumorStatus GetActivesById(int id);
        List<TumorStatusVM> GetListTumorStatuss(int FormID);
        TumorStatusVM GetListTumorStatussID(int id);
        string Add(TumorStatus tumorStatus);
        string Update(TumorStatus tumorStatus);
        string Delete(TumorStatus tumorStatus);
        object GetById();
    }
}
