using Articles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Articles.Infrastructure.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Hash)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(x => x.Email)
                    .HasColumnType("varchar(180)")
                    .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnType("varchar(200)")
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(x => x.Role)
                    .HasColumnType("int")
                    .IsRequired();
        }
    }
}
