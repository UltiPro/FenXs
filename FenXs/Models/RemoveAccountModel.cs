using System.ComponentModel.DataAnnotations;

namespace Models.RemoveAccountModel;

public class RemoveAccount
{
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(30, ErrorMessage = "Incorrect password.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$", ErrorMessage = "Incorrect password.")]
    [Display(Name = "password")]
    public string password { get; set; }
}