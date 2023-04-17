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
   public class TaskUploadFileService : ITaskUploadFileService
    {
        private ITaskUploadFileRepository _taskUploadFileRepository;
        public TaskUploadFileService(ITaskUploadFileRepository taskUploadFileRepository)
        {
            _taskUploadFileRepository = taskUploadFileRepository;
        }

        public TaskUploadFile GetById(int Id)
        {
            return _taskUploadFileRepository.Get(a => a.ID == Id);
        }
        public List<TaskUploadFile> GetList()
        {
            return _taskUploadFileRepository.GetList().ToList();
        }
        public List<TaskUploadFile> GetActives(int CompanyID)
        {
            return _taskUploadFileRepository.GetList(x=>x.CompanyID== CompanyID && x.Status != 3).ToList();
        }
        public List<TaskUploadFile> GetActivesFormID(int FormID)
        {
            return _taskUploadFileRepository.GetList(x => x.TaskSystemID == FormID && x.Status != 3).ToList();
        }
        public List<TaskUploadFile> GetFileNames(string FileName)
        {
            return _taskUploadFileRepository.GetList(x => x.UploadFileName == FileName && x.Status != 3).ToList();
        }
        public TaskUploadFile GetFileName(string FileName)
        {
            return _taskUploadFileRepository.GetList(x => x.UploadFileName == FileName && x.Status != 3).FirstOrDefault();
        }
        public TaskUploadFile GetActivesById(int id)
        {
            return _taskUploadFileRepository.Get(x => x.ID == id && x.Status != 3);
        }
        public string Add(TaskUploadFile taskUploadFile)
        {
            taskUploadFile.CreatedDate = DateTime.Now;

            _taskUploadFileRepository.Add(taskUploadFile);
            return "Ok";
        }
        public string Update(TaskUploadFile taskUploadFile)
        {
            var User = _taskUploadFileRepository.Get(a => a.ID == taskUploadFile.ID);
            taskUploadFile.CreatedDate = User.CreatedDate;
            taskUploadFile.ModifiedDate = DateTime.Now;
            taskUploadFile.Status = 2;
            _taskUploadFileRepository.Update(taskUploadFile);
            return "Ok";
        }
        public string Delete(TaskUploadFile taskUploadFile)
        {
            var User = _taskUploadFileRepository.Get(a => a.ID == taskUploadFile.ID);
            taskUploadFile.CreatedDate = User.CreatedDate;
            taskUploadFile.ModifiedDate = User.ModifiedDate;
            taskUploadFile.DeletedDate = DateTime.Now;
            taskUploadFile.Status = 3;
            _taskUploadFileRepository.Update(taskUploadFile);
            return "Ok";
        }

        public object GetById()
        {
            throw new NotImplementedException();
        }

    }
}
