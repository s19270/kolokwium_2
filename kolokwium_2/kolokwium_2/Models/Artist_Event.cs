using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_2.Models
{
    public class Artist_Event
    {
        [ForeignKey("Artist")]
        public int? IdArtist { get; set; }
        public virtual Artist Artist { get; set; }
        [ForeignKey("Event")]
        public int? IdEvent { get; set; }
        public virtual Event Event { get; set; }
        [Required]
        public DateTime PerformanceDate { get; set; }
    }
}
