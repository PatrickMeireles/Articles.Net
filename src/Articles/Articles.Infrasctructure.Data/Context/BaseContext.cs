using Articles.Entities;
using Articles.Infrastructure.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Articles.Infrastructure.Data.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ArticleLikes> ArticleLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ArticleLikesConfig());
        }
    }
}
