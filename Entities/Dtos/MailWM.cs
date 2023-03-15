using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public  class MailWM
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string DisplayName { get; set; }
    }
}
