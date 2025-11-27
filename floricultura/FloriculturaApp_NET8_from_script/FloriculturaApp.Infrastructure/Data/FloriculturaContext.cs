using Microsoft.EntityFrameworkCore;
using FloriculturaApp.Domain.Entities;
using FloriculturaApp.Infrastructure.Configurations;

namespace FloriculturaApp.Infrastructure.Data
{
    public class FloriculturaContext : DbContext
    {
        public FloriculturaContext(DbContextOptions<FloriculturaContext> options) 
            : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
