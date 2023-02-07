using Business.Services.Interfeces;
using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjeTanimService : IProjeTanimService
    {
        private IProjeTanimRepository _projeTanimRepository;
        public ProjeTanimService(IProjeTanimRepository projeTanimRepository)
        {
            _projeTanimRepository = projeTanimRepository;
        }

        public ProjeTanim GetById(int Id)
        {
            return _projeTanimRepository.Get(a => a.ProjeTanimId == Id);
        }

        public List<ProjeTanim> GetList()
        {
            return _projeTanimRepository.GetList().ToList();
        }
        public List<ProjeTanimDto> GetListProje()
        {
            return new List<ProjeTanimDto>(_projeTanimRepository.GetListProje().ToList());
        }
        public string Add(ProjeTanim projeTanim)
        {
            _projeTanimRepository.Add(projeTanim);
            return "Ok";
        }
        public string Update(ProjeTanim projeTanim)
        {
            _projeTanimRepository.Update(projeTanim);
            return "Ok";
        }
        public string Delete(ProjeTanim projeTanim)
        {
            _projeTanimRepository.Delete(projeTanim);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
