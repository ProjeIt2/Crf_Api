﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public  class Personnel : BaseEntity
    {
        public int? UserRoleID { get; set; }
        public int? DepartmentID { get; set; }
        public int? MySideManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? PersonelKey { get; set; }
    }
}
