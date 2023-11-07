using Microsoft.EntityFrameworkCore;

namespace WaterConsumptionTracker.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersManagement>().HasData(
            new UsersManagement { Id = 1, FirstName = "John", LastName = "Hewitt", Email = "customer@gmail.com" },
            new UsersManagement { Id = 2, FirstName = "Jack", LastName = "Taylor", Email = "Admin@gmail.com" });

            modelBuilder.Entity<WaterRecords>().HasData(
            new WaterRecords { Id = 1, IntakeDate = Convert.ToDateTime("20/10/2023"), Usage = 16777, UserId = 1 },
            new WaterRecords { Id = 2, IntakeDate = Convert.ToDateTime("25/10/2023"), Usage = 16377, UserId = 2 });
        }

        public DbSet<UsersManagement> UsersManagements { get; set; }

        public DbSet<WaterRecords> WaterRecords { get; set; }
    }
}
