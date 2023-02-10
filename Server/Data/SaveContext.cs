using System;
using Examensarbete.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Examensarbete.Server.Data
{
    public class SaveContext : DbContext
    {
        public SaveContext()
        {
        }

        public SaveContext(DbContextOptions<SaveContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutModel>();
        }
        //oklart vad denna gör
        public DbSet<WorkoutModel> Workout { get; set; }

    }
}
