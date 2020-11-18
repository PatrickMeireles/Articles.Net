namespace Articles.Entities
{
    public class ArticleLikes
    {
        public ArticleLikes(int idUser, int idArticle)
        {
            IdUser = idUser;
            IdArticle = idArticle;
        }

        public ArticleLikes()
        {

        }

        public virtual int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual int IdArticle { get; set; }
        public virtual Article Article { get; set; }

        
    }
}
