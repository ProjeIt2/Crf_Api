﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Report: BaseEntity
    {
        public string Name { get; set; }
        public int? ReportKey { get; set; }
    }
}
