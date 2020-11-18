using Articles.Application.Interfaces;
using Articles.Application.ViewModel;
using FluentValidation;

namespace Articles.Application.Validation
{
    public class ArticleValidation
    {
    }

    public class CreateArticleValidation : AbstractValidator<CreateArticleViewModel>
    {
        public CreateArticleValidation()
        {
            RuleFor(x => x.Text)
                    .NotEmpty().WithMessage("Text cannot be empty")
                    .NotNull().WithMessage("Text cannot be empty");

            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title cannot be empty")
                    .NotNull().WithMessage("Title cannot be empty");
        }
    }

    public class ArticleLikeValidation : AbstractValidator<ArticleLikeViewModel>
    {
        private readonly IArticleApplication _article;

        public ArticleLikeValidation(IArticleApplication article)
        {
            _article = article;

            RuleFor(x => x)
                    .Must(x => ExistLike(x)).WithMessage("User have like for this article");

            RuleFor(x => x.IdArticle).Must(x => x > 0).WithMessage("IdArticle cannot be empty");
            RuleFor(x => x.IdUser).Must(x => x > 0).WithMessage("IdUser cannot be empty");
        }


        private bool ExistLike(ArticleLikeViewModel model)
        {
            return _article.Get(model)
                           .GetAwaiter()
                           .GetResult() == null;
        }
    }

    public class ArticleDisLikeValidation : AbstractValidator<ArticleLikeViewModel>
    {
        private readonly IArticleApplication _article;

        public ArticleDisLikeValidation(IArticleApplication article)
        {
            _article = article; 
            
            RuleFor(x => x)
                .Must(x => ExistLike(x)).WithMessage("User not have like for this article");

            RuleFor(x => x.IdArticle).Must(x => x > 0).WithMessage("IdArticle cannot be empty");
            RuleFor(x => x.IdUser).Must(x => x > 0).WithMessage("IdUser cannot be empty");
        }

        private bool ExistLike(ArticleLikeViewModel model)
        {
            return _article.Get(model)
                           .GetAwaiter()
                           .GetResult() != null;
        }
    }
}
