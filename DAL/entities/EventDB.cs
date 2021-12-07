using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.entities
{
    public partial class EventDB : DbContext
    {
        public EventDB()
            : base("name=EventDB3")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Category>()
                .Property(e => e.name_category)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.name_city)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Venue)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.poster)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.id_event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Reminder)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.id_event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.id_event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.name_organizer)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Organizer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Type>()
                .Property(e => e.name_type)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reminder)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Venue)
                .WillCascadeOnDelete(false);
        }
    }
}
