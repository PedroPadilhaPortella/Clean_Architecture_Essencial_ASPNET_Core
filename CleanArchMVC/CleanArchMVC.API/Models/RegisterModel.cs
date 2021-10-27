using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and max {1} characters long",
            MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passeord don't match")]
        public string ConfirmPassword { get; set; }
    }
}
