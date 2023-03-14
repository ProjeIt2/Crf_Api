using Core;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICancerTreatmentRepository : IEntityRepository<CancerTreatment>
    {
        List<CancerTreatmentVM> GetListCancerTreatments(int FormID);
        CancerTreatmentVM GetListCancerTreatmentsID(int id);
    }
}
