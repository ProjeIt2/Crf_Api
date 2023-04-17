using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public   class TaskUploadFile : BaseEntity
    {
        public string UploadFileName { get; set; }
           public string UploadPath { get; set; }
       
        public int? TaskSystemID { get; set; }
    }
}
