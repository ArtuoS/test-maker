using Newtonsoft.Json;

namespace UninterTestMaker.Domain.Entities
{
    public class Alternative
    {
        public long Id { get; set; }

        [JsonProperty("questaoAlternativaAtributos")]
        public List<AlternativeAttributes> Attributes { get; set; }
    }
}