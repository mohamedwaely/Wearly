using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class SizeCon : IEntityTypeConfiguration<Size>
    {
        void IEntityTypeConfiguration<Size>.Configure(EntityTypeBuilder<Size> builder)
        {

            builder.HasKey(s => s.id);
            builder.Property(s => s.name).IsRequired().HasMaxLength(50);
            builder.Property(s=>s.type).IsRequired();

            builder.HasMany(s => s.products)
                   .WithOne(pv => pv.size)
                   .HasForeignKey(pv => pv.sizeId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
