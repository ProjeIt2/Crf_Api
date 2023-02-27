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
    public class PatientInformationRepository : EntityRepositoryBase<PatientInformation, ProjeItContext>, IPatientInformationRepository
    {

    }
}
