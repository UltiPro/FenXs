using FenXsDAL.Models.LoginModel;
using System.ComponentModel.DataAnnotations;

namespace FenXsDAL.Models.RegistrationModel;

public class Registration : Login
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Incorrect address email.")]
    [Display(Name = "Email")]
    public string email { get; set; }

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare("password", ErrorMessage = "The passwords do not match!")]
    [Display(Name = "Confirm Password")]
    public string confirmPassword { get; set; }
}