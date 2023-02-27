using System;
using Examensarbete.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Data
{
    public partial class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<WorkoutModel> Workout { get; set; } = null!;
        public virtual DbSet<ExercisesListModel> ExercisesList { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ExercisesListModel>(entity =>
            {
                entity.ToTable("exerciseTable");
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<WorkoutModel>(entity =>
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
                entity.Property(e => e.WorkoutModelid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}