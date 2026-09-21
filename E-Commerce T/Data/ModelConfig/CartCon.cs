using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class CartCon:IEntityTypeConfiguration<Cart>
    {
        void IEntityTypeConfiguration<Cart>.Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(c => c.id);
            builder.Property(c=>c.createdAt).IsRequired();
            builder.Property(c => c.updatedAt).IsRequired();

            builder.HasOne(c => c.user)
                .WithOne(u => u.cart)
                .HasForeignKey<Cart>(c => c.userId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
