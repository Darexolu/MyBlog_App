namespace MyBlog_App.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Assuming a user ID for simplicity
        public int PostId { get; set; } // Foreign key to associate the like with a post
    }
}
