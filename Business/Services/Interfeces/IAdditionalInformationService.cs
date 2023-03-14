using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IAdditionalInformationService
    {
        AdditionalInformation GetById(int Id);
        List<AdditionalInformation> GetList();
        List<AdditionalInformation> GetActives(int CompanyID);
        List<AdditionalInformation> GetActivesFormID(int FormID);
        AdditionalInformation GetActivesById(int id);
        string Add(AdditionalInformation additionalInformation);
        string Update(AdditionalInformation additionalInformation);
        string Delete(AdditionalInformation additionalInformation);
        object GetById();
    }
}
