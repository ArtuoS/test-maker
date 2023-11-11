using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TestMaker.Web.Core.Models
{
    public class Evaluation
    {
        [BsonId]
        public string Guid { get; set; }

        [JsonProperty("avaliacaoUsuarioHistoricos")]
        public List<Question> Questions { get; set; }
    }
}