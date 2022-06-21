using System.ComponentModel.DataAnnotations;

namespace Models.UserModel;

public class User
{
    [Display(Name = "id")]
    public int id { get; set; }
    [Display(Name = "login")]
    public string login { get; set; }
    [Display(Name = "email")]
    public string email { get; set; }
    [Display(Name = "admin")]
    public bool admin { get; set; }
    [Display(Name = "fenXs_Stars")]
    public int fenXs_Stars { get; set; }
    public User() { }
    public User(int id, string login, string email, bool admin, int fenXs_Stars)
    {
        this.id = id;
        this.login = login;
        this.email = email;
        this.admin = admin;
        this.fenXs_Stars = fenXs_Stars;
    }
}

public class UserReturn
{
    public int statusCode { get; }
    public User user { get; }
    public UserReturn(User user, int statusCode)
    {
        this.user = user;
        this.statusCode = statusCode;
    }
}

public class UserFULL : User
{
    [Display(Name = "active")]
    public bool active { get; set; }
    [Display(Name = "banned")]
    public bool banned { get; set; }
    [Display(Name = "signInDate")]
    public DateTime signInDate { get; set; }
    [Display(Name = "lastLogin")]
    public DateTime lastLogin { get; set; }
    public UserFULL(int id, string login, string email, bool admin, int fenXs_Stars, bool active, bool banned, DateTime signInDate, DateTime lastLogin) : base(id, login, email, admin, fenXs_Stars)
    {
        this.active = active;
        this.banned = banned;
        this.signInDate = signInDate;
        this.lastLogin = lastLogin;
    }
}