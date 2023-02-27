﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IJobService
    {
        Job GetById(int Id);
        List<Job> GetList();
        List<Job> GetActivesById(int CompanyID);
        string Add(Job job);
        string Update(Job job);
        string Delete(Job job);
        object GetById();
    }
}
