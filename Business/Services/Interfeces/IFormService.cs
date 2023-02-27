﻿using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IFormService
    {
        Form GetById(int Id);
        List<Form> GetList();
        List<Form> GetActivesById(int CompanyID);
        List<FormListVM> GetListForms();
        string Add(Form kullanici);
        string Update(Form kullanici);
        string Delete(Form kullanici);
        object GetById();
    }
}
