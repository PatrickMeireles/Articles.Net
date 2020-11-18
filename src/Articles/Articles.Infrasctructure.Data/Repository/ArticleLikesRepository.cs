using Articles.Domain.Interfaces;
using Articles.Entities;
using Articles.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Infrastructure.Data.Repository
{
    public class ArticleLikesRepository : IArticleLikes
    {
        protected readonly BaseContext _db;
        public ArticleLikesRepository(BaseContext context) => _db = context;

        public void AddLike(ArticleLikes data)
        {
            _db.Set<ArticleLikes>().Add(data);
            _db.SaveChanges();
        }

        public async Task<ArticleLikes> Get(int idArticle, int idUser) =>
            await _db.Set<ArticleLikes>().Where(x => x.IdArticle == idArticle && x.IdUser == idUser)
                        .FirstOrDefaultAsync();

        public void RemoveLike(ArticleLikes data)
        {
            _db.Set<ArticleLikes>().Remove(data);
            _db.SaveChanges();
        }
    }
}
