using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicle { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ParkingSpot> ParkingSpot { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntity(modelBuilder);
            DisableDeleteCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        private void MapEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void DisableDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }

}
