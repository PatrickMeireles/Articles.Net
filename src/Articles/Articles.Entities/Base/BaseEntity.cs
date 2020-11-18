using System.ComponentModel.DataAnnotations;

namespace Articles.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
