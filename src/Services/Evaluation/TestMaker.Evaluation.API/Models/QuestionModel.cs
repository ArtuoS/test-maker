using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TestMaker.Evaluation.API.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }

        [JsonProperty("questao")]
        public string BaseText { get; set; }

        [JsonProperty("comando")]
        public string? BaseCommand { get; set; }

        [JsonProperty("alternativas")]
        public List<AlternativeModel> Alternatives { get; set; }

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