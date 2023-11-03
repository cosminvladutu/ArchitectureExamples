using ExampleDomain.Classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Ignore(p => p.Approvers);
            modelBuilder.Entity<Project>().Ignore(p => p.Members);

            base.OnModelCreating(modelBuilder);

        }
    }
}
