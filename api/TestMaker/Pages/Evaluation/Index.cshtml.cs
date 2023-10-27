using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TestMaker.Evaluation.Application.Interfaces;

namespace TestMaker.Web.Pages.Evaluation
{
    public class EvaluationModel : PageModel
    {
        public string? Evaluation { get; set; }

        private readonly ICacheService _cache;
        public EvaluationModel(ICacheService cache)
        {
            _cache = cache;
        }

        public IActionResult OnPost(string evaluation)
        {
            if (evaluation is null)
            {
                return BadRequest("Invalid evaluation JSON");
            }

            var instance = JsonConvert.DeserializeObject<TestMaker.Evaluation.Domain.Entities.Evaluation>(evaluation);
            if (instance is null)
            {
                return BadRequest("Invalid evaluation sent");
            }

            var guid = Guid.NewGuid().ToString();
            _cache.Add(guid, instance, 600);
            return RedirectToPage("/evaluation/evaluating", new { guid });
        }
    }
}
