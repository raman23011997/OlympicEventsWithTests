namespace olympicEvents.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventsDetail
    {
        [Key]
        public int event_detailID { get; set; }

        public int eventID { get; set; }

        [Required]
        [StringLength(562)]
        public string Name { get; set; }

        [Required]
        [StringLength(5623)]
        public string Description { get; set; }

        public int Age_InYears { get; set; }

        public virtual Event Event { get; set; }
    }
}
