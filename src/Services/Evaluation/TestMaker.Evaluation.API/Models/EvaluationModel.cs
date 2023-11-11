using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TestMaker.Evaluation.API.Models
{
    public class EvaluationModel
    {
        [JsonProperty("avaliacaoUsuarioHistoricos")]
        public List<QuestionModel> Questions { get; set; }
    }
}