using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class TaskUploadFielVM
    {

        public string UploadFileName { get; set; }
        public int? TaskSystemID { get; set; }
        public IFormFile? FilePickerResults { get; set; }
        //public string imagePath { get; set; }
        //public IFormFile? imageItem { get; set; }
        public string UploadPath { get; set; }
    }
}
