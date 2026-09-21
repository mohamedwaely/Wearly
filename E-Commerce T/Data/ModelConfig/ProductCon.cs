using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class ProductCon : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.description).IsRequired().HasMaxLength(500);
            builder.Property(p=>p.createdAt).IsRequired();
            builder.Property(p => p.updatedAt).IsRequired();

            builder.HasMany(p=>p.productVariants)
                .WithOne(pv=>pv.product)
                .HasForeignKey(pv => pv.productId)
                .OnDelete(DeleteBehavior.Cascade);
        }
       
    }
}
