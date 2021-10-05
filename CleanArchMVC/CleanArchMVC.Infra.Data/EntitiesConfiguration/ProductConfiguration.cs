using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Application.EntitiesConfiguration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Name).HasMaxLength(100).IsRequired();
            builder.Property(pt => pt.Description).HasMaxLength(200).IsRequired();
            builder.Property(pt => pt.Price).HasPrecision(10, 2);
            builder.HasOne(pt => pt.Category).WithMany(pt => pt.Products).HasForeignKey(pt => pt.CategoryId);
        }
    }
}
