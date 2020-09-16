using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoatRental.Models
{
    public partial class BoatRentalContext : DbContext
    {
        public BoatRentalContext()
        {
        }

        public BoatRentalContext(DbContextOptions<BoatRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBooking> TblBooking { get; set; }
        public virtual DbSet<TblRegister> TblRegister { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBooking>(entity =>
            {
                entity.HasKey(e => e.BoatId);

                entity.ToTable("tblBooking");

                entity.Property(e => e.BoatId).ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRegister>(entity =>
            {
                entity.ToTable("tblRegister");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BoatName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
