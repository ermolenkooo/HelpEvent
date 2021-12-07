namespace DAL.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            Booking = new HashSet<Booking>();
            Reminder = new HashSet<Reminder>();
            Ticket = new HashSet<Ticket>();
        }

        public int id { get; set; }

        public DateTime time { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        public int number_of_seats { get; set; }

        public int id_organizer { get; set; }

        public int id_category { get; set; }

        public int id_type { get; set; }

        public int id_venue { get; set; }

        [StringLength(50)]
        public string poster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }

        public virtual Category Category { get; set; }

        public virtual Organizer Organizer { get; set; }

        public virtual Type Type { get; set; }

        public virtual Venue Venue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reminder> Reminder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
