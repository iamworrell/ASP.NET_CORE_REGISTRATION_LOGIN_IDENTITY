using System.ComponentModel.DataAnnotations;

namespace signup_login.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Email is Needed")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}