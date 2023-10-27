using Newtonsoft.Json;

namespace TestMaker.Evaluation.Domain.Entities
{
    public class Evaluation
    {
        public long Id { get; set; }

        [JsonProperty("avaliacaoUsuarioHistoricos")]
        public List<Question> Questions { get; set; }
    }
}