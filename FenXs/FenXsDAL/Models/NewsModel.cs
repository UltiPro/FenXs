using System.ComponentModel.DataAnnotations;

namespace FenXsData.Models.NewsModel;

public class News
{
    [Display(Name = "Id")]
    public int id { get; set; }

    [Display(Name = "Date")]
    public DateTime date { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(64, ErrorMessage = "Title should be 3 to 64 characters long.", MinimumLength = 3)]
    [Display(Name = "Title")]
    public string title { get; set; }

    [Required(ErrorMessage = "Text is required.")]
    [StringLength(1024, ErrorMessage = "Text should be 4 to 1024 characters long.", MinimumLength = 4)]
    [Display(Name = "Text")]
    public string text { get; set; }

    [Required(ErrorMessage = "Id of category is required.")]
    [Display(Name = "Id Of Category")]
    public int idOfCategory { get; set; }
}

public class NewsCategory
{
    [Display(Name = "Id")]
    public int id { get; set; }

    [Display(Name = "Name")]
    public string name { get; set; }
}