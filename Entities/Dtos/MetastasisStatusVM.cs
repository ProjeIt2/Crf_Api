using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public  class MetastasisStatusVM
    {
        public int ID { get; set; }
        public int Status { get; set; }
        public string LymphNoduOperation { get; set; }
        public string LymphNoduMetastasis { get; set; }
        public string DistantMetastasisExist { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? MetastasisID { get; set; }
        public string MetastasisOrgan { get; set; }
        public int? LymphNodeID { get; set; }
        public string LymphLocation { get; set; }
        public int? DistantMetastasisID { get; set; }
        public string DistantMetastasisLocation { get; set; }
    }
}
