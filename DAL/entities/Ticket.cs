namespace DAL.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int row { get; set; }

        public int place { get; set; }

        public decimal price { get; set; }

        public int status { get; set; }

        public int id_event { get; set; }

        [Key]
        public int id_ticket { get; set; }

        public int? id_booking { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Event Event { get; set; }
    }
}
