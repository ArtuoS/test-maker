using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace UninterTestMaker.Domain.Entities
{
    public class Question
    {
        public long Id { get; set; }

        [JsonProperty("questao")]
        private string BaseText { get; set; }

        [JsonProperty("comando")]
        public string BaseCommand { get; set; }

        [JsonProperty("alternativas")]
        public List<Alternative> Alternatives { get; set; }

        public string Text
        {
            get => Regex.Replace(BaseText, "<.*?>", string.Empty);
        }

        public string Command
        {
            get => Regex.Replace(BaseCommand, "<.*?>", string.Empty);
        }
    }
}