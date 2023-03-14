using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UploadFilesPatientICF : BaseEntity
    {

        public string UploadFileName { get; set; }
        public string UploadPath { get; set; }
        //public HttpPostedFileBase[] files { get; set; }
        public int? FormID { get; set; }
        public int? ProjectInformationID { get; set; }
    }
}
