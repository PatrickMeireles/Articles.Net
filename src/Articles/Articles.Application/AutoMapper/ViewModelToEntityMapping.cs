using Articles.Application.ViewModel;
using Articles.Entities;
using AutoMapper;

namespace Articles.Application.AutoMapper
{
    public class ViewModelToEntityMapping : Profile
    {
        public ViewModelToEntityMapping()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<ArticleViewModel, Article>();
            CreateMap<ArticleLikeViewModel, ArticleLikes>();
        }
    }
}
