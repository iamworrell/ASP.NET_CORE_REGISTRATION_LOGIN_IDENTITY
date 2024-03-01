using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using signup_login.Models;

namespace signup_login.Pages
{
    public class RegisterModel : PageModel
    {
        //these properties are used in the OnPost Method
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //bind cshtml page to this model
        [BindProperty]
        public Register Model { get; set; }

        //Properties are initialized using this constructor
        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public string errors;
        public async void OnPostAsync()
        {
            //Check if User Input complies to Restrictions set in Register Model
            if(ModelState.IsValid)
            {
                //Store an Object of type IdenityUser into the user variable
                //Since we are using Identity the type has to be IdentityUser, this is what the table will recognize
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email,
                };

                //comes from Identity Package
                //CreateAsync adds a user to the Users table
                //user - user Object
                //Model.Password - is hashed automatically and stored for the corresponding user
                //

                var result = userManager.CreateAsync(user, Model.Password).GetAwaiter().GetResult();

                //check if user was successfully created
                if(result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).GetAwaiter().GetResult();
                    //await signInManager.SignInAsync(user, false);
                    Response.Redirect("Index");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        errors += error.Description + '\n';
                    }
                }
            }
        }
    }
}