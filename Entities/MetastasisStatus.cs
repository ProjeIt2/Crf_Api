using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public   class MetastasisStatus: BaseEntity
    {
        public string LymphNoduOperation { get; set; }
        public string LymphNoduMetastasis { get; set; }
        public string DistantMetastasisExist { get; set; }
         public int? FormID { get; set; }
        public int? MetastasisID { get; set; }
        public int? LymphNodeID { get; set; }
        public int? DistantMetastasisID { get; set; }
    
    }
}
