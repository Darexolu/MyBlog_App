using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyBlog_App.Models
{
    public class PostModel
    {
       
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}