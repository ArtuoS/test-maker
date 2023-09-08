using Newtonsoft.Json;

namespace UninterTestMaker.Domain.Entities
{
    public class Evaluation
    {
        public long Id { get; set; }

        [JsonProperty("avaliacaoUsuarioHistoricos")]
        public List<Question> Questions { get; set; }
    }
}