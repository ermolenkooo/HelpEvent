namespace DAL.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reminder")]
    public partial class Reminder
    {
        public int id_user { get; set; }

        public int id_event { get; set; }

        [Key]
        public int id_reminder { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
