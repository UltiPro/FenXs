using System.ComponentModel.DataAnnotations;

namespace Models.ChangePasswordModel;

public class ChangePassword
{
    [Required(ErrorMessage = "Old password is required.")]
    [StringLength(30, ErrorMessage = "Incorrect old password.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$", ErrorMessage = "Incorrect expression of  old password.")]
    [Display(Name = "oldPassword")]
    public string oldPassword { get; set; }
    [Required(ErrorMessage = "New password is required.")]
    [StringLength(30, ErrorMessage = "New password should be 8 to 30 characters long.", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,30}$", ErrorMessage = "Incorrect expression of new password.")]
    [Display(Name = "newPassword")]
    public string newPassword { get; set; }
    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare("newPassword", ErrorMessage = "The passwords do not match!")]
    [Display(Name = "c_newPassword")]
    public string r_newPassword { get; set; }
}