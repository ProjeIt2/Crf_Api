﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Disease : BaseEntity
    {
        public string DiseaseName { get; set; }
        public int? DKey { get; set; }
    }
}
