using Business.Services.Interfeces;
using Core.Tools;
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
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor GetById(int Id)
        {
            return _doctorRepository.Get(a => a.ID == Id);
        }
        public List<Doctor> GetList()
        {
            return _doctorRepository.GetList().ToList();
        }
        public List<Doctor> GetActivesById(int CompanyID)
        {
            return _doctorRepository.GetList(x=>x.CompanyID==CompanyID&&x.Status!=3).ToList();
        }

        //public List<KullaniciDto> GetListKullanici()
        //{
        //    return new List<KullaniciDto>(_doctorRepository.GetListKullanici().ToList());
        //}
        public string Add(Doctor doctor)
        {
            doctor.CreatedDate = DateTime.Now;

            _doctorRepository.Add(doctor);
            return "Ok";
        }
        public string Update(Doctor doctor)
        {
            var User = _doctorRepository.Get(a => a.ID== doctor.ID);
            doctor.CreatedDate = User.CreatedDate;
            doctor.ModifiedDate = DateTime.Now;
            doctor.Status = 2;
            _doctorRepository.Update(doctor);
            return "Ok";
        }
        public string Delete(Doctor doctor)
        {
            var User = _doctorRepository.Get(a => a.ID == doctor.ID);
            doctor.CreatedDate = User.CreatedDate;
            doctor.ModifiedDate = User.ModifiedDate;
            doctor.DeletedDate = DateTime.Now;
            doctor.Status = 3;
            _doctorRepository.Delete(doctor);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
