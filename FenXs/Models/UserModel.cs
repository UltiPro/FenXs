using System.ComponentModel.DataAnnotations;

namespace Models.UserModel;

public class User
{
    [Display(Name = "id")]
    public int id { get; }
    [Display(Name = "login")]
    public string login { get; }
    [Display(Name = "email")]
    public string email { get; }
    [Display(Name = "admin")]
    public bool admin { get; }
    [Display(Name = "FenXs_stars")]
    public int FenXs_stars { get; }
    public User(int id, string login, string email, bool admin, int FenXs_stars)
    {
        this.id = id;
        this.login = login;
        this.email = email;
        this.admin = admin;
        this.FenXs_stars = FenXs_stars;
    }
}

public class UserReturn
{
    public int statusCode { get; }
    private User user { get; }
    public UserReturn(User user, int statusCode)
    {
        this.user = user;
        this.statusCode = statusCode;
    }
}
