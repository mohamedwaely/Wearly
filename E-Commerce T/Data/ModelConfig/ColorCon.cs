using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class ColorCon : IEntityTypeConfiguration<Color>
    {
        void IEntityTypeConfiguration<Color>.Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.name).IsRequired().IsUnicode(true).HasMaxLength(100);
            builder.Property(c => c.hexCode).IsRequired(false).IsUnicode(true).HasMaxLength(20);

            builder.HasMany(c => c.products)
                   .WithOne(pv => pv.color)
                   .HasForeignKey(pv => pv.colorId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
