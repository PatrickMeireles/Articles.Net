using Articles.Entities.Base;
using System;
using System.Collections.Generic;

namespace Articles.Entities
{
    public class Article : BaseEntity
    {
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime PublishedDate { get; set; }
        public virtual int IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ArticleLikes> Likes { get; set; }
    }
}
