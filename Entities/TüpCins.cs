using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TüpCins
    {
        [Key]
        public int TüpCinsId { get; set; }
        public string TüpCinsAdi { get; set; }
    }
}
