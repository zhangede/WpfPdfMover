namespace WpfPdfMover.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KundenModel : DbContext
    {
        public KundenModel()
            : base("KundenModel")
        {
        }

        public virtual DbSet<Kunden> Kundens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunden>()
                .Property(e => e.Kundennummer)
                .IsFixedLength();

            modelBuilder.Entity<Kunden>()
                .Property(e => e.Kundenname)
                .IsFixedLength();

            modelBuilder.Entity<Kunden>()
                .Property(e => e.Postleitzahl)
                .IsFixedLength();

            modelBuilder.Entity<Kunden>()
                .Property(e => e.Ort)
                .IsFixedLength();

            modelBuilder.Entity<Kunden>()
                .Property(e => e.Land)
                .IsFixedLength();

            modelBuilder.Entity<Kunden>()
                .Property(e => e.Strasse)
                .IsFixedLength();
        }
    }
}
