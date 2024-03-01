using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace signup_login.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        //Code Executes on post Action from Logout Page
        //When the user posts on "logout" page
        //the SignOutAsync Method from Identity does the sign out for us
        //This clears the cookie from the browser
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            //This removes the cookie
            await signInManager.SignOutAsync();
            return RedirectToPage("Login");
        }
    }
}
