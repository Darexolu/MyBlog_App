using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyBlog_App.Models.ViewModels
{
    public class PostViewModel
    {
        [ValidateNever]
        public int Id { get; set; }
        [ValidateNever]
        public List<PostModel> PostList { get; set; }
        public PostModel Post { get; set; }
    }
}
