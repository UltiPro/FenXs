using System.ComponentModel.DataAnnotations;

namespace Models.User;

public class User
{
    [Display(Name = "login")]
    public string login { get; set; }

    [Display(Name = "email")]
    public string email { get; set; }

    public bool admin {get;}
}
