using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ISponsorService
    {
        Sponsor GetById(int Id);
        List<Sponsor> GetList();
        string Add(Sponsor sponsor);
        string Update(Sponsor sponsor);
        string Delete(Sponsor sponsor);
        object GetById();
    }
}
