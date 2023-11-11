using Newtonsoft.Json;

namespace TestMaker.Web.Core.Models
{
    public class Alternative
    {
        public long Id { get; set; }

        [JsonProperty("questaoAlternativaAtributos")]
        public List<AlternativeAttributes> Attributes { get; set; }
    }
}