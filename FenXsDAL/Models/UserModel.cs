using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.UserModel;

public class User
{
    [Display(Name = "Id")]
    public int id { get; set; }

    [Display(Name = "Login")]
    public string? login { get; set; }

    [Display(Name = "Email")]
    public string email { get; set; }

    [Display(Name = "Admin")]
    public bool admin { get; set; }

    [Display(Name = "Moderator")]
    public bool moderator { get; set; }

    [Display(Name = "FenXs Stars")]
    public int fenxsStars { get; set; }

    public User()
    {
        login = "";
        email = "";
    }

    public User(int id, string login, string email, bool admin, bool moderator, int fenxsStars)
    {
        this.id = id;
        this.login = login;
        this.email = email;
        this.admin = admin;
        this.moderator = moderator;
        this.fenxsStars = fenxsStars;
    }
}

public class UserReturn
{
    public User user { get; }
    public int statusCode { get; }

    public UserReturn(User user, int statusCode)
    {
        this.user = user;
        this.statusCode = statusCode;
    }
}

public class UserFull : User
{
    [Display(Name = "Active")]
    public bool active { get; set; }

    [Display(Name = "Banned")]
    public bool banned { get; set; }

    [Display(Name = "Sign In Date")]
    public DateTime signInDate { get; set; }

    [Display(Name = "Last Login Date")]
    public DateTime lastLoginDate { get; set; }

    public UserFull(int id, string login, string email, bool admin, bool moderator, int fenxsStars, bool active, bool banned, DateTime signInDate, DateTime lastLoginDate) : base(id, login, email, admin, moderator, fenxsStars)
    {
        this.active = active;
        this.banned = banned;
        this.signInDate = signInDate;
        this.lastLoginDate = lastLoginDate;
    }
}