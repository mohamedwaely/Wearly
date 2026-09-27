using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class SizeCon : IEntityTypeConfiguration<Size>
    {
        void IEntityTypeConfiguration<Size>.Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("sizes");
            builder.HasKey(s => s.id);

            builder.Property(s => s.name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.type).IsRequired();

            builder.HasMany(s => s.products)
                   .WithOne(pv => pv.size)
                   .HasForeignKey(pv => pv.sizeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Size { id = 1, name = "L", type = SizeType.Clothing },
                new Size { id = 2, name = "XL", type = SizeType.Clothing },
                new Size { id = 3, name = "2XL", type = SizeType.Clothing },
                new Size { id = 4, name = "3XL", type = SizeType.Clothing },
                new Size { id = 5, name = "45", type = SizeType.Footwear },
                new Size { id = 6, name = "46", type = SizeType.Footwear },
                new Size { id = 7, name = "47", type = SizeType.Footwear },
                new Size { id = 8, name = "48", type = SizeType.Footwear }
            );
        }
    }
}