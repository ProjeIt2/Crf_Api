using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Hospital : BaseEntity
    {
        public string ResponsibleFullName { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleDuty { get; set; }
        public string ResponsibleMail { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
