using Newtonsoft.Json;

namespace UninterTestMaker.Domain.Entities
{
    public class AlternativeAttributes
    {
        public long Id { get; set; }

        [JsonProperty("valor")]
        public string Value { get; set; }

        [JsonProperty("nomeAtributo")]
        public string Name { get; set; }
    }
}