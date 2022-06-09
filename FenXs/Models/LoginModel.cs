using System.ComponentModel.DataAnnotations;

namespace Models.LoginModel;

public class Login
{
    [Required(ErrorMessage = "Login is required.")]
    [StringLength(15, ErrorMessage = "Login should be 3 to 15 characters long.", MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z][A-Za-z0-9_-]{1,13}[A-Za-z0-9]$", ErrorMessage = "Incorrect expression of login. Check info!")]
    [Display(Name = "login")]
    public string login { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(30, ErrorMessage = "Password should be 8 to 30 characters long.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$", ErrorMessage = "Incorrect expression of password. Check info!")]
    [Display(Name = "password")]
    public string password { get; set; }
}