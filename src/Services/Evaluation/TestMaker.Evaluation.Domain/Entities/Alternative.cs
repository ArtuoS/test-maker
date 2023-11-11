 using Newtonsoft.Json;

namespace TestMaker.Evaluation.Domain.Entities
{
    public class Alternative
    {
        public long Id { get; set; }

        [JsonProperty("questaoAlternativaAtributos")]
        public List<AlternativeAttributes> Attributes { get; set; }
    }
}