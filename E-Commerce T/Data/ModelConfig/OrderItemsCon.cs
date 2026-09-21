using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class OrderItemsCon:IEntityTypeConfiguration<OrderItems>
    {
        void IEntityTypeConfiguration<OrderItems>.Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable("order_items");
            builder.HasKey(oi => oi.id);
            builder.Property(oi => oi.quantity).IsRequired();
            builder.Property(oi => oi.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(oi=>oi.ProductName).IsRequired();
            builder.Property(oi => oi.ColorName).IsRequired();
            builder.Property(oi => oi.SizeName).IsRequired();

            builder.HasOne(oi=>oi.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.orderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.productVariant)
                .WithMany()
                .HasForeignKey(oi => oi.productVariantId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
