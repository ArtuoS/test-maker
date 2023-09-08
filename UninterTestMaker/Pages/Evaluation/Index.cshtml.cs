using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UninterTestMaker.Web.Pages.Evaluation
{
    public class EvaluationModel : PageModel
    {
        public string EvaluationJson { get; set; }

        private readonly ILogger<EvaluationModel> _logger;

        public EvaluationModel(ILogger<EvaluationModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost(string evaluationJson)
        {
            if (evaluationJson is null)
            {
                return BadRequest("Invalid evaluation JSON");
            }

            _logger.LogInformation("Received evaluation: {@EvaluationJson}", evaluationJson);
            var evaluation = JsonConvert.DeserializeObject<Domain.Entities.Evaluation>(evaluationJson);
            return RedirectToPage("Evaluating", "IndexPower", new { evaluation });
        }
    }
}
