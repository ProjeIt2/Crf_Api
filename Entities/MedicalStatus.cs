using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class MedicalStatus: BaseEntity
    {
        public string Medical_Status { get; set; }
        public int? MKey { get; set; }
    }
}
