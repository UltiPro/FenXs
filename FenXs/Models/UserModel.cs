using System.ComponentModel.DataAnnotations;

namespace Models.UserModel;

public class User
{
    [Display(Name = "Id")]
    public int Id { get; set; }
    [Display(Name = "Login")]
    public string Login { get; set; }
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Display(Name = "Admin")]
    public bool Admin { get; set; }
    [Display(Name = "FenXs_stars")]
    public int FenXs_stars { get; set; }
    public User() { }
    public User(int Id, string Login, string Email, bool Admin, int FenXs_stars)
    {
        this.Id = Id;
        this.Login = Login;
        this.Email = Email;
        this.Admin = Admin;
        this.FenXs_stars = FenXs_stars;
    }
}

public class UserReturn
{
    public int StatusCode { get; }
    public User User { get; }
    public UserReturn(User User, int StatusCode)
    {
        this.User = User;
        this.StatusCode = StatusCode;
    }
}