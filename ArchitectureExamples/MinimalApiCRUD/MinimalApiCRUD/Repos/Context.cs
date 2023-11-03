using ExampleDomain.Classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace MinimalApiCRUD.Repos
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Project> Projects => Set<Project>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Ignore(p => p.Approvers);
            modelBuilder.Entity<Project>().Ignore(p => p.Members);

            base.OnModelCreating(modelBuilder);

        }
    }
}
