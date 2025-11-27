using FloriculturaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FloriculturaApp.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)   // <-- Aqui estava o erro
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
