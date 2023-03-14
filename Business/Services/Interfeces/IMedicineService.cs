using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IMedicineService
    {
        Medicine GetById(int Id);
        List<Medicine> GetList();
        List<Medicine> GetActives(int CompanyID);
        Medicine GetActivesById(int id);
        List<MedicineVM> GetListMedicines(int FormID);
       MedicineVM GetListMedicinesID(int id); 

        string Add(Medicine medicine);
        string Update(Medicine medicine);
        string Delete(Medicine medicine);
        object GetById();
    }
}
