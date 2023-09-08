using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UninterTestMaker.Web.Pages.Evaluation
{
    public class EvaluatingModel : PageModel
    {
        public Domain.Entities.Evaluation Instance { get; set; }

        public void IndexPower(Domain.Entities.Evaluation evaluation)
        {
            this.Instance = evaluation;
        }

        public void OnGet()
        {
        }
    }
}
