using Articles.Domain.Interfaces.Generic;
using Articles.Entities;

namespace Articles.Domain.Interfaces
{
    public interface IArticle : IRepository<Article>
    {
    }
}
