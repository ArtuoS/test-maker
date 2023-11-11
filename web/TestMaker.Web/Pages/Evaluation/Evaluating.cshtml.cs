using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;
using TestMaker.Web.Core;
using TestMaker.Web.Core.Endpoints;

namespace TestMaker.Web.Pages.Evaluation
{
    public class EvaluatingModel : PageModel
    {
        public Core.Models.Evaluation? Instance { get; set; }

        private readonly ICaller _caller;

        public EvaluatingModel(ICaller caller)
        {
            _caller = caller;
        }

        public async Task OnGet(string guid)
        {
            var response = await _caller.GetAsync(string.Format(EvaluationEndpoints.GetEvaluationByGuid, guid));
            var evaluation = JsonConvert.DeserializeObject<Core.Models.Evaluation>(response.Content);
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
