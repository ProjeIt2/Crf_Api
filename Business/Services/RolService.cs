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
    public class RolService : IRolService
    {
        private IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public Rol GetById(int Id)
        {
            return _rolRepository.Get(a => a.RolId == Id);
        }

        public List<Rol> GetList()
        {
            return _rolRepository.GetList().ToList();
        }
        public string Add(Rol rol)
        {
            _rolRepository.Add(rol);
            return "Ok";
        }
        public string Update(Rol rol)
        {
            _rolRepository.Update(rol);
            return "Ok";
        }
        public string Delete(Rol rol)
        {
            _rolRepository.Delete(rol);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
