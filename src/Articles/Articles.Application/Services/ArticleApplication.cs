using Articles.Application.Interfaces;
using Articles.Application.ViewModel;
using Articles.Domain.Interfaces;
using Articles.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Articles.Application.Services
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticle _article;
        private readonly IArticleLikes _articleLikes;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public ArticleApplication(IArticle article, IMapper mapper, IArticleLikes articleLikes, IUser user)
        {
            _article = article;
            _mapper = mapper;
            _articleLikes = articleLikes;
            _user = user;
        }

        public async Task<ArticleViewModel> Create(CreateArticleViewModel model, string hashUser)
        {
            var user = await _user.GetByHash(hashUser);
            var data = new Article();
            data.IdUser = user.Id;
            data.PublishedDate = DateTime.Now;
            data.Text = model.Text;
            data.Title = model.Title;

            return _mapper.Map<ArticleViewModel>(await _article.Add(data));
        }        

        public async Task<IEnumerable<ArticleViewModel>> GetAll() =>
              _mapper.Map<IEnumerable<ArticleViewModel>>(await _article.GetAll());

        public async Task<ArticleViewModel> Like(ArticleLikeViewModel model)
        {
            var data = new ArticleLikes(model.IdUser, model.IdArticle);
            _articleLikes.AddLike(data);

            return _mapper.Map<ArticleViewModel>(await _article.GetById(model.IdArticle));
        }
        public async Task<ArticleViewModel> Dislike(ArticleLikeViewModel model)
        {
            var data = await _articleLikes.Get(model.IdArticle, model.IdUser);

             _articleLikes.RemoveLike(data);

            return _mapper.Map<ArticleViewModel>(await _article.GetById(model.IdArticle));
        }

        public async Task<ArticleLikeViewModel> Get(ArticleLikeViewModel model) =>
            _mapper.Map<ArticleLikeViewModel>(await _articleLikes.Get(model.IdArticle, model.IdUser));

        public async Task<ArticleViewModel> GetById(int id) =>
               _mapper.Map<ArticleViewModel>(await _article.GetById(id));
    }
}
