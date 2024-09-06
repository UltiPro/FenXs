using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.ChangePasswordModel;

public class ChangePassword
{
    [Required(ErrorMessage = "Old password is required.")]
    [StringLength(40, ErrorMessage = "Incorrect old password.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?]{8,40}$", ErrorMessage = "Incorrect old password.")]
    [Display(Name = "Old Password")]
    public string oldPassword { get; set; }

    [Required(ErrorMessage = "New password is required.")]
    [StringLength(40, ErrorMessage = "New password should be 8 to 40 characters long.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?])[a-zA-Z0-9.~!@#$%^&*()+=[\]\\;:'""/,|{}<>?]{8,40}$", ErrorMessage = "Password must be between 8 and 40 characters long and contain at least one lowercase letter, one uppercase letter, one number and one special character.")]
    [Display(Name = "New Password")]
    public string newPassword { get; set; }

    [Required(ErrorMessage = "Repeat password is required.")]
    [Compare("newPassword", ErrorMessage = "The passwords do not match!")]
    [Display(Name = "Repeat New Password")]
    public string repeatNewPassword { get; set; }
}