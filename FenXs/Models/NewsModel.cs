using System.ComponentModel.DataAnnotations;

namespace Models.NewsModel;

public class News
{
    public int id { get; set; }
    public DateTime date { get; set; }
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(64, ErrorMessage = "Title should be 3 to 64 characters long.", MinimumLength = 3)]
    [Display(Name = "title")]
    public string title { get; set; }
    [Required(ErrorMessage = "Text is required.")]
    [StringLength(64, ErrorMessage = "Text should be 3 to 1024 characters long.", MinimumLength = 3)]
    [Display(Name = "text")]
    public string text { get; set; }
    [Required(ErrorMessage = "Id of category is required.")]
    [Display(Name = "idOfCategory")]
    public int idOfCategory { get; set; }
}

public class NewsCategory
{
    public int id { get; set; }
    public string name { get; set; }
}