using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using TestMaker.Evaluation.Application.Interfaces;

namespace TestMaker.Web.Pages.Evaluation
{
    public class EvaluatingModel : PageModel
    {
        public TestMaker.Evaluation.Domain.Entities.Evaluation? Instance { get; set; }

        private readonly ICacheService _cache;
        public EvaluatingModel(ICacheService cache)
        {
            _cache = cache;
        }

        public void OnGet(string guid)
        {
            _cache.Get(guid, out TestMaker.Evaluation.Domain.Entities.Evaluation? evaluation);
            if (evaluation is null)
            {
                throw new ArgumentNullException("evaluation");
            }

            Instance = evaluation;
        }

        public async Task<IActionResult> OnPostAsync(string evaluation)
        {
            return Page();
        }
    }
}
