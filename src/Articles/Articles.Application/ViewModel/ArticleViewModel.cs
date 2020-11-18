using System;

namespace Articles.Application.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishedDate { get; set; }
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public int Likes { get; set; }
        public string LikesBy { get; set; }
    }

    public class CreateArticleViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class ArticleLikeViewModel
    {
        public int IdUser { get; set; }
        public int IdArticle { get; set; }
    }
}
