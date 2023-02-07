using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        public string SponsorAdi { get; set; }
    }
}
