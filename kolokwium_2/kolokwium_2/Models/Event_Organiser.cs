using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_2.Models
{
    public class Event_Organiser
    {
        [ForeignKey("Organiser")]
        public int? IdOrganiser { get; set; }
        public virtual Organiser Organiser { get; set; }
        [ForeignKey("Event")]
        public int? IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}
