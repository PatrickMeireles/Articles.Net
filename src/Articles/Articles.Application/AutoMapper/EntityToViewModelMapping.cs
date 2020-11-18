using Articles.Application.ViewModel;
using Articles.Entities;
using AutoMapper;
using System.Linq;

namespace Articles.Application.AutoMapper
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Article, ArticleViewModel>()
                    .ForMember(x => x.NameUser, y => y.MapFrom(z => z.User.Name))
                    .ForMember(x => x.Likes, y => y.MapFrom(z => z.Likes.Count))
                    .ForMember(x => x.LikesBy, y =>  y.MapFrom(z => string.Join(';', z.Likes.ToList().Select(x => x.User.Name))));

            CreateMap<ArticleLikes, ArticleLikeViewModel>();
        }
    }
}
