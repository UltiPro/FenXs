using System.ComponentModel.DataAnnotations;

namespace Models.RegistrationModel;

public class Registration
{
    [Required(ErrorMessage = "Login is required.")]
    [StringLength(15, ErrorMessage = "Login should be 3 to 15 characters long.", MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z][A-Za-z0-9_-]{1,13}[A-Za-z0-9]$", ErrorMessage = "Incorrect expression of login. Check info!")]
    [Display(Name = "login")]
    public string login { get; set; }

    [Required(ErrorMessage = "E-mail is required.")]
    [EmailAddress(ErrorMessage = "Incorrect Address E-mail.")]
    [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Incorrect expression of e-mail. Check info!")]
    [Display(Name = "email")]
    public string email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(30, ErrorMessage = "Password should be 8 to 30 characters long.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$", ErrorMessage = "Incorrect expression of password. Check info!")]
    [Display(Name = "password")]
    public string password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required.")]
    [Display(Name = "c-password")]
    public string c_password { get; set; }
}
