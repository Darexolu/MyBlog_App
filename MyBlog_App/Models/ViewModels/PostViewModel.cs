using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Xml.Linq;

namespace MyBlog_App.Models.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            Post = new PostModel
            {
                Likes = new List<LikeModel>(),
                Comments = new List<CommentModel>()
            };
        }
        public int Id { get; set; }
        [ValidateNever]
        public List<PostModel> PostList { get; set; }
        public PostModel Post { get; set; }
        [ValidateNever]
        public CommentModel Comment { get; set; } // New property for adding comments
        [ValidateNever]
        public LikeModel Like { get; set; }

    }
}
