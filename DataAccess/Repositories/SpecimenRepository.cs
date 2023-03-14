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

    public class SpecimenRepository : EntityRepositoryBase<Specimen, ProjeItContext>, ISpecimenRepository
    {

        public List<SpecimenVM> GetListSpecimens(int FormID)
        {
            var _result = new List<SpecimenVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _specimen in context.Specimen.Where(x => x.FormID == FormID && x.Status != 3)
                         join _form in context.Forms on _specimen.FormID equals _form.ID
                              join _opPros in context.OperationProcedures on _specimen.OperationProcedureID equals _opPros.ID
                              join _anatArea in context.AnatomicalAreas on _specimen.AnatomicalAreaID equals _anatArea.ID
                              join _aditType in context.AdditionTypes on _specimen.AdditionTypeID equals _aditType.ID
                              select new SpecimenVM
                              {
                                  ID = _specimen.ID,
                                  FormID = _specimen.FormID,
                                  AdditionDate= _specimen.AdditionDate,
                                  AdditionHour= _specimen.AdditionHour,
                                  Barcode = _form.Barcode,
                                  OperationProcedureID = _opPros.ID,
                                  Operation_Procedure= _opPros.Operation_Procedure,
                                  AnatomicalAreaID = _anatArea.ID,
                                  Anatomical_Area = _anatArea.Anatomical_Area,
                                  AdditionTypeID = _aditType.ID,
                                  Addition_Type = _aditType.Addition_Type,

                              }).ToList();

                _result = result;

            }
            return _result;
        }


        public SpecimenVM GetListSpecimensID(int id)
        {
            var _result = new SpecimenVM();
            using (var context = new ProjeItContext())
            {
                var result = (from _specimen in context.Specimen.Where(x => x.ID == id&&x.Status!=3)
                              join _form in context.Forms on _specimen.FormID equals _form.ID
                              join _opPros in context.OperationProcedures on _specimen.OperationProcedureID equals _opPros.ID
                              join _anatArea in context.AnatomicalAreas on _specimen.AnatomicalAreaID equals _anatArea.ID
                              join _aditType in context.AdditionTypes on _specimen.AdditionTypeID equals _aditType.ID
                              select new SpecimenVM
                              {
                                  ID = _specimen.ID,
                                  FormID = _specimen.FormID,
                                  AdditionDate = _specimen.AdditionDate,
                                  AdditionHour = _specimen.AdditionHour,
                                  Barcode = _form.Barcode,
                                  OperationProcedureID = _opPros.ID,
                                  Operation_Procedure = _opPros.Operation_Procedure,
                                  AnatomicalAreaID = _anatArea.ID,
                                  Anatomical_Area = _anatArea.Anatomical_Area,
                                  AdditionTypeID = _aditType.ID,
                                  Addition_Type = _aditType.Addition_Type,

                              }).FirstOrDefault();

                _result = result;

            }
            return _result;
        }
    }
}
