using Core;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{

    public class MedicineRepository : EntityRepositoryBase<Medicine, ProjeItContext>, IMedicineRepository
    {

        public List<MedicineVM> GetListMedicines(int FormID)
        {
            var _result = new List<MedicineVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _medicine in context.Medicines.Where(x => x.FormID == FormID && x.Status != 3)
                         join _form in context.Forms on _medicine.FormID equals _form.ID
                              join _pill in context.Pills on _medicine.PillID equals _pill.ID
                              join _usage in context.Usages on _medicine.UsageID equals _usage.ID
                              join _currentStatus in context.CurrentStatus on _medicine.CurrentStatusID equals _currentStatus.ID

                              select new MedicineVM
                              {
                                  ID = _medicine.ID,
                                  FormID = _medicine.FormID,
                                  Dosage = _medicine.Dosage,
                                  Unit = _medicine.Unit,
                                  Density = _medicine.Density,
                                  Barcode = _form.Barcode,
                                   PillID=_pill.ID,
                                   PillName=_pill.PillName,
                                   UsageID=_usage.ID,
                                   UsageType=_usage.UsageType,
                                   CurrentStatusID=_currentStatus.ID,
                                   Current_Status=_currentStatus.Current_Status,
                              }).ToList();

                _result = result;


            }
            return _result;
        }

        public MedicineVM GetListMedicinesID(int id)
        {
            var _resultID = new MedicineVM();
            using (var context = new ProjeItContext())
            {
                var resultID = (from _medicine in context.Medicines.Where(x => x.ID == id&&x.Status!=3)
                              join _form in context.Forms on _medicine.FormID equals _form.ID
                              join _pill in context.Pills on _medicine.PillID equals _pill.ID
                              join _usage in context.Usages on _medicine.UsageID equals _usage.ID
                              join _currentStatus in context.CurrentStatus on _medicine.CurrentStatusID equals _currentStatus.ID

                              select new MedicineVM
                              {
                                  ID = _medicine.ID,
                                  FormID = _medicine.FormID,
                                  Dosage = _medicine.Dosage,
                                  Unit = _medicine.Unit,
                                  Density = _medicine.Density,
                                  Barcode = _form.Barcode,
                                  PillID = _pill.ID,
                                  PillName = _pill.PillName,
                                  UsageID = _usage.ID,
                                  UsageType = _usage.UsageType,
                                  CurrentStatusID = _currentStatus.ID,
                                  Current_Status = _currentStatus.Current_Status,
                              }).FirstOrDefault();

                _resultID = resultID;


            }
            return _resultID;
        }

    }
}
