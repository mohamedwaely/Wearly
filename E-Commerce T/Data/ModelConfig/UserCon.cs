using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_Commerce_T.Data.Entities;

namespace E_Commerce_T.Data.ModelConfig
{
    public class UserCon: IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.id);
            builder.Property(x=>x.userName).IsRequired(true).HasMaxLength(70);
            builder.Property(x => x.password).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.email).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.role).IsRequired(true);
            builder.Property(x => x.role).HasConversion<string>();

            builder.HasOne(u=>u.address)
                .WithOne(a => a.user)
                .HasForeignKey<Address>(a => a.userId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    } 
}
