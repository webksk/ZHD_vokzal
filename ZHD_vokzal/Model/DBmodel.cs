namespace ZHD_vokzal.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBmodel : DbContext
    {
        public DBmodel()
            : base("name=DBmodel")
        {
        }

        public virtual DbSet<Bilet> Bilet { get; set; }
        public virtual DbSet<Marshrut> Marshrut { get; set; }
        public virtual DbSet<Ostanovki> Ostanovki { get; set; }
        public virtual DbSet<Reis> Reis { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Train> Train { get; set; }
        public virtual DbSet<Vagon> Vagon { get; set; }
        public virtual DbSet<Passazhir> Passazhir { get; set; }
        public virtual DbSet<VagonType> VagonType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bilet>()
                .Property(e => e.PunktPribitiya)
                .IsFixedLength();

            modelBuilder.Entity<Marshrut>()
                .HasMany(e => e.Reis)
                .WithOptional(e => e.Marshrut)
                .HasForeignKey(e => e.NumberMarshruta);

            modelBuilder.Entity<Ostanovki>()
                .HasMany(e => e.Marshrut)
                .WithOptional(e => e.Ostanovki)
                .HasForeignKey(e => e.Ostanovka);
        }
    }
}
