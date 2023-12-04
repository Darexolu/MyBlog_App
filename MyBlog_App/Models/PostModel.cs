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
        public int LikesCount { get; set; }
        public bool IsLiked { get; set; }

        public List<LikeModel> Likes { get; set; } = new List<LikeModel>();
    public List<CommentModel> Comments { get; set; } = new List<CommentModel>();
    }
}