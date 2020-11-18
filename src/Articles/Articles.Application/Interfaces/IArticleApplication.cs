using Articles.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Articles.Application.Interfaces
{
    public interface IArticleApplication 
    {
        Task<IEnumerable<ArticleViewModel>> GetAll();
        Task<ArticleViewModel> Create(CreateArticleViewModel model, string hashUser);
        Task<ArticleViewModel> Like(ArticleLikeViewModel model);
        Task<ArticleViewModel> Dislike(ArticleLikeViewModel model);
        Task<ArticleLikeViewModel> Get(ArticleLikeViewModel model);
        Task<ArticleViewModel> GetById(int id);
    }
}
