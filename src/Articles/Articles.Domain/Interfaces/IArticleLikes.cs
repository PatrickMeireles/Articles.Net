using Articles.Entities;
using System.Threading.Tasks;

namespace Articles.Domain.Interfaces
{
    public interface IArticleLikes
    {
        Task<ArticleLikes> Get(int idArticle, int idUser);
        void AddLike(ArticleLikes data);
        void RemoveLike(ArticleLikes data);
    }
}
