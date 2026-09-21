using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class BrandCon:IEntityTypeConfiguration<Brand>
    {
        void IEntityTypeConfiguration<Brand>.Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.id);
            builder.Property(b=>b.name).IsRequired().IsUnicode(true).HasMaxLength(100);

            builder.HasMany(b => b.products)
                   .WithOne(p => p.brand)
                   .HasForeignKey(p => p.brandId)
                   .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
