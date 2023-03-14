using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Metastasis: BaseEntity
    {
     public string MetastasisOrgan { get; set; }
        public int? MKey { get; set; }
    }
}
