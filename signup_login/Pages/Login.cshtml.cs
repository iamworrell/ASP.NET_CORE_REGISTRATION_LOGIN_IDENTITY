using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using signup_login.Models;

namespace signup_login.Pages
{
    public class LoginModel : PageModel
    {
        //Declare Object of Type SignInMananger - from Identity
        private readonly SignInManager<IdentityUser> signInManager;

        //Links the properties of the LoginModel to the form in Login.cshtml
        [BindProperty]
        public Login Model { get; set; }

        //Constructor
        //Initialize the signManager when the LoginModel is called
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public string attempt = "";
        public string errors = "";
        //Execut code when post occurs on razor page
        public async void OnPostAsync()
        {

            //check if ModelState is Valid ie. user conforms to restrictions set in Login Model
            if(ModelState.IsValid)
            {
                //Login
                //Using PasswordSignAsync we let Identity do the work for us
                //return true if user is found and password matches that stored in db
                //IMPORTANT - When we sign in via identity's signInManager it generates and stores a cookie for us
                var result = signInManager.PasswordSignInAsync(Model.Email, Model.Password, false, false).GetAwaiter().GetResult();
                
                //check if user was found and password matches
                if(result.Succeeded)
                {
                    Response.Redirect("Index");
                }
                else
                {
                    attempt = "Invalid Credentials";
                }
            } 
        }
    }
}