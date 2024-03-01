using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace signup_login.Pages
{
    //Prevents anyone without a cookie from Accessing the razor page associated with this model
    //Identity generated the cookies
    //If user has no cookie in the browser they are re-directed to login path declared in program.cs
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}