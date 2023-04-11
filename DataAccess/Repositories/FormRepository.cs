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
    public class FormRepository : EntityRepositoryBase<Form, ProjeItContext>, IFormRepository
    {
   
        public List<FormListVM> GetListForms(int CompanyID)
        {
            var _result = new List<FormListVM>();
            using (var context = new ProjeItContext())
            {
                var result = (from _form in context.Forms.Where(x=>x.CompanyID== CompanyID&&x.Status!=3)
                              join _hospital in context.Hospitals on _form.HospitalID equals _hospital.ID
                              join _doctor in context.Doctors on _form.DoctorID equals _doctor.ID
                              join _personel in context.Personnels on _form.PersonnelID equals _personel.ID
                              join _projecyInfo in context.ProjectInformations on _form.ProjectInformationID equals _projecyInfo.ID
                              join _patInf in context.PatientInformations on _form.ID equals _patInf.FormID
                              select new FormListVM
                              {
                                  ID = _form.ID,
                                  Barcode = _form.Barcode,
                                  CompanyID=_form.CompanyID,
                                  FormFullStatus = _form.FormFullStatus,
                                  CreatedDate = _form.CreatedDate,
                                  HospitalID = _hospital.ID,
                                  HospitalName = _hospital.Name,
                                  DoctorID = _doctor.ID,
                                  DoctorFullName = _doctor.FirstName + _doctor.LastName,
                                  PersonnelID = _personel.ID,
                                  PersonnelFullName = _personel.FirstName + _personel.LastName,
                                  ProjectInformationID = _projecyInfo.ID,
                                  ProjectName = _projecyInfo.ProjectName,
                                  PatientInformationID= _patInf.ID,
                                  ProtokolNumber = _patInf.ProtokolNumber,
                                  TcNo = _patInf.TcNo,
                              }).ToList(); 

                _result = result;


            }
            return _result;
        }

    }
}
