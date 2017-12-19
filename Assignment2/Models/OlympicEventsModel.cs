namespace olympicEvents.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OlympicEventsModel : DbContext
    {
        public OlympicEventsModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventsDetail> EventsDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventsDetail)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventsDetail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EventsDetail>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
