using Articles.Application.Interfaces;
using Articles.Application.Services;
using Articles.Domain.Interfaces;
using Articles.Infrastructure.Data.Context;
using Articles.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Infrastructure.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //APPLICATION
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IArticleApplication, ArticleApplication>();

            //INFRA
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IArticle, ArticleRepository>();
            services.AddScoped<IArticleLikes, ArticleLikesRepository>();

            //CONTEXT
            services.AddScoped<BaseContext>();
        }
    }
}
