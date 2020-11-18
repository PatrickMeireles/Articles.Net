using Articles.Domain.Interfaces;
using Articles.Entities;
using Articles.Infrastructure.Data.Context;
using Articles.Infrastructure.Data.Repository.Generic;

namespace Articles.Infrastructure.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticle
    {
        public ArticleRepository(BaseContext context) : base(context)
        {
        }
    }
}
