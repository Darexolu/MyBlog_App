using System.ComponentModel.DataAnnotations;

namespace MyBlog_App.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
