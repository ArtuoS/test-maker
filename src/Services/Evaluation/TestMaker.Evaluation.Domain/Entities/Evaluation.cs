using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TestMaker.Evaluation.Domain.Entities
{
    public class Evaluation
    {
        public Evaluation()
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
        }

        [BsonId]
        public string Guid { get; set; }

        [JsonProperty("avaliacaoUsuarioHistoricos")]
        public List<Question> Questions { get; set; }
    }
}