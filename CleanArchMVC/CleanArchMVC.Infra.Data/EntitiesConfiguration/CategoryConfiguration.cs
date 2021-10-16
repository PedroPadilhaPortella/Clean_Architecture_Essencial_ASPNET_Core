using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Application.EntitiesConfiguration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Acessories and Peripherals"),
                new Category(2, "Harware"),
                new Category(3, "Notebooks"),
                new Category(4, "Others")
            );
        }
    }
}
