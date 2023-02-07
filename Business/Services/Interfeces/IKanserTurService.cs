using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfeces
{
    public interface IKanserTurService
    {
        KanserTur GetById(int Id);
        List<KanserTur> GetList();
        string Add(KanserTur kanserTur);
        string Update(KanserTur kanserTur);
        string Delete(KanserTur kanserTur);
        object GetById();
    }
}
