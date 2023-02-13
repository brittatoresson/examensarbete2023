using System;
using Examensarbete.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Models
{
    public partial class DatabaseContextNy : DbContext
    {
        public DatabaseContextNy()
        {
        }
        public DatabaseContextNy(DbContextOptions<DatabaseContextNy> options)
            : base(options)
        {
        }
        public virtual DbSet<Ny> Ny { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ny>(entity =>
            {
                entity.ToTable("workout");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.Exercise)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Repetition)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Rounds)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TotalTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}