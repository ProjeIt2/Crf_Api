using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IFamilyMedicalHistoryService
    {
        FamilyMedicalHistory GetById(int Id);
        List<FamilyMedicalHistory> GetList();
        List<FamilyMedicalHistory> GetActives(int CompanyID);
        FamilyMedicalHistory GetActivesById(int id);
        List<FamilyMedicalHistoryVM> GetListFamilyMedicalHistorys(int FormID);
        string Add(FamilyMedicalHistory familyMedicalHistory);
        string Update(FamilyMedicalHistory familyMedicalHistory);
        string Delete(FamilyMedicalHistory familyMedicalHistory);
        object GetById();
    }
}
