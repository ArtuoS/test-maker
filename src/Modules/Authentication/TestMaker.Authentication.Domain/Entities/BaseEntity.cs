using System.ComponentModel.DataAnnotations;

namespace TestMaker.Authentication.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Guid { get; set; }
    }
}
