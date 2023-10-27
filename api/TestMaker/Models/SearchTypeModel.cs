using TestMaker.Evaluation.Domain.Enums;

namespace TestMaker.Web.Models
{
    public class SearchTypeModel
    {
        public SearchType Type { get; set; }
        public required string Text { get; set; }
        public string? Url { get; set; }
    }
}
