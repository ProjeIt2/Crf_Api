using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KanserTur
    {
        [Key]
        public int KanserTurId { get; set; }
        public string KanserTurAdi { get; set; }    
    }
}
