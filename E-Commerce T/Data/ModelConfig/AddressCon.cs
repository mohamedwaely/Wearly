using E_Commerce_T.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_T.Data.ModelConfig
{
    public class AddressCon : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses"); 
            builder.HasKey(a => a.id);

            builder.Property(a => a.street).IsRequired().HasMaxLength(200);
            builder.Property(a => a.city).IsRequired().HasMaxLength(100);
            builder.Property(a => a.country).IsRequired().HasMaxLength(100);
            builder.Property(a => a.postalCode).IsRequired().HasMaxLength(20);

            builder.HasOne(a => a.user)
                   .WithMany()
                   .HasForeignKey(a => a.userId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
