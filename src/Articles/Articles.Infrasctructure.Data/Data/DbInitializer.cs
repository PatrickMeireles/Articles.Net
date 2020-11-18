using Articles.Entities;
using Articles.Entities.Enuns;
using Articles.Infrastructure.Data.Context;
using Articles.Util;
using System;
using System.Linq;

namespace Articles.Infrastructure.Data.Data
{
    public static class DbInitializer
    {
        public static void Initializer(BaseContext context)
        {
            if (context.User.Any() && context.Article.Any())
                return;
            else
            {
                var defaultUser = new User();
                defaultUser.Name = "Admin";
                defaultUser.Email = "admin@admin.com";
                defaultUser.Hash = HashMD5.getMD5("admin@admin.com");
                defaultUser.Password = HashMD5.getMD5("123456");
                defaultUser.Role = (int)RoleType.Admin;

                context.Add(defaultUser);
                context.SaveChanges();

                var defaultArticle = new Article();
                defaultArticle.PublishedDate = DateTime.Now;
                defaultArticle.Text = "New Text";
                defaultArticle.Title = "Same Title";
                defaultArticle.User = context.User.FirstOrDefault();
                context.Add(defaultArticle);
                context.SaveChanges();

                var like = new ArticleLikes();
                like.Article = context.Article.FirstOrDefault();
                like.User = context.User.FirstOrDefault();
                context.Add(like);

                context.SaveChanges();
            }
        }
    }
}
