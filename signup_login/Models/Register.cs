using System.ComponentModel.DataAnnotations;

namespace signup_login.Models
{
    public class Register
    {
        [Required (ErrorMessage = "We Need Your Email")]
        [EmailAddress (ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Enter Password")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password Did Not Match")]
        public string ConfirmPassword { get; set; }
    }
}