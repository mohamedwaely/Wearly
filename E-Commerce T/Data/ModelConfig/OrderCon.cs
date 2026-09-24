using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class OrderCon : IEntityTypeConfiguration<Order>
    {
        void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(o => o.id);
            builder.Property(o => o.orderedAt).IsRequired();
            builder.Property(o => o.updatedAt).IsRequired();
            builder.Property(o => o.status).IsRequired();
            builder.Property(o => o.TotalAmount).IsRequired().HasPrecision(10, 2);

            builder.HasOne(o => o.user)
                .WithMany(u => u.orders)
                .HasForeignKey(o => o.userId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.orderItems)
                .WithOne(oi => oi.order)
                .HasForeignKey(oi => oi.orderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.address)
                .WithMany()
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
