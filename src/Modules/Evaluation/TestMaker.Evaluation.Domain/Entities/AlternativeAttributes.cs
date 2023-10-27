using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TestMaker.Evaluation.Domain.Entities
{
    public class AlternativeAttributes
    {
        public long Id { get; set; }

        [JsonProperty("valor")]
        private string BaseValue { get; set; }

        [JsonProperty("nomeAtributo")]
        public string Name { get; set; }

        public string Value
        {
            get => Regex.Replace(BaseValue, "<.*?>", string.Empty);
        }
    }
}