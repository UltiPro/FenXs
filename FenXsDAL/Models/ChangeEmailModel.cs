using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.ChangeEmailModel;

public class ChangeEmail
{
    [Required(ErrorMessage = "Old email is required.")]
    [EmailAddress(ErrorMessage = "Incorrect old adress email.")]
    [Display(Name = "Old Email")]
    public string oldEmail { get; set; }

    [Required(ErrorMessage = "New email is required.")]
    [EmailAddress(ErrorMessage = "Incorrect new address email.")]
    [Display(Name = "New Email")]
    public string newEmail { get; set; }

    [Required(ErrorMessage = "Repeat new email is required.")]
    [Compare("newEmail", ErrorMessage = "New email and repeat new email do not match!")]
    [Display(Name = "Repeat New Email")]
    public string repeatNewEmail { get; set; }
}