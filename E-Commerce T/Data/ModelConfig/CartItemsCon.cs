using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class CartItemsCon : IEntityTypeConfiguration<CartItems>
    {
        void IEntityTypeConfiguration<CartItems>.Configure(EntityTypeBuilder<CartItems> builder)
        {
            builder.ToTable("cart_items");
            builder.HasKey(ci => ci.id);
            builder.Property(ci => ci.quantity).IsRequired();

            builder.HasOne(ci=>ci.cart)
                .WithMany(c=>c.cartItems)
                .HasForeignKey(ci=>ci.cartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.productVariant)
                .WithMany()
                .HasForeignKey(ci => ci.productVariantId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
