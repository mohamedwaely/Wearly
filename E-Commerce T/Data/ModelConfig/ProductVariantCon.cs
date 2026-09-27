using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class ProductVariantCon : IEntityTypeConfiguration<ProductVariant>
    {
        void IEntityTypeConfiguration<ProductVariant>.Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
            builder.HasKey(pv => pv.id);
            builder.Property(pv => pv.quantity).IsRequired();
            builder.Property(pv => pv.price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(pv=>pv.discountPercentage).IsRequired(false).HasColumnType("decimal(5,2)");
            builder.Property(pv => pv.discountStartDate).IsRequired(false);
            builder.Property(pv => pv.discountEndDate).IsRequired(false);
            builder.Property(pv => pv.IsActive).IsRequired();


        }
    }
}
