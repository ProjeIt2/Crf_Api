using Business.Services.Interfeces;
using DataAccess.Repositories.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class KanserTurService : IKanserTurService
    {
        private IKanserTurRepository _KanserTurRepository;
        public KanserTurService(IKanserTurRepository KanserTurRepository)
        {
            _KanserTurRepository = KanserTurRepository;
        }

        public KanserTur GetById(int Id)
        {
            return _KanserTurRepository.Get(a => a.KanserTurId == Id);
        }

        public List<KanserTur> GetList()
        {
            return _KanserTurRepository.GetList().ToList();
        }
        public string Add(KanserTur KanserTur)
        {
            _KanserTurRepository.Add(KanserTur);
            return "Ok";
        }
        public string Update(KanserTur KanserTur)
        {
            _KanserTurRepository.Update(KanserTur);
            return "Ok";
        }
        public string Delete(KanserTur KanserTur)
        {
            _KanserTurRepository.Delete(KanserTur);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
