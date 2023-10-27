using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestMaker.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string NumeroRu { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost(string numeroRu)
        {
        }
    }
}