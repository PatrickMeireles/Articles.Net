using Articles.Entities.Base;
using System.Collections.Generic;

namespace Articles.Entities
{
    public class User : BaseEntity
    {
        public virtual string Hash { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual int Role { get; set; }
        public virtual string Password { get; set; }
        public virtual ICollection<ArticleLikes> Likes { get; set; }
    }
}
