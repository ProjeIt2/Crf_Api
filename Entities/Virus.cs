using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Virus : BaseEntity
    {
        public string VirusName { get; set; }
        public int? Vkey { get; set; }
    }
}
