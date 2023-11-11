using Newtonsoft.Json;

namespace TestMaker.Evaluation.API.Models
{
    public class AlternativeModel
    {
        public long Id { get; set; }

        [JsonProperty("questaoAlternativaAtributos")]
        public List<AlternativeAttributesModel> Attributes { get; set; }
    }
}