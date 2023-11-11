using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;
using System;
using TestMaker.Web.Core;
using TestMaker.Web.Core.Endpoints;

namespace TestMaker.Web.Pages.Evaluation
{
    public class EvaluationModel : PageModel
    {
        public string? Evaluation { get; set; }
        public string? Guid { get; set; }

        private readonly ICaller _caller;

        public EvaluationModel(ICaller caller)
        {
            _caller = caller;
        }

        public async Task<IActionResult> OnPost(string evaluation, string guid)
        {
            if (evaluation is null && guid is null)
            {
                return BadRequest("Preencha o JSON da prova ou um Guid.");
            }

            RestResponse? response;
            Core.Models.Evaluation? instance;
            if (evaluation != null)
            {
                instance = JsonConvert.DeserializeObject<Core.Models.Evaluation>(evaluation);
                if (instance is null)
                {
                    return BadRequest("Invalid evaluation sent");
                }

                response = await _caller.PostAsync(EvaluationEndpoints.CreateOrUpdateEvaluation, instance);
            }
            else
            {
                response = await _caller.GetAsync(string.Format(EvaluationEndpoints.GetEvaluationByGuid, guid));
            }

            if (response != null && !response.IsSuccessStatusCode)
            {
                return BadRequest(response.ErrorMessage ?? string.Empty);
            }

            instance = JsonConvert.DeserializeObject<Core.Models.Evaluation>(response.Content);
            if (instance is null)
            {
                return BadRequest("Invalid evaluation sent");
            }

            return RedirectToPage("/evaluation/evaluating", new { instance.Guid });
        }
    }
}
