using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public  class UploadFileVM
    {
        public int? FormID { get; set; }
        public IFormFile? FilePickerResults { get; set; }
        public string imagePath { get; set; }
        public IFormFile? imageItem { get; set; }
    }
}
