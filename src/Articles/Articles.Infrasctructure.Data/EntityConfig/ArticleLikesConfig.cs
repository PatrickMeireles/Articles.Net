using Articles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Articles.Infrastructure.Data.EntityConfig
{
    public class ArticleLikesConfig : IEntityTypeConfiguration<ArticleLikes>
    {
        public void Configure(EntityTypeBuilder<ArticleLikes> builder)
        {
            builder.ToTable("ArticlesLikes");

            builder.HasKey(x => new { x.IdArticle, x.IdUser });

            builder.HasOne(x => x.Article)
                   .WithMany(x => x.Likes)
                   .HasForeignKey(x => x.IdArticle);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Likes)
                   .HasForeignKey(x => x.IdUser);
        }
    }
}
