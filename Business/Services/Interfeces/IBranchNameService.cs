using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IBranchNameService
    {
        BranchName GetById(int Id);
        List<BranchName> GetList();
        List<BranchName> GetActives(int CompanyID);
        BranchName GetActivesById(int id);
        string Add(BranchName branchName);
        string Update(BranchName branchName);
        string Delete(BranchName branchName);
        object GetById();
    }
}
