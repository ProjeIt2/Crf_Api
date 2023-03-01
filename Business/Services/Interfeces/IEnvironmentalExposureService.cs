﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IEnvironmentalExposureService
    {
        EnvironmentalExposure GetById(int Id);
        List<EnvironmentalExposure> GetList();
        List<EnvironmentalExposure> GetActivesById(int CompanyID);
        string Add(EnvironmentalExposure environmentalExposure);
        string Update(EnvironmentalExposure environmentalExposure);
        string Delete(EnvironmentalExposure environmentalExposure);
        object GetById();
    }
}
