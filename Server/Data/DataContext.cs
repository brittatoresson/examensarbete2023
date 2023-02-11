using System;
using Examensarbete.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Data
{
    public class DataContext : DbContext

    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseModel>().HasData(
                 new ExerciseModel { ID = 1, Name = "Run", Type = "Intervall" },
                 new ExerciseModel { ID = 2, Name = "Ski", Type = "Fast" },
                 new ExerciseModel { ID = 3, Name = "Row", Type = "Steady" }
                );

        }
        //oklart vad denna gör
        public DbSet<ExerciseModel> Exercises { get; set; }
   
    }
}
