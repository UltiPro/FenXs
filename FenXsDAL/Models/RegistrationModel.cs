using FenXsDAL.Models.LoginModel;
using System.ComponentModel.DataAnnotations;

namespace FenXsDAL.Models.RegistrationModel;

public class Registration : Login
{
    [Required(ErrorMessage = "Login is required.")]
    [StringLength(30, ErrorMessage = "Login should be 4 to 30 characters long.", MinimumLength = 4)]
    [RegularExpression(@"^(?=.*?[a-zA-Z\d])[a-zA-Z][a-zA-Z\d_-]{2,28}[a-zA-Z\d]$", ErrorMessage = "The login must be between 4 and 30 characters long and must start with a letter and end with a letter or number. May contain a floor and a dash between the start and end.")]
    [Display(Name = "Login")]
    public string login { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Incorrect address email.")]
    [Display(Name = "Email")]
    public string email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(40, ErrorMessage = "Password should be 8 to 40 characters long.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?]{8,40}$", ErrorMessage = "Password must be between 8 and 40 characters long and contain at least one lowercase letter, one uppercase letter, one number and one special character.")]
    [Display(Name = "Password")]
    public string password { get; set; }

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare("password", ErrorMessage = "The passwords do not match!")]
    [Display(Name = "Confirm Password")]
    public string confirmPassword { get; set; }
}