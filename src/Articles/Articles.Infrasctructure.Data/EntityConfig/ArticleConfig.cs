using Articles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Articles.Infrastructure.Data.EntityConfig
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.Property(x => x.PublishedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.Text)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(x => x.Title)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.IdUser)
                    .HasPrincipalKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
