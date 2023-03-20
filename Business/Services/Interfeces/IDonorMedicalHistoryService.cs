using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IDonorMedicalHistoryService
    {
        DonorMedicalHistory GetById(int Id);
        List<DonorMedicalHistory> GetList();
        List<DonorMedicalHistory> GetActives(int CompanyID);
        DonorMedicalHistory GetActivesById(int id);
        List<DonorMedicalHistoryVM> GetListDonorMedicalHistorys(int FormID);
        string Add(DonorMedicalHistory donorMedicalHistory);
        string Update(DonorMedicalHistory donorMedicalHistory);
        string Delete(DonorMedicalHistory donorMedicalHistory);
        object GetById();
    }
}
