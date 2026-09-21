using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class CategoryConcs : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.name).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.parentCategory)
                .WithMany(c => c.subCategories)
                .HasForeignKey(c => c.parentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new Category { id = 1, name = "Clothes", parentCategoryId = null },
                    new Category { id = 2, name = "Shoes", parentCategoryId = null }
                );
        }

    }
}
