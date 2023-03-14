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
   public class UploadFileService : IUploadFileService
    {
        private IUploadFileRepository _uploadFileRepository;
        public UploadFileService(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public UploadFile GetById(int Id)
        {
            return _uploadFileRepository.Get(a => a.ID == Id);
        }
        public List<UploadFile> GetList()
        {
            return _uploadFileRepository.GetList().ToList();
        }
        public List<UploadFile> GetActives(int CompanyID)
        {
            return _uploadFileRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<UploadFile> GetActivesFormID(int FormID)
        {
            return _uploadFileRepository.GetList(x => x.FormID == FormID && x.Status != 3).ToList();
        }
        public UploadFile GetActivesById(int id)
        {
            return _uploadFileRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(UploadFile uploadFile)
        {
            uploadFile.CreatedDate = DateTime.Now;

            _uploadFileRepository.Add(uploadFile);
            return "Ok";
        }
        public string Update(UploadFile uploadFile)
        {
            var User = _uploadFileRepository.Get(a => a.ID == uploadFile.ID);
            uploadFile.CreatedDate = User.CreatedDate;
            uploadFile.ModifiedDate = DateTime.Now;
            uploadFile.Status = 2;
            _uploadFileRepository.Update(uploadFile);
            return "Ok";
        }
        public string Delete(UploadFile uploadFile)
        {
            var User = _uploadFileRepository.Get(a => a.ID == uploadFile.ID);
            uploadFile.CreatedDate = User.CreatedDate;
            uploadFile.ModifiedDate = User.ModifiedDate;
            uploadFile.DeletedDate = DateTime.Now;
            uploadFile.Status = 3;
            _uploadFileRepository.Update(uploadFile);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }
    }
}
