using Api_Customer_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Customer_Data.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext() { }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Resolve o mapeametno no DbContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
