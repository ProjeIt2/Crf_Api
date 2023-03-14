using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities
{
   public class UploadFile: BaseEntity
    {
        public string UploadFileName { get; set; }

        public string UploadPath { get; set; }
           
        public int? FormID { get; set; }
    



    }
}
