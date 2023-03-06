using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IOperationProcedureService
    {
        OperationProcedure GetById(int Id);
        List<OperationProcedure> GetList();
        List<OperationProcedure> GetActives(int CompanyID);
        OperationProcedure GetActivesById(int id);
        string Add(OperationProcedure operationProcedure);
        string Update(OperationProcedure operationProcedure);
        string Delete(OperationProcedure operationProcedure);
        object GetById();
    }
}
