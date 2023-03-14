using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface ILymphNodeService
    {
        LymphNode GetById(int Id);
        List<LymphNode> GetList();
        List<LymphNode> GetActives(int CompanyID);
        LymphNode GetActivesById(int id);
        string Add(LymphNode lymphNode);
        string Update(LymphNode lymphNode);
        string Delete(LymphNode lymphNode);
        object GetById();
    }
}
