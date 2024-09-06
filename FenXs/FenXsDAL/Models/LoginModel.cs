using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.LoginModel;

public class Login
{
    [Required(ErrorMessage = "Login is required.")]
    [StringLength(30, ErrorMessage = "Incorrect login.", MinimumLength = 4)]
    [RegularExpression(@"^(?=.*?[a-zA-Z\d])[a-zA-Z][a-zA-Z\d_-]{2,28}[a-zA-Z\d]$", ErrorMessage = "Incorrect login.")]
    [Display(Name = "Login")]
    public string login { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(40, ErrorMessage = "Incorrect password.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?]{8,40}$", ErrorMessage = "Incorrect password.")]
    [Display(Name = "Password")]
    public string password { get; set; }
}