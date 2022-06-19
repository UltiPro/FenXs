using System.ComponentModel.DataAnnotations;

namespace Models.ChangeEmailModel;

public class ChangeEmail
{
    [Required(ErrorMessage = "Old e-mail is required.")]
    [EmailAddress(ErrorMessage = "Incorrect old adress e-mail.")]
    [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Incorrect expression of old e-mail.")]
    [Display(Name = "oldEmail")]
    public string oldEmail { get; set; }
    [Required(ErrorMessage = "New e-mail is required.")]
    [EmailAddress(ErrorMessage = "Incorrect new address e-mail.")]
    [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Incorrect expression of new e-mail.")]
    [Display(Name = "newEmail")]
    public string newEmail { get; set; }
    [Required(ErrorMessage = "Repeat e-mail is required.")]
    [Compare("newEmail", ErrorMessage = "New email and repeat email do not match!")]
    [Display(Name = "r_newEmail")]
    public string r_newEmail { get; set; }
}