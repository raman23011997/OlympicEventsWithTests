namespace olympicEvents.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventsDetails = new HashSet<EventsDetail>();
        }

        public int eventID { get; set; }

        [Required]
        [StringLength(562)]
        public string Name { get; set; }

        [Required]
        [StringLength(5623)]
        public string Description { get; set; }

        public int Participation_Percent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventsDetail> EventsDetails { get; set; }
    }
}
