using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IMateryalTipService
    {
        MateryalTip GetById(int Id);
        List<MateryalTip> GetList();
        string Add(MateryalTip materyalTip);
        string Update(MateryalTip materyalTip);
        string Delete(MateryalTip materyalTip);
        object GetById();
    }
}
