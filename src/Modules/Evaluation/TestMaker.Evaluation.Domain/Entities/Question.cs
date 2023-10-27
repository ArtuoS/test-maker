using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TestMaker.Evaluation.Domain.Entities
{
    public class Question
    {
        public long Id { get; set; }

        [JsonProperty("questao")]
        public string BaseText { get; set; }

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
            get => !string.IsNullOrEmpty(BaseCommand) ? Regex.Replace(BaseCommand, "<.*?>", string.Empty)
                                                      : string.Empty;
        }
    }
}