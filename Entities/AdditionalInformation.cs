using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public   class AdditionalInformation :BaseEntity
    {
        public string AdditionalActions { get; set; }

        //-----------
        public string Notes { get; set; }
        //-----------

        //Relational Properties
        public int? FormID { get; set; }
    }
}
