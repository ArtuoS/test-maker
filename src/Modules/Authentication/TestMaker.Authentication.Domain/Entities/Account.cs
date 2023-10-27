using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaker.Authentication.Domain.Entities
{
    public class Account : BaseEntity
    {
        public required string RegisterUninter { get; set; }
        public required string Password { get; set; }
        public required DateTime ExpirationDate { get; set; }

        [NotMapped]
        public bool Expired => ExpirationDate < DateTime.Now;
    }
}
