using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Job: BaseEntity
    {
        public string JobName { get; set; }
        public int? JobKey { get; set; }
    }
}
