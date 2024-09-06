using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.RemoveAccountModel;

public class RemoveAccount
{
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(40, ErrorMessage = "Incorrect password.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?]{8,40}$", ErrorMessage = "Incorrect password.")]
    [Display(Name = "Password")]
    public string password { get; set; }
}