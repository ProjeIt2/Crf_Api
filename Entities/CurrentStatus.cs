using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class CurrentStatus :BaseEntity
    {
     public string Current_Status { get; set; }
        public int? CKey { get; set; }
    }
}
