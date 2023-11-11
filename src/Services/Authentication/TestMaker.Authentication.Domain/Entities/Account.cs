using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestMaker.Authentication.Domain.Entities
{
    public class Account
    {
        public Account()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
        }

        [BsonId]
        public string Guid { get; set; }

        [BsonElement("Login")]
        public required string Login { get; set; }

        [BsonElement("Password")]
        public required string Password { get; set; }

        [BsonElement("ExpirationDate")]
        public required DateTime ExpirationDate { get; set; }

        [BsonIgnore]
        public bool Expired => ExpirationDate < DateTime.Now;
    }
}
